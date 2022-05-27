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
   
    public class CenterController : Controller
    {
        private DcsaContext db = new DcsaContext();

        // GET: Center
        public ActionResult Index()
        {
            return View(db.tbl_center.ToList());
        }

        // GET: Center/Details/5'
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_center tbl_center = db.tbl_center.Find(id);
            if (tbl_center == null)
            {
                return HttpNotFound();
            }
            return View(tbl_center);
        }

        // GET: Center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Center/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "center_id,center_code,center_name")] tbl_center tbl_center)
        {
            if (ModelState.IsValid)
            {
                db.tbl_center.Add(tbl_center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_center);
        }

        // GET: Center/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_center tbl_center = db.tbl_center.Find(id);
            if (tbl_center == null)
            {
                return HttpNotFound();
            }
            return View(tbl_center);
        }

        // POST: Center/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "center_id,center_code,center_name")] tbl_center tbl_center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_center);
        }

        // GET: Center/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_center tbl_center = db.tbl_center.Find(id);
            if (tbl_center == null)
            {
                return HttpNotFound();
            }
            return View(tbl_center);
        }

        // POST: Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_center tbl_center = db.tbl_center.Find(id);
            db.tbl_center.Remove(tbl_center);
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
