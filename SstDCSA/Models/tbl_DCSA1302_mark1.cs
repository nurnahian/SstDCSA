//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SstDCSA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_DCSA1302_mark1
    {
        public int id { get; set; }
        [Display(Name = "Student ID ")]
        public string st_registration { get; set; }
        [Display(Name = "Course Code ")]
        public string subj_code { get; set; }
        [Display(Name = "TMA 1 Mark ")]
        [Range(0, 5)]
        public Nullable<int> tma1 { get; set; }
        [Display(Name = "TMA 2 Mark ")]
        [Range(0, 5)]
        public Nullable<int> tma2 { get; set; }
        [Display(Name = "Total TMA Mark ")]
        public Nullable<int> total_tma { get; set; }
        [Display(Name = "Experiment Mark ")]
        [Range(0, 10)]
        public Nullable<int> experiment { get; set; }
        [Display(Name = "Record Book Mark ")]
        [Range(0, 5)]
        public Nullable<int> record_book { get; set; }
        [Display(Name = "Viva Mark ")]
        [Range(0, 5)]
        public Nullable<int> viva { get; set; }
        [Display(Name = "Total Practical Mark ")]
        public Nullable<int> total_practical { get; set; }
        [Display(Name = "Center Code ")]
        public Nullable<int> st_center_code { get; set; }
        [Display(Name = "Submit Date ")]
        public Nullable<System.DateTime> submit_date { get; set; }
        [Display(Name = "Exam Term ")]
        public Nullable<int> exam_term { get; set; }

        public virtual tbl_student tbl_student { get; set; }
    }
}
