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

namespace LogReader
{
    static class Program
    {
        static volatile bool applicationCrashed = false;
        public static readonly string PadUrl = "http://snakenest.com/snaketail.pad.xml";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (applicationCrashed)
                return;
            applicationCrashed = true;

            if (e.ExceptionObject is Exception)
                SendCrashReport(e.ExceptionObject as Exception);
            else
                SendCrashReport(new Exception(string.Format("Unknown Exception - {0}", e.ExceptionObject)));

            applicationCrashed = false;
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (applicationCrashed)
                return;
            applicationCrashed = true;

            SendCrashReport(e.Exception);

            applicationCrashed = false;
        }

        static void SendCrashReport(Exception ex)
        {
            CheckForUpdates updateChecker = new CheckForUpdates();
            updateChecker.PadUrl = PadUrl;

            ThreadExceptionDialogEx dlg = new ThreadExceptionDialogEx(ex);
            dlg.SendReportEvent += updateChecker.SendReport;
            if (MainForm.Instance != null && !MainForm.Instance.IsDisposed)
                dlg.ShowDialog(MainForm.Instance);
            else
                dlg.ShowDialog();
        }
    }
}
