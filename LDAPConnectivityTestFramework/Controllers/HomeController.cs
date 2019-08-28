using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LDAPConnectivityTestFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var directoryEntry = new DirectoryEntry("LDAP://35.222.32.157", "iwasvc", "New0rder");
                var searcher = new DirectorySearcher(directoryEntry)
                {
                    PageSize = int.MaxValue,
                    Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=iwasvc))"
                };

                searcher.PropertiesToLoad.Add("sn");

                var result = searcher.FindOne();
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Content(e.ToString());
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}