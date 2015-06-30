using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Collections.Specialized;

namespace nopCommerceCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region [Event]
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            //CreateLocalUserAccount("nopcommerce_user", "Password@123");

            string applicationDirectoryPath = StaticData.ParentPath + "\\" + txtSubdomain.Text;

            if (!Directory.Exists(applicationDirectoryPath))
            {
                Directory.CreateDirectory(applicationDirectoryPath);
            }
            string sourcePath = txtSourcePath.Text;
            CopyPackageContent(sourcePath, applicationDirectoryPath);
            AddApplication("Default Web Site", "/" + txtSubdomain.Text, "DefaultAppPool", "/", applicationDirectoryPath, "", "");
            if (chkBinding.Checked)
            {
                AddSiteBinding("Default Web Site", txtIP.Text, txtPort.Text, "", "http");
            }
            WebPageCall("http://localhost/" + txtSubdomain.Text + "/install");
            

        }
        #endregion

        #region [Copy File]

        public static void CopyPackageContent(string sourcePath, string destinaionPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*",
                SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, destinaionPath));

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*",
                SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, destinaionPath), true);
        }
        #endregion

        #region [Add Application]
        public static bool AddApplication(string siteName, string applicationPath, string applicationPool, string virtualDirectoryPath, string physicalPath, string userName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(siteName))
                    throw new ArgumentNullException("siteName", "AddApplication: siteName is null or empty.");
                if (string.IsNullOrEmpty(applicationPath))
                    throw new ArgumentNullException("applicationPath", "AddApplication: application path is null or empty.");
                if (string.IsNullOrEmpty(physicalPath))
                    throw new ArgumentNullException("PhysicalPath", "AddApplication: Invalid physical path.");
                if (string.IsNullOrEmpty(applicationPool))
                    throw new ArgumentNullException("ApplicationPool", "AddApplication: application pool namespace is Nullable or empty.");
                using (ServerManager mgr = new ServerManager())
                {
                    ApplicationPool appPool = mgr.ApplicationPools[applicationPool];
                    if (appPool == null)
                        throw new Exception("Application Pool: " + applicationPool + " does not exist.");
                    Site site = mgr.Sites[siteName];
                    if (site != null)
                    {
                        Microsoft.Web.Administration.Application app = site.Applications[applicationPath];
                        if (app != null)
                            throw new Exception("Application: " + applicationPath + " already exists.");
                        else
                        {
                            app = site.Applications.CreateElement();
                            app.Path = applicationPath;
                            app.ApplicationPoolName = applicationPool;
                            VirtualDirectory vDir = app.VirtualDirectories.CreateElement();
                            vDir.Path = virtualDirectoryPath;
                            vDir.PhysicalPath = physicalPath;
                            if (!string.IsNullOrEmpty(userName))
                            {
                                if (string.IsNullOrEmpty(password))
                                    throw new Exception("Invalid Virtual Directory User Account Password.");
                                else
                                {
                                    vDir.UserName = userName;
                                    vDir.Password = password;
                                }
                            }
                            app.VirtualDirectories.Add(vDir);
                        }
                        site.Applications.Add(app);
                        mgr.CommitChanges();
                        return true;
                    }
                    else
                        throw new Exception("Site: " + siteName + " does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region [Binding]
        public static bool AddSiteBinding(string siteName, string ipAddress, string tcpPort, string hostHeader, string protocol)
        {
            try
            {
                if (string.IsNullOrEmpty(siteName))
                {
                    throw new ArgumentNullException("siteName", "AddSiteBinding: siteName is null or empty.");
                }
                //get the server manager instance
                using (ServerManager mgr = new ServerManager())
                {
                    SiteCollection sites = mgr.Sites;
                    Site site = mgr.Sites[siteName];
                    if (site != null)
                    {
                        string bind = ipAddress + ":" + tcpPort + ":" + hostHeader;
                        //check the binding exists or not
                        foreach (Microsoft.Web.Administration.Binding b in site.Bindings)
                        {
                            if (b.Protocol == protocol && b.BindingInformation == bind)
                            {
                                throw new Exception("A binding with the same ip, port and host header already exists.");
                            }
                        }
                        Microsoft.Web.Administration.Binding newBinding = site.Bindings.CreateElement();
                        newBinding.Protocol = protocol;
                        newBinding.BindingInformation = bind;
                        site.Bindings.Add(newBinding);
                        mgr.CommitChanges();
                        return true;
                    }
                    else
                        throw new Exception("Site: " + siteName + " does not exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        #endregion

        #region [User Account Create]
       
        public static bool CreateLocalUserAccount(string userName, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                    throw new ArgumentNullException("userName", "Invalid User Name.");
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentNullException("password", "Invalid Password.");
                DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://" +
                Environment.MachineName + ",computer");
                bool userFound = false;
                try
                {
                    if (directoryEntry.Children.Find(userName, "user") != null)
                        userFound = true;
                }
                catch
                {
                    userFound = false;
                }
                if (!userFound)
                {
                    DirectoryEntry newUser = directoryEntry.Children.Add(userName, "user");
                    newUser.Invoke("SetPassword", new object[] { password });
                    newUser.Invoke("Put", new object[] { "Description", "Application Pool User Account" });
                    newUser.CommitChanges();
                    newUser.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return true;
        }
        #endregion

        #region [Create Application Pool]
        public static bool CreateApplicationPool(string applicationPoolName, ProcessModelIdentityType identityType, string applicationPoolIdentity, string password, string managedRuntimeVersion, bool autoStart, bool enable32BitAppOnWin64, ManagedPipelineMode managedPipelineMode, long queueLength, TimeSpan idleTimeout, long periodicRestartPrivateMemory, TimeSpan periodicRestartTime)
        {
            try
            {
                if (identityType == ProcessModelIdentityType.SpecificUser)
                {
                    if (string.IsNullOrEmpty(applicationPoolName))
                        throw new ArgumentNullException("applicationPoolName", "CreateApplicationPool: applicationPoolName is null or empty.");
                    if (string.IsNullOrEmpty(applicationPoolIdentity))
                        throw new ArgumentNullException("applicationPoolIdentity", "CreateApplicationPool: applicationPoolIdentity is null or empty.");
                    if (string.IsNullOrEmpty(password))
                        throw new ArgumentNullException("password", "CreateApplicationPool: password is null or empty.");
                }
                using (ServerManager mgr = new ServerManager())
                {
                    ApplicationPool newAppPool = mgr.ApplicationPools.Add(applicationPoolName);
                    if (identityType == ProcessModelIdentityType.SpecificUser)
                    {
                        newAppPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                        newAppPool.ProcessModel.UserName = applicationPoolIdentity;
                        newAppPool.ProcessModel.Password = password;
                    }
                    else
                    {
                        newAppPool.ProcessModel.IdentityType = identityType;
                    }
                    if (!string.IsNullOrEmpty(managedRuntimeVersion))
                        newAppPool.ManagedRuntimeVersion = managedRuntimeVersion;
                    newAppPool.AutoStart = autoStart;
                    newAppPool.Enable32BitAppOnWin64 = enable32BitAppOnWin64;
                    newAppPool.ManagedPipelineMode = managedPipelineMode;
                    if (queueLength > 0)
                        newAppPool.QueueLength = queueLength;
                    if (idleTimeout != TimeSpan.MinValue)
                        newAppPool.ProcessModel.IdleTimeout = idleTimeout;
                    if (periodicRestartPrivateMemory > 0)
                        newAppPool.Recycling.PeriodicRestart.PrivateMemory = periodicRestartPrivateMemory;
                    if (periodicRestartTime != TimeSpan.MinValue)
                        newAppPool.Recycling.PeriodicRestart.Time = periodicRestartTime;
                    mgr.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return true;
        }
        #endregion

        #region [Webpage call]
        private void WebPageCall(string URL)
        {
            string AdminEmail = txtAdminEmail.Text;
            string AdminPassword =txtPassword.Text;
            string ConfirmPassword = txtPassword.Text;
            string InstallSampleData = "false";
            string DataProvider = "sqlserver";
            string SqlServerCreateDatabase = chkDBExits.Checked.ToString();
            //string SqlServerCreateDatabase1 = "false";
            string SqlConnectionInfo = "sqlconnectioninfo_values";
            string SqlServerName = txtSqlServerName.Text;
            string SqlDatabaseName =txtDatabaseName.Text;
            string SqlAuthenticationType = "";
           
            if (radioSQLAuth.Checked)
            {
                SqlAuthenticationType = "sqlauthentication";
                radioWindowsAuth.Checked = false;
            }
            else
            {
                SqlAuthenticationType = "windowsauthentication";
                radioSQLAuth.Checked = false;
                txtSQLUser.Text = "";
                txtSqlPass.Text = "";
            }
            string SqlServerUsername = txtSQLUser.Text;
            string SqlServerPassword = txtSqlPass.Text;
            string DatabaseConnectionString = "";
            string UseCustomCollation = "false";
            string Collation = "SQL_Latin1_General_CP1_CI_AS";
            string language = "/nopcommerce/Install/ChangeLanguage?language=en";


            //URL=http://localhost/nopcommerce/install ;

            String Url = URL;
            //HtmlAgilityPack.HtmlDocument document = GetWebRequest(Url);
            //NameValueCollection formData = GetFormData(document);
            NameValueCollection formData = new NameValueCollection();
            formData["AdminEmail"] = AdminEmail;
            formData["AdminPassword"] = AdminPassword;
            formData["ConfirmPassword"] = ConfirmPassword;
            formData["InstallSampleData"] = InstallSampleData;
            formData["DataProvider"] = DataProvider;
            formData["SqlServerCreateDatabase"] = SqlServerCreateDatabase;
           // formData["SqlServerCreateDatabase"] = SqlServerCreateDatabase1;
            formData["SqlConnectionInfo"] = SqlConnectionInfo;
            formData["SqlServerName"] = SqlServerName;
            formData["SqlDatabaseName"] = SqlDatabaseName;
            formData["SqlAuthenticationType"] = SqlAuthenticationType;
            formData["SqlServerUsername"] = SqlServerUsername;
            formData["SqlServerPassword"] = SqlServerPassword;
            formData["DatabaseConnectionString"] = DatabaseConnectionString;
            formData["UseCustomCollation"] = UseCustomCollation;
            formData["Collation"] = Collation;
            formData["language"] = language;

            HtmlAgilityPack.HtmlDocument doc = PostRequest(Url, null, formData);
            bool Success = doc.DocumentNode.OuterHtml.Contains("Your store");
            if (Success)
            {
                //Utility.ApplicationLog("AdiGlobal login sucessful");
               MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
               
      
        #endregion

        #region [Other]
       
        public HtmlAgilityPack.HtmlDocument GetWebRequest(String Url)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                byte[] responseBytes;
                responseBytes = httpClient.DownloadData(Url);
                MemoryStream mStream = new MemoryStream(responseBytes);
                document.Load(mStream);
                return document;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public NameValueCollection GetFormData(HtmlAgilityPack.HtmlDocument document)
        {
            NameValueCollection formData = new NameValueCollection();
            var inputItems = document.DocumentNode.SelectNodes("//input");//.Descendants()
        

            foreach (var items in inputItems)
            {
                if (items.Attributes.Contains("id") && items.Attributes["id"].Value!="")
                formData.Add(items.Attributes["id"].Value, items.Attributes["value"] == null ? String.Empty : items.Attributes["value"].Value);
            }
           
            return formData;
        }

        public HtmlAgilityPack.HtmlDocument PostRequest(String Url, System.Net.WebHeaderCollection Header, NameValueCollection formData)
        {
           
                try
                {
                    HttpClient httpClient = new HttpClient();
                    httpClient.SetTimeout(1800000);
                    byte[] responseBytes;                    
                    if (!ReferenceEquals(Header, null))
                    {
                        httpClient.Headers = Header;
                    }
                    if (!ReferenceEquals(formData, null))
                    {
                        httpClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        responseBytes = httpClient.UploadValues(Url, "POST", formData);
                    }
                    else
                    {
                        responseBytes = httpClient.DownloadData(Url);
                    }
                    string resultAuthTicket = Encoding.UTF8.GetString(responseBytes);
                    httpClient.Dispose();
                    MemoryStream mStream = new MemoryStream(responseBytes);
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.Load(mStream);
                    return document;
                }
                catch (Exception ex)
                {
                   
                        throw ex;
                }

        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtSourcePath);
        }
        #endregion

        #region [Browse]
        private void BrowseFolder(TextBox textBox)
        {
            folderBrowserDialog1.ShowDialog();
            textBox.Text = folderBrowserDialog1.SelectedPath;
        }
        #endregion

       

    }
}
