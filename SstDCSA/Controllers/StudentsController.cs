using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SstDCSA.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace SstDCSA.Controllers
{
    public class StudentsController : Controller
    {
        private DcsaContext db = new DcsaContext();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.tbl_student.ToList());
        }
        [HttpPost]
        public ActionResult Up(HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;


            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Create a DataTable.
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("st_registration", typeof(string)),
                                new DataColumn("st_name", typeof(string)),
                                new DataColumn("st_admission_year",typeof(System.DateTime)),
                                new DataColumn("st_semester1",typeof(bool)),
                                new DataColumn("st_semester2",typeof(bool)),
                                new DataColumn("st_semester3",typeof(bool)),
                                new DataColumn("st_center_code",typeof(int))});


                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {

                    if (!string.IsNullOrEmpty(row))
                    {
                        dt.Rows.Add();
                        int i = 0;
                        //Execute a loop over the columns.
                        foreach (string cell in row.Split(','))
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell;
                            i++;
                        }
                    }
                }

                //manin
                string conString = ConfigurationManager.ConnectionStrings["UplodeCsvContex1"].ConnectionString;
                
                using (SqlConnection con = new SqlConnection(conString))
                {          
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        SqlBulkCopy sqlBulkCop = new SqlBulkCopy(conString, SqlBulkCopyOptions.FireTriggers);
                        //Set the database table name.                        
                        //sqlBulkCopy.DestinationTableName = "dbo.tbl_student";




                        ////[OPTIONAL]: Map the DataTable columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("st_registration", "st_registration");
                        //sqlBulkCopy.ColumnMappings.Add("st_name", "st_name");
                        //sqlBulkCopy.ColumnMappings.Add("st_admission_year", "st_admission_year");
                        //sqlBulkCopy.ColumnMappings.Add("st_semester1", "st_semester1");
                        //sqlBulkCopy.ColumnMappings.Add("st_semester2", "st_semester2");
                        //sqlBulkCopy.ColumnMappings.Add("st_semester3", "st_semester3");
                        //sqlBulkCopy.ColumnMappings.Add("st_center_code", "st_center_code");

                        sqlBulkCop.DestinationTableName = "dbo.tbl_student";




                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCop.ColumnMappings.Add("st_registration", "st_registration");
                        sqlBulkCop.ColumnMappings.Add("st_name", "st_name");
                        sqlBulkCop.ColumnMappings.Add("st_admission_year", "st_admission_year");
                        sqlBulkCop.ColumnMappings.Add("st_semester1", "st_semester1");
                        sqlBulkCop.ColumnMappings.Add("st_semester2", "st_semester2");
                        sqlBulkCop.ColumnMappings.Add("st_semester3", "st_semester3");
                        sqlBulkCop.ColumnMappings.Add("st_center_code", "st_center_code");



                        con.Open();
                        sqlBulkCop.WriteToServer(dt);                       
                        con.Close();

                    }
                }
            }
            return RedirectToAction("Index","Students");
        }
        // GET: Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_student tbl_student = db.tbl_student.Find(id);
            if (tbl_student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "st_registration,st_name,st_admission_year,st_semester1,st_semester2,st_semester3,st_center_code")] tbl_student tbl_student)
        {
            if (ModelState.IsValid)
            {
                db.tbl_student.Add(tbl_student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_student tbl_student = db.tbl_student.Find(id);
            if (tbl_student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "st_registration,st_name,st_admission_year,st_semester1,st_semester2,st_semester3,st_center_code")] tbl_student tbl_student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_student tbl_student = db.tbl_student.Find(id);
            if (tbl_student == null)
            {
                return HttpNotFound();
            }
            return View(tbl_student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_student tbl_student = db.tbl_student.Find(id);
            db.tbl_student.Remove(tbl_student);
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
