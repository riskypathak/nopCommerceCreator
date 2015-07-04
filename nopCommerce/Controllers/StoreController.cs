using Microsoft.Web.Administration;
using nopCommerce.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using nopCommerce;
using System.Data.SqlClient;
using System.Configuration;

namespace nopCommerce.Controllers
{
    public class StoreController : Controller
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public SqlCommand cmd;
        //
        // GET: /Store/
        public string StartStore(StoreDetails oStoreDetails)
        {
           
            //StoreDetails oStoreDetails = new StoreDetails();
            //oStoreDetails.Email = "TestMail@gmail.com";
            //oStoreDetails.StoreName = "Mystore6";
            //oStoreDetails.StorePassword = "1234";
            //Index(oStoreDetails);
            string applicationDirectoryPath = System.Configuration.ConfigurationManager.AppSettings["ParentPath"] + "\\" + oStoreDetails.StoreName;

            if (!Directory.Exists(applicationDirectoryPath))
            {
                Directory.CreateDirectory(applicationDirectoryPath);
            }
            string sourcePath = System.Configuration.ConfigurationManager.AppSettings["SourcePath"];
            CopyPackageContent(sourcePath, applicationDirectoryPath);
            AddApplication("Default Web Site", "/" + oStoreDetails.StoreName, "DefaultAppPool", "/", applicationDirectoryPath, "", "");
            string status = WebPageCall(System.Configuration.ConfigurationManager.AppSettings["MainDomain"] + oStoreDetails.StoreName + "/install", oStoreDetails);
            return status;
        }

        public ActionResult Index(StoreDetails oStoreDetails)
        {
           
            //try
            //{
                
            //}
            //catch(Exception ex) 
            //{
            //    ViewBag.Message("Error");
            //}
            return View();
        }
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
                System.IO.File.Copy(newPath, newPath.Replace(sourcePath, destinaionPath), true);
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
                using (ServerManager mgr1 = new ServerManager())
                {
                    ServerManager mgr = new ServerManager();
                     mgr = ServerManager.OpenRemote(Environment.MachineName);
                    //This throws an exception
                    mgr = new ServerManager(@"%windir%\system32\inetsrv\config\applicationhost.config");

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

        #region [Webpage call]
        private string WebPageCall(string URL, StoreDetails oStoreDetails)
        {
            string AdminEmail = oStoreDetails.Email;
            string AdminPassword = oStoreDetails.StorePassword;
            string ConfirmPassword = oStoreDetails.StorePassword;
            string InstallSampleData = "false";
            string DataProvider = "sqlserver";
            string SqlServerCreateDatabase = "true";
            //string SqlServerCreateDatabase1 = "false";
            string SqlConnectionInfo = "sqlconnectioninfo_values";
            string SqlServerName = System.Configuration.ConfigurationManager.AppSettings["SqlServerName"];
            string SqlDatabaseName = oStoreDetails.StoreName;
            string SqlAuthenticationType = "";
            SqlAuthenticationType = "sqlauthentication";
            string SqlServerUsername = System.Configuration.ConfigurationManager.AppSettings["SqlServerUsername"];
            string SqlServerPassword = System.Configuration.ConfigurationManager.AppSettings["SqlServerPassword"];
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
                //NameValueCollection formDataAdmin = new NameValueCollection();
                //URL = System.Configuration.ConfigurationManager.AppSettings["MainDomain"] + oStoreDetails.StoreName + "/login?ReturnUrl=" + oStoreDetails.StoreName + "/admin";
                //HtmlAgilityPack.HtmlDocument document = GetWebRequest(URL);
                //formDataAdmin = GetFormData(document);
               
                //formDataAdmin["Email"] = AdminEmail;
                //formDataAdmin["Password"] = AdminPassword;
                //formDataAdmin["RememberMe"] = "false";
                //HtmlAgilityPack.HtmlDocument docAdmin = PostRequest(URL, null, formDataAdmin);
                //URL = System.Configuration.ConfigurationManager.AppSettings["MainDomain"] + oStoreDetails.StoreName + "/admin";
                return (URL);
            }
            else
            {
                return "ERROR";
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
                if (items.Attributes.Contains("id") && items.Attributes["id"].Value != "")
                    formData.Add(items.Attributes["id"].Value, items.Attributes["value"] == null ? String.Empty : items.Attributes["value"].Value);
            }

            return formData;
        }

        public HtmlAgilityPack.HtmlDocument PostRequest(String Url, System.Net.WebHeaderCollection Header, NameValueCollection formData)
        {

            try
            {
                System.Threading.Thread.Sleep(60000);
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

        #endregion

        #region [Store Name From DB]
        public DataTable GetStoreName(string storeName,string userName)
        {
            SqlDataAdapter adp;
            DataTable dt = new DataTable();
            adp = new SqlDataAdapter("SP_GET_STORENAME", con);
            adp.SelectCommand.Parameters.AddWithValue("@StoreName", storeName);
            adp.SelectCommand.Parameters.AddWithValue("@UserName", userName);
            adp.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            adp.Fill(dt);
            return dt;            
        }
        #endregion

        #region [Store Name]
        public int SaveStoreName(string storeName, string userName)
        {

            int iRowAffected = 0;
            cmd = new SqlCommand("SP_AD_STORENAME", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StoreName", SqlDbType.NVarChar).Value = storeName;
            cmd.Parameters.AddWithValue("@UserName", SqlDbType.NVarChar).Value = userName;
            try
            {
                con.Open();
                iRowAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception oException)
            {
                throw oException;
            }
            finally
            {
                con.Close();
                cmd.Dispose();
            }

            return iRowAffected;


        }
        #endregion

    }
}
