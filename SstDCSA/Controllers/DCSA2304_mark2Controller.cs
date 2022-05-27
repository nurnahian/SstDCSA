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
    public class DCSA2304_mark2Controller : Controller
    {
        private DcsaContext db = new DcsaContext();

        // GET: DCSA2304_mark2
        public ActionResult Index()
        {
            var tbl_DCSA2304_mark2 = db.tbl_DCSA2304_mark2.Include(t => t.tbl_student);
            return View(tbl_DCSA2304_mark2.Where(t => t.tbl_student.st_semester2 == true).ToList());
        }

        // GET: DCSA2304_mark2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DCSA2304_mark2 tbl_DCSA2304_mark2 = db.tbl_DCSA2304_mark2.Find(id);
            if (tbl_DCSA2304_mark2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DCSA2304_mark2);
        }

        // GET: DCSA2304_mark2/Create
        public ActionResult Create()
        {
            ViewBag.st_registration = new SelectList(db.tbl_student.Where(s => s.st_semester2 == true), "st_registration", "st_registration");
            return View();
        }

        // POST: DCSA2304_mark2/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,st_registration,subj_code,tma1,tma2,total_tma,experiment,record_book,viva,total_practical,st_center_code,submit_date,exam_term")] tbl_DCSA2304_mark2 tbl_DCSA2304_mark2)
        {
            tbl_DCSA2304_mark2.total_practical = tbl_DCSA2304_mark2.experiment + tbl_DCSA2304_mark2.record_book + tbl_DCSA2304_mark2.viva;
            tbl_DCSA2304_mark2.total_tma = tbl_DCSA2304_mark2.tma1 + tbl_DCSA2304_mark2.tma2;
            tbl_DCSA2304_mark2.submit_date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.tbl_DCSA2304_mark2.Add(tbl_DCSA2304_mark2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.st_registration = new SelectList(db.tbl_student, "st_registration", "st_registration", tbl_DCSA2304_mark2.st_registration);
            return View(tbl_DCSA2304_mark2);
        }

        // GET: DCSA2304_mark2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DCSA2304_mark2 tbl_DCSA2304_mark2 = db.tbl_DCSA2304_mark2.Find(id);
            if (tbl_DCSA2304_mark2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.st_registration = new SelectList(db.tbl_student, "st_registration", "st_registration", tbl_DCSA2304_mark2.st_registration);
            return View(tbl_DCSA2304_mark2);
        }

        // POST: DCSA2304_mark2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,st_registration,subj_code,tma1,tma2,total_tma,experiment,record_book,viva,total_practical,st_center_code,submit_date,exam_term")] tbl_DCSA2304_mark2 tbl_DCSA2304_mark2)
        {
            tbl_DCSA2304_mark2.subj_code = "DCSA 2304";
            tbl_DCSA2304_mark2.total_practical = tbl_DCSA2304_mark2.experiment + tbl_DCSA2304_mark2.record_book + tbl_DCSA2304_mark2.viva;
            tbl_DCSA2304_mark2.total_tma = tbl_DCSA2304_mark2.tma1 + tbl_DCSA2304_mark2.tma2;
            tbl_DCSA2304_mark2.submit_date = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(tbl_DCSA2304_mark2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.st_registration = new SelectList(db.tbl_student, "st_registration", "st_registration", tbl_DCSA2304_mark2.st_registration);
            return View(tbl_DCSA2304_mark2);
        }

        // GET: DCSA2304_mark2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DCSA2304_mark2 tbl_DCSA2304_mark2 = db.tbl_DCSA2304_mark2.Find(id);
            if (tbl_DCSA2304_mark2 == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DCSA2304_mark2);
        }

        // POST: DCSA2304_mark2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_DCSA2304_mark2 tbl_DCSA2304_mark2 = db.tbl_DCSA2304_mark2.Find(id);
            db.tbl_DCSA2304_mark2.Remove(tbl_DCSA2304_mark2);
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
