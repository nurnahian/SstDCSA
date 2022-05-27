using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SstDCSA.Models;

namespace SstDCSA.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogCheck(tbl_users model)
        {
            //if (ModelState.IsValid)
            //{
            using (DcsaContext db = new DcsaContext())
            {
                var v = db.tbl_users.Where(a => a.user_name.Equals(model.user_name) && a.user_password.Equals(model.user_password)).FirstOrDefault();
                if (v != null)
                {
                    var role = db.tbl_users.Where(a => a.user_role.Equals("Admin") && a.user_name.Equals(model.user_name)).FirstOrDefault();


                    //string r = role.user_role.ToString();
                    if (role != null)
                    {
                        Session["Aname"] = v.user_name.ToString();
                        return RedirectToAction("AdminCheck");
                    }
                    else
                    {
                        Session["Uname"] = v.user_name.ToString();
                        Session["Ucenter"] = v.user_center_code;
                        return RedirectToAction("UserCheck");
                    }

                }
                else
                {
                    return RedirectToAction("Index", "Log"); ;
                }

            }

            // }
            //return View("Log");

        }
        public ActionResult AdminCheck()
        {
            if (Session["Aname"] != null)
            {
                //return View("~/Views/Home/Index.cshtml");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult UserCheck()
        {
            if (Session["Uname"] != null)
            {
                return RedirectToAction("Index", "MyCenter");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Log");
        }
    }
}