using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SstDCSA.Models;
using System.Dynamic;

namespace SstDCSA.Controllers
{
    public class MyCenterController : Controller
    {
        // GET: MyCenter
        DcsaContext db = new DcsaContext();
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.UserList = getUser();

            ViewBag.TotalUser = db.tbl_center.Count();
            var st = Convert.ToInt32(Session["Ucenter"]);
            ViewBag.TotalStudent = db.tbl_student.Where(s=>s.st_center_code == st).Count();

            dy.CenterList = getCenter();

            dy.Student = getstudent();
            dy.DCSA1201Mark = getDCSA1201();
            return View(dy);
        }
        public List<tbl_users> getUser()
        {
            DcsaContext db = new DcsaContext();
            List<tbl_users> _Users = db.tbl_users.OrderByDescending(t => t.user_id).ToList();
            return _Users;
        }

        public List<tbl_center> getCenter()
        {
            DcsaContext db = new DcsaContext();
            List<tbl_center> _Center = db.tbl_center.OrderByDescending(t => t.center_id).ToList();
            return _Center;
        }
        public List<tbl_student> getstudent()
        {
            DcsaContext db = new DcsaContext();
            var st = Convert.ToInt32(Session["Ucenter"]);
            List<tbl_student> student = db.tbl_student.Where(m => m.st_center_code== st).ToList();
            return student;
        }
        public List<tbl_DCSA1201_mark1> getDCSA1201()
        {
            DcsaContext db = new DcsaContext();
            List<tbl_DCSA1201_mark1> _DCSA1201 = db.tbl_DCSA1201_mark1.Where(m => m.tbl_student.st_semester1 == true && m.exam_term != null).ToList();
            return _DCSA1201;
        }

    }
}