using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LDAPConnectivityTest.Controllers
{
    [Route("/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
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
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(e.ToString());
            }
            
        }

    }
}