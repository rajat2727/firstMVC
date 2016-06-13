using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using firstMVC.Models;
using System.Data;
using System.Dynamic;

namespace firstMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            CodeDB cc = new CodeDB();
            DataTable objDataTable = cc.getAllMusicTypes();
            ViewBag.getAllMusicTypes = objDataTable;
            return View();

            //  return Content("This method returns plain texts.");

            //var employee = new
            //{
            //    Name = "Rajat Sharma",
            //    Age = "25",
            //    Occupation = "Software Developer"
            //};
            //return Json(employee, JsonRequestBehavior.AllowGet);

            //return File(Server.MapPath("~/App_Data/documentation.pdf"),
            //        contentType: "application/pdf",
            //        fileDownloadName: "documentation.pdf");
        }

        //public ActionResult getMusic()
        //{
        //    CodeDB cc = new CodeDB();
        //    return View(cc.setDataInMusicDetailModel());
        //}

        public ActionResult getMusic()
        {
            CodeDB cc = new CodeDB();
            MvcMusicStoreEntities musicDB = new MvcMusicStoreEntities();
            dynamic model = new ExpandoObject();
            model.Genres = musicDB.Genres.ToList();
            model.Albums = musicDB.Albums.ToList(); 
            return View(model);
        }
        //public ActionResult Index()
        //{
        //    return RedirectToAction("Contact");
        //}

        //public ActionResult Contact()
        //{
        //    return Content("This is the redirected Contact method.");
        //}
    }
}