using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebJusticeIN.Areas.Admin.Models
{
    public class News
    {
        [Key]
        public Guid NewsID { get; set; }

        [Required(ErrorMessage ="News Number is mandatory")]
        public string NewsNumber { get; set; }

        public string NewsTitle { get; set; }

        public string NewsDesc { get; set; }

        public bool IsPublished { get; set; }

        public string AuthorName { get; set; }

        public string CreatedBy { get; set; }

        public string ImagePath { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool Active { get; set; }
    }
}