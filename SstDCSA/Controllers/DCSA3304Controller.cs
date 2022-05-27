using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SstDCSA.Models;
using System.Data;
using System.IO;
using System.Configuration;

namespace SstDCSA.Controllers
{
    public class DCSA3304Controller : Controller
    {
        // GET: DCSA3304
        public ActionResult Index()
        {
            DcsaContext db = new DcsaContext();
            var st = Convert.ToInt32(Session["Ucenter"]);
            List<tbl_DCSA3304_mark3> DCSA3304 = db.tbl_DCSA3304_mark3.Where(s => s.tbl_student.st_semester2 == true && s.st_center_code == st).ToList();
            return View(DCSA3304.ToList());
        }

        [HttpPost]
        public ActionResult UpdateCustomer(tbl_DCSA3304_mark3 customer)
        {
            using (DcsaContext db = new DcsaContext())
            {
                tbl_DCSA3304_mark3 updatedCustomer = (from c in db.tbl_DCSA3304_mark3
                                                      where c.st_registration == customer.st_registration
                                                      select c).FirstOrDefault();

                updatedCustomer.project_report = customer.project_report;
                updatedCustomer.viva = customer.viva;

                updatedCustomer.exam_term = customer.exam_term;
                updatedCustomer.submit_date = DateTime.Now;

                db.SaveChanges();
            }

            return new EmptyResult();
        }
    }
}