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

using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Xml;

namespace LogReader
{
    partial class ThreadExceptionDialogEx : Form
    {
        public CrashReportDetails CrashReport { get; set; }

        public Action<CrashReportDetails> SendReportEvent;

        public ThreadExceptionDialogEx(Exception exception)
        {
            InitializeComponent();

            Text = Application.ProductName + " - Error Report";

            ShowInTaskbar = Application.OpenForms.Count == 0;

            _pictureBox.Image = SystemIcons.Error.ToBitmap();

            _reportText.Text = "Unhandled exception has occurred in the application:";
            _reportText.Text += Environment.NewLine;
            _reportText.Text += Environment.NewLine + exception.Message;
            _reportText.Text += Environment.NewLine;
            _reportText.Text += Environment.NewLine + "Please press 'Send Report' to notify " + Application.CompanyName;

            CrashReport = new CrashReportDetails();
            CrashReport.Items.Add(new ExceptionReport(exception));
            CrashReport.Items.Add(new ApplicationReport());
            CrashReport.Items.Add(new SystemReport());
            CrashReport.Items.Add(new MemoryPerformanceReport());
        }

        private void ThreadExceptionDialogEx_Load(object sender, EventArgs e)
        {
            foreach (object reportItem in CrashReport.Items)
            {
                _reportListBox.Items.Add(reportItem);
            }
        }

        private void _detailsBtn_Click(object sender, EventArgs e)
        {
            _reportListBox.Visible = !_reportListBox.Visible;
            if (_reportListBox.Visible)
                this.Height += 150;
            else
                this.Height -= 150;
        }

        private void _abortBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _sendReportBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (new HourGlass(this))
                {
                    Action<CrashReportDetails> handler = SendReportEvent;
                    if (handler != null)
                        handler(CrashReport);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Failed to send report");
            }
            DialogResult = DialogResult.Ignore;
            Close();
        }

