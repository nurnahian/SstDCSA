using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using SstDCSA.Models;

namespace SstDCSA.Controllers
{
    public class HomeController : Controller
    {
        DcsaContext db = new DcsaContext();
        public ActionResult Index()
        {
            dynamic dy = new ExpandoObject();
            dy.UserList = getUser();

            ViewBag.TotalUser = db.tbl_users.Count();
            ViewBag.TotalStudent = db.tbl_student.Count();

            dy.CenterList = getCenter();
            dy.DCSA1201Mark=getDCSA1201();
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
        public List<tbl_DCSA1201_mark1> getDCSA1201()
        {
            DcsaContext db = new DcsaContext();
            List<tbl_DCSA1201_mark1> _DCSA1201 = db.tbl_DCSA1201_mark1.Where(m => m.tbl_student.st_semester1 == true && m.exam_term != null).ToList();
            return _DCSA1201;
        }


    }
}