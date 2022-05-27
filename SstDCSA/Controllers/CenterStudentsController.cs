using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SstDCSA.Models;


namespace SstDCSA.Controllers
{
   
    public class CenterStudentsController : Controller
    {
        DcsaContext db = new DcsaContext();
        // GET: CenterStudents
        public ActionResult Index()
        {
            var st = Convert.ToInt32(Session["Ucenter"]);

            return View(db.tbl_student.Where(s=>s.st_center_code== st).ToList());
            
        }
    }
}