using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebJusticeIN.Areas.Admin.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "User Name is mandatory")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "User Email is mandatory")]
        [EmailAddress(ErrorMessage = "Please provide the valid email address")]
        public string UserEmail { get; set; }


        public bool IsAdmin { get; set; }

        [Required(ErrorMessage = "Password is mandatory")]
        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}