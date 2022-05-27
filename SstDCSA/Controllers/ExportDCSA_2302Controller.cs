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
    public class ExportDCSA_2302Controller : Controller
    {
        // GET: ExportDCSA_2302
        public ActionResult Index()
        {
            DcsaContext db = new DcsaContext();
            var st = Convert.ToInt32(Session["Ucenter"]);
            return View(db.tbl_DCSA2302_mark2.Where(m => m.tbl_student.st_semester2 == true && m.exam_term != null && m.st_center_code == st).ToList());
        }
        public ActionResult ExportDCSA2302()
        {
            DcsaContext db = new DcsaContext();
            return View(db.tbl_DCSA2302_mark2.Where(m => m.tbl_student.st_semester2 == true && m.exam_term != null).ToList());
        }
    }
}