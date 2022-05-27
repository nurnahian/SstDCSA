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
    public class DCSA1302_mark1Controller : Controller
    {
        private DcsaContext db = new DcsaContext();

        // GET: DCSA1302_mark1
        public ActionResult Index()
        {
            var tbl_DCSA1302_mark1 = db.tbl_DCSA1302_mark1.Include(t => t.tbl_student);
            return View(tbl_DCSA1302_mark1.Where(t => t.tbl_student.st_semester1 == true).ToList());
        }

        // GET: DCSA1302_mark1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DCSA1302_mark1 tbl_DCSA1302_mark1 = db.tbl_DCSA1302_mark1.Find(id);
            if (tbl_DCSA1302_mark1 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DCSA1302_mark1);
        }

        // GET: DCSA1302_mark1/Create
        public ActionResult Create()
        {
            ViewBag.st_registration = new SelectList(db.tbl_student.Where(s => s.st_semester1 == true), "st_registration", "st_name");
            return View();
        }

        // POST: DCSA1302_mark1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,st_registration,subj_code,tma1,tma2,total_tma,experiment,record_book,viva,total_practical,st_center_code,submit_date,exam_term")] tbl_DCSA1302_mark1 tbl_DCSA1302_mark1)
        {
            tbl_DCSA1302_mark1.total_practical = tbl_DCSA1302_mark1.experiment + tbl_DCSA1302_mark1.record_book + tbl_DCSA1302_mark1.viva;
            tbl_DCSA1302_mark1.total_tma = tbl_DCSA1302_mark1.tma1 + tbl_DCSA1302_mark1.tma2;
            tbl_DCSA1302_mark1.submit_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.tbl_DCSA1302_mark1.Add(tbl_DCSA1302_mark1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.st_registration = new SelectList(db.tbl_student, "st_registration", "st_name", tbl_DCSA1302_mark1.st_registration);
            return View(tbl_DCSA1302_mark1);
        }

        // GET: DCSA1302_mark1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DCSA1302_mark1 tbl_DCSA1302_mark1 = db.tbl_DCSA1302_mark1.Find(id);
            if (tbl_DCSA1302_mark1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.st_registration = new SelectList(db.tbl_student, "st_registration", "st_name", tbl_DCSA1302_mark1.st_registration);
            return View(tbl_DCSA1302_mark1);
        }

        // POST: DCSA1302_mark1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,st_registration,subj_code,tma1,tma2,total_tma,experiment,record_book,viva,total_practical,st_center_code,submit_date,exam_term")] tbl_DCSA1302_mark1 tbl_DCSA1302_mark1)
        {
            tbl_DCSA1302_mark1.subj_code = "DCSA 1302";
            tbl_DCSA1302_mark1.total_practical = tbl_DCSA1302_mark1.experiment + tbl_DCSA1302_mark1.record_book + tbl_DCSA1302_mark1.viva;
            tbl_DCSA1302_mark1.total_tma = tbl_DCSA1302_mark1.tma1 + tbl_DCSA1302_mark1.tma2;
            tbl_DCSA1302_mark1.submit_date = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(tbl_DCSA1302_mark1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.st_registration = new SelectList(db.tbl_student, "st_registration", "st_name", tbl_DCSA1302_mark1.st_registration);
            return View(tbl_DCSA1302_mark1);
        }

        // GET: DCSA1302_mark1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DCSA1302_mark1 tbl_DCSA1302_mark1 = db.tbl_DCSA1302_mark1.Find(id);
            if (tbl_DCSA1302_mark1 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DCSA1302_mark1);
        }

        // POST: DCSA1302_mark1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_DCSA1302_mark1 tbl_DCSA1302_mark1 = db.tbl_DCSA1302_mark1.Find(id);
            db.tbl_DCSA1302_mark1.Remove(tbl_DCSA1302_mark1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