        private void ThreadExceptionDialogEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.C))
            {
                Clipboard.SetText(_reportText.Text);
            }
        }

        private void _reportListBox_DoubleClick(object sender, EventArgs e)
        {
            object reportItem = _reportListBox.SelectedItem;
            if (reportItem != null)
            {
                using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
                {
                    //Create our own namespaces for the output
                    System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                    ns.Add("", "");
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(reportItem.GetType());
                    x.Serialize(stringWriter, reportItem, ns);
                    MessageBox.Show(this, stringWriter.ToString(), reportItem.GetType().ToString());
                }
            }
        }

        private void _reportListBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                e.IsInputKey = true;    // Steal the key-event from parent from
        }

        private void _reportListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                _reportListBox_DoubleClick(sender, e);
                e.Handled = true;
            }
        }
    }

    public class CrashReportDetails
    {
        [System.Xml.Serialization.XmlArray("ReportItems")]
        [System.Xml.Serialization.XmlArrayItem("Item")]
        public List<object> Items { get; set; }

        public CrashReportDetails()
        {
            Items = new List<object>();
        }

        public Type[] GetItemTypes()
        {
            List<Type> typesList = new List<Type>();
            foreach (object reportItem in Items)
                typesList.Add(reportItem.GetType());
            return typesList.ToArray();
        }
    }

    public class ExceptionReport
    {
        public string ExceptionDetails { get; set; }
        public string StackTrace { get; set; }
        public string ExceptionSource { get; set; }

        public ExceptionReport()
        {
        }

        public ExceptionReport(Exception exception)
        {
            StringBuilder exceptionReport = new StringBuilder();
            Exception innerException = exception;
            while (innerException != null)
            {
                exceptionReport.Append("  ");
                exceptionReport.Append(innerException.Message);
                exceptionReport.Append(" (");
                exceptionReport.Append(innerException.GetType().ToString());
                exceptionReport.AppendLine(")");
                innerException = innerException.InnerException;
            }
            ExceptionDetails = exceptionReport.ToString();
            ExceptionSource = exception.Source;
            StackTrace = exception.ToString();
        }
    }

    public class ApplicationReport
    {
        public string ApplicationTitle { get; set; }
        public string ApplicationVersion { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }

        public ApplicationReport()
        {
            ApplicationTitle = GetAssemblyTitle();
            ApplicationVersion = Application.ProductVersion;
            ProductName = Application.ProductName;
            CompanyName = Application.CompanyName;
        }

        static string GetAssemblyTitle()
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (!string.IsNullOrEmpty(titleAttribute.Title))
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }
    }

    public class SystemReport
    {
        public string OperatingSystem { get; set; }
        public string Platform { get; set; }
        public string FrameworkVersion { get; set; }
        public string Language { get; set; }

        public SystemReport()
        {
            OperatingSystem os = Environment.OSVersion;
            OperatingSystem = os.VersionString;
            if (IntPtr.Size == 4)
                Platform = "x86";
            else
                Platform = "x64";
            FrameworkVersion = System.Environment.Version.ToString();
            Language = Application.CurrentCulture.EnglishName;
        }
    }

    public class MemoryPerformanceReport
    {
        public long PrivateMemorySize;
        public long VirtualMemorySize;
        public long WorkingSet;
        public long PagedMemorySize;
        public long PeakWorkingSet;
        public long PeakVirtualMemorySize;
        public long PeakPagedMemorySize;
        public long ManagedMemorySize;

        internal MemoryPerformanceReport()
        {
            try
            {
                ManagedMemorySize = GC.GetTotalMemory(false);
                using (System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess())
                {
                    PrivateMemorySize = process.PrivateMemorySize64;
                    VirtualMemorySize = process.VirtualMemorySize64;
                    WorkingSet = process.WorkingSet64;
                    PagedMemorySize = process.PagedMemorySize64;
                    PeakWorkingSet = process.PeakWorkingSet64;
                    PeakVirtualMemorySize = process.PeakVirtualMemorySize64;
                    PeakPagedMemorySize = process.PeakPagedMemorySize64;
                }
            }
            catch
            {
            }
        }
    }

    class CheckForUpdates
    {
        public string PadUrl { get; set; }
        public bool PromptAlways { get; set; }

        public void SendReport(CrashReportDetails crashReport)
        {
            if (String.IsNullOrEmpty(PadUrl))
                return;
           
            System.Net.HttpWebRequest req = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(PadUrl);
            //HACK: add proxy
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            req.Proxy = proxy;
            req.PreAuthenticate = true;
            //HACK: end add proxy
            req.Accept = "text/html,application/xml";
            req.UserAgent = "Mozilla/5.0";  // Fix HTTP Error 406 Not acceptable - Security incident detected

            XmlDocument xmlDoc = new XmlDocument();
            using (WebResponse response = req.GetResponse())
            {
                xmlDoc.Load(response.GetResponseStream());
            }

            XmlNode appVerNode = xmlDoc.SelectSingleNode("/XML_DIZ_INFO/Program_Info/Program_Version");
            if (appVerNode != null)
            {
                Version appVer = new Version(appVerNode.InnerText);
                if (appVer > System.Reflection.Assembly.GetExecutingAssembly().GetName().Version)
                {
                    string message = "New version " + appVer.ToString() + " is available at application homepage.";
                    XmlNode appInfoURL = xmlDoc.SelectSingleNode("/XML_DIZ_INFO/Web_Info/Application_URLs/Application_Info_URL");
                    if (appInfoURL != null && !String.IsNullOrEmpty(appInfoURL.InnerText))
                    {
                        DialogResult res = MessageBox.Show(message + "\n\nCheck homepage for changelog and download?", "New update available", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (res == DialogResult.OK)
                            System.Diagnostics.Process.Start(appInfoURL.InnerText);
                    }
                    else
                    {
                        MessageBox.Show(message, "New update available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
            }

            if (PromptAlways)
                MessageBox.Show("Using the latest version", "Check for updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public class MailCrashReport
    {
        public string EmailHost { get; set; }
        public int EmailPort { get; set; }
        public string EmailUsername { get; set; }
        public string EmailPassword { get; set; }
        public string EmailToAddress { get; set; }
        public string EmailFromAddress { get; set; }
        public string EmailSubject { get; set; }
        public bool EmailSSL { get; set; }

        public void SendReport(CrashReportDetails crashReport)
        {
            // Convert ReportItems to EmailBody
            string emailBody = "";

            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
            {
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add("", "");
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(crashReport.GetType(), crashReport.GetItemTypes());
                x.Serialize(stringWriter, crashReport, ns);
                emailBody = stringWriter.ToString();
            }

            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(EmailFromAddress);
                foreach (string s in EmailToAddress.Split(";".ToCharArray()))
                {
                    msg.To.Add(s);
                }
                if (String.IsNullOrEmpty(EmailSubject))
                    msg.Subject = Application.ProductName + " - Error Report";
                else
                    msg.Subject = EmailSubject;

                msg.Body = emailBody;

                SmtpClient smtp = null;
                if (String.IsNullOrEmpty(EmailHost))
                {
                    smtp = new SmtpClient();
                }
                else
                {
                    if (EmailPort == 0)
                        smtp = new SmtpClient(EmailHost);
                    else
                        smtp = new SmtpClient(EmailHost, EmailPort);
                }
                if (String.IsNullOrEmpty(EmailUsername) && String.IsNullOrEmpty(EmailPassword))
                    smtp.UseDefaultCredentials = true;
                else
                    smtp.Credentials = new System.Net.NetworkCredential(EmailUsername, EmailPassword);
                smtp.EnableSsl = EmailSSL;
                smtp.Send(msg);
            }
        }
    }

    public class UploadCrashReport : IDisposable
    {
        public string HttpUrl { get; set; }
        public string FileName { get; set; }
        public string FileParamName { get; set; }
        public System.Collections.Specialized.NameValueCollection HttpParams { get; set; }

        System.IO.MemoryStream ZipStream = null;
        ZipStorer ZipStore = null;

        internal UploadCrashReport()
        {
            HttpParams = new System.Collections.Specialized.NameValueCollection();
            HttpParams.Add("AppName", Application.ProductName);
            HttpParams.Add("AppVersion", Application.ProductVersion);
            HttpParams.Add("CrashGuid", Guid.NewGuid().ToString());

            FileName = "crashrpt.zip";
            FileParamName = "crashrpt";

            string tmpFileName = System.IO.Path.GetTempFileName();
            MiniDumper.Write(tmpFileName, MiniDumper.Typ.MiniDumpNormal);

            ZipStream = new System.IO.MemoryStream();
            ZipStore = ZipStorer.Create(ZipStream, "Generated by ZipStorer class");
            ZipStore.AddFile(ZipStorer.Compression.Deflate, tmpFileName, "crashdump.dmp", "");
        }

        public void SendReport(CrashReportDetails crashReport)
        {
            // Create xml file containing reportItems
            string prettyXml = "";
            using (System.IO.StringWriter stringWriter = new System.IO.StringWriter())
            {
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add("", "");
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(crashReport.GetType(), crashReport.GetItemTypes());
                x.Serialize(stringWriter, crashReport, ns);
                prettyXml = stringWriter.ToString();
            }

            using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(new System.IO.MemoryStream()))
            {
                streamWriter.WriteLine(prettyXml);
                streamWriter.Flush();
                streamWriter.BaseStream.Position = 0;
                ZipStore.AddStream(ZipStorer.Compression.Deflate, "crashrpt.xml", streamWriter.BaseStream, DateTime.Now, "");
            }

            ZipStore.Close();

            // Upload File
            HttpUploadFile(HttpUrl, ZipStream.ToArray(), FileParamName, FileName, "application/x-zip-compressed", HttpParams);
        }

        protected virtual void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (ZipStore != null)
                    ZipStore.Dispose();
                if (ZipStream != null)
                    ZipStream.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Credits Cristian Romanescu @ http://stackoverflow.com/questions/566462/upload-files-with-httpwebrequest-multipart-form-data
        static void HttpUploadFile(string url, byte[] fileContents, string fileParam, string fileName, string contentType, System.Collections.Specialized.NameValueCollection nvc)
        {
            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            System.Net.HttpWebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //HACK: add proxy
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            wr.Proxy = proxy;
            wr.PreAuthenticate = true;
            //HACK: end add proxy
            wr.Accept = "text/html,application/xml";
            wr.UserAgent = "Mozilla/5.0";   // Fix HTTP Error 406 Not acceptable - Security incident detected
            wr.ContentType = "multipart/form-data; boundary=" + boundary;
            wr.Method = "POST";

            System.IO.Stream rs = wr.GetRequestStream();

            {
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n";
                foreach (string key in nvc.Keys)
                {
                    // Parameter Header (+ boundary)
                    rs.Write(boundarybytes, 0, boundarybytes.Length);
                    string header = string.Format(formdataTemplate, key);
                    byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                    rs.Write(headerbytes, 0, headerbytes.Length);

                    // Parameter Content
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(nvc[key].ToString());
                    rs.Write(buffer, 0, buffer.Length);
                }
            }
            {
                // File Header (+ boundary)
                rs.Write(boundarybytes, 0, boundarybytes.Length);
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, fileParam, fileName, contentType);
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                rs.Write(headerbytes, 0, headerbytes.Length);

                // File Content
                rs.Write(fileContents, 0, fileContents.Length);
            }
            {
                // WebRequest Trailer
                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                rs.Write(trailer, 0, trailer.Length);
            }
            rs.Close();

            try
            {
                using (System.Net.WebResponse wresp = wr.GetResponse())
                {
                    System.IO.StreamReader respReader = new System.IO.StreamReader(wresp.GetResponseStream());
                    //MessageBox.Show(respReader.ReadToEnd());
                }
            }
            catch (System.Net.WebException ex)
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(ex.Response.GetResponseStream());
                MessageBox.Show(ex.Message + " " + reader.ReadToEnd());
            }
        }
    }
}
