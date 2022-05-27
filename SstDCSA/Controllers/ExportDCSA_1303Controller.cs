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
    public class ExportDCSA_1303Controller : Controller
    {
        // GET: ExportDCSA_1303
        public ActionResult Index()
        {
            DcsaContext db = new DcsaContext();
            var st = Convert.ToInt32(Session["Ucenter"]);
            return View(db.tbl_DCSA1303_mark1.Where(m => m.tbl_student.st_semester1 == true && m.exam_term != null && m.st_center_code == st).ToList());
        }
        public ActionResult ExportDCSA1303()
        {
            DcsaContext db = new DcsaContext();
            return View(db.tbl_DCSA1303_mark1.Where(m => m.tbl_student.st_semester1 == true && m.exam_term != null).ToList());
        }
    }
}