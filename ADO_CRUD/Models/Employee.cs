using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ADO_CRUD.Models
{
    public class Employee
    {
        [Required]
        public string id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public float salary { get; set; }

        [Required]
        public string city { get; set; }

    }
}