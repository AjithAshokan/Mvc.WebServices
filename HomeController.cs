using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConcumingWbServicesMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult insert()
        {
            return View();
        }
        [HttpPost]
        public JsonResult InsertPost(string name, string city)
        {
            Webservice_insert.TestService objinsert = new Webservice_insert.TestService();
            int result = objinsert.InsertDetail(name, city);
            return Json(new { id = 1 }, JsonRequestBehavior.AllowGet);
                }
        

        
    }
}
