﻿#region License statement
/* SnakeTail is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, version 3 of the License.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion

using System.Diagnostics;
using System.Security.Principal;
using System.ServiceProcess;

namespace LogReader
{
    class TaskMonitor : IDisposable
    {
        public string ServiceName { get; set; }
        public string ServiceMachineName { get; set; }
        public System.ServiceProcess.ServiceController ServiceController { get { return _serviceController; } }

        System.ServiceProcess.ServiceController _serviceController;
        System.Diagnostics.Process _process;
        CPUMeter _cpuMeter;

        public void Dispose()
        {
            if (_serviceController != null)
            {
                _serviceController.Dispose();
                _serviceController = null;
            }
            Process = null;
        }

        private int GetProcessID(string name)
        {
            if (_serviceController != null)
                return (int)GetProcessIDByServiceName(name);
            else
                return GetProcessIDByProcessName(name);
        }

        private static int GetProcessIDByProcessName(string processeName)
        {
            Process[] processList = Process.GetProcessesByName(processeName.Substring(0, processeName.LastIndexOf('.')));
            try
            {
                foreach (Process process in processList)
                {
                    if (process.Id > 0)
                        return process.Id;
                }
            }
            finally
            {
                foreach (Process process in processList)
                    process.Dispose();
            }
            return 0;
        }

        private static uint GetProcessIDByServiceName(string serviceName)
        {
            uint processId = 0;
            string qry = "SELECT PROCESSID FROM WIN32_SERVICE WHERE NAME = '" + serviceName + "'";
            using (System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(qry))
            {
                foreach (System.Management.ManagementObject mngntObj in searcher.Get())
                {
                    using (mngntObj)
                    {
                        processId = (uint)mngntObj["PROCESSID"];
                        if (processId > 0)
                            return processId;
                    }
                }
            }
            return processId;
        }

        public Process Process
        {
            get
            {
                if (_process == null || !ServiceRunning)
                {
                    Process = null;
                    if (ServiceRunning)
                    {
                        int processId = GetProcessID(ServiceName);
                        if (processId > 0)
                        {
                            Process = System.Diagnostics.Process.GetProcessById(processId);
                        }
                    }
                }
                return _process;
            }
            private set
            {
                if (_process != null)
                {
                    _process.Exited -= _process_Exited;
                    _process.Dispose();
                    _process = null;
                }
                if (_cpuMeter != null)
                {
                    _cpuMeter.Dispose();
                    _cpuMeter = null;
                }

                if (value != null)
                {
                    _process = value;
                    _process.Exited += _process_Exited;
                    if (IsAdministrator)
                        PerformanceCounter.CloseSharedResources();
                    _cpuMeter = new CPUMeter(_process.Id);
                }
            }
        }

        void _process_Exited(object sender, EventArgs e)
        {
            Process = null;
        }

        public float ProcessorUsage
        {
            get
            {
                try
                {
                    if (_process != null)
                        return _cpuMeter.GetCpuUtilization();
                    else
                        return 0;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("CPU Meter Failed: " + ex.Message);
                    Process = null;
                    return 0;
                }
            }
        }

        public TaskMonitor(string serviceName, string serviceMachineName)
        {
            ServiceName = serviceName;
            ServiceMachineName = serviceMachineName;
            if (serviceName.IndexOf('.') == -1 || !string.IsNullOrEmpty(serviceMachineName))
            {
                if (string.IsNullOrEmpty(ServiceMachineName))
                    _serviceController = new System.ServiceProcess.ServiceController(ServiceName);
                else
                    _serviceController = new System.ServiceProcess.ServiceController(ServiceName, ServiceMachineName);
            }
        }

        public bool ServiceRunning
        {
            get
            {
                if (_serviceController != null)
                {
                    try
                    {
                        _serviceController.Refresh();
                        return _serviceController.Status != ServiceControllerStatus.Stopped;
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("ServiceController Failed: " + ex.Message);
                        Process = null;
                        return false;
                    }
                }
                else
                {
                    try
                    {
                        if (_process == null)
                            return GetProcessIDByProcessName(ServiceName) > 0;
                        else
                        if (_process.Responding)
                            return true;
                        else
                        {
                            Process = null;
                            return false;
                        }
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("ServiceController Failed: " + ex.Message);
                        Process = null;
                        return false;
                    }
                }
            }
        }

        public bool CanPauseAndContinue
        {
            get
            {
                if (ServiceController != null)
                {
                    try
                    {
                        return ServiceController.CanPauseAndContinue;
                    }
                    catch (System.InvalidOperationException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("ServiceController Failed: " + ex.Message);
                        return false;
                    }
                }
                else
                    return false;
            }
        }

        private bool IsAdministrator
        {
            get
            {
                WindowsIdentity wi = WindowsIdentity.GetCurrent();
                WindowsPrincipal wp = new WindowsPrincipal(wi);

                return wp.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public void StartService()
        {
            if (_serviceController == null)
                return;

            try
            {
                ProcessStartInfo startInfo = string.IsNullOrEmpty(ServiceMachineName) ?
                    new ProcessStartInfo("sc.exe", "start " + ServiceName) :
                    new ProcessStartInfo("sc.exe", "\\\\" + ServiceMachineName + " start " + ServiceName);
                if (!IsAdministrator)
                    startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("sc.exe start failed: " + ex.Message, ex);
            }
        }

        public void StopService()
        {
            if (_serviceController == null)
                return;

            try
            {
                ProcessStartInfo startInfo = string.IsNullOrEmpty(ServiceMachineName) ?
                    new ProcessStartInfo("sc.exe", "stop " + ServiceName) :
                    new ProcessStartInfo("sc.exe", "\\\\" + ServiceMachineName + " stop " + ServiceName);
                if (!IsAdministrator)
                    startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("sc.exe stop failed: " + ex.Message, ex);
            }
        }

        public void PauseService()
        {
            if (_serviceController == null)
                return;

            try
            {
                ProcessStartInfo startInfo = string.IsNullOrEmpty(ServiceMachineName) ?
                    new ProcessStartInfo("sc.exe", "pause " + ServiceName) :
                    new ProcessStartInfo("sc.exe", "\\\\" + ServiceMachineName + " pause " + ServiceName);
                if (!IsAdministrator)
                    startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("sc.exe pause failed: " + ex.Message, ex);
            }
        }

        public void ContinueService()
        {
            if (_serviceController == null)
                return;

            try
            {
                ProcessStartInfo startInfo = string.IsNullOrEmpty(ServiceMachineName) ?
                    new ProcessStartInfo("sc.exe", "continue " + ServiceName) :
                    new ProcessStartInfo("sc.exe", "\\\\" + ServiceMachineName + " continue " + ServiceName);
                if (!IsAdministrator)
                    startInfo.Verb = "runas";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                throw new Exception("sc.exe continue failed: " + ex.Message, ex);
            }
        }
    }
}
