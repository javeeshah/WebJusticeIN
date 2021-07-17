using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebJusticeIN.Areas.Admin.Models
{
    public class Blog
    {
        [Key]
        public Guid BlogID { get; set; }

        [Required]
        public string BlogNumber { get; set; }

        [Required]
        public string BlogTitle { get; set; }

        public string BlogSummary { get; set; }

        public bool IsPublished { get; set; }

        public string AuthorName { get; set; }

        public string ImagePath { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

    }
}