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
    public class ExportDCSA_3303Controller : Controller
    {
        // GET: ExportDCSA_3303
        public ActionResult Index()
        {
            DcsaContext db = new DcsaContext();
            var st = Convert.ToInt32(Session["Ucenter"]);
            return View(db.tbl_DCSA3303_mark3.Where(m => m.tbl_student.st_semester3 == true && m.exam_term != null && m.st_center_code == st).ToList());
        }
        public ActionResult ExportDCSA3303()
        {
            DcsaContext db = new DcsaContext();
            return View(db.tbl_DCSA3303_mark3.Where(m => m.tbl_student.st_semester3 == true && m.exam_term != null).ToList());
        }
    }
}