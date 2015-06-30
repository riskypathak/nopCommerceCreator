using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nopCommerce.Controllers
{
    public class CopyFileController : Controller
    {
        //
        // GET: /CopyFile/

        public ActionResult Index()
        {
            string applicationDirectoryPath = "C:\\inetpub\\wwwroot" + "\\" + "Test";

            if (!Directory.Exists(applicationDirectoryPath))
            {
                Directory.CreateDirectory(applicationDirectoryPath);
            }
            string sourcePath = "E:\\Anup\\Development\\Freelancer\\nopComp\\nopCommerce_3.60_NoSource";
            CopyPackageContent(sourcePath, applicationDirectoryPath);
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


    }
}
