using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TimeKepper.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("[A-z]{2,15}", ErrorMessage = "Use letters only please.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [Required,StringLength(10, ErrorMessage = "Must be between 3 and 10 letters.", MinimumLength = 3)]
        public string Nickname { get; set; }

        [Required]
        public bool IsActive { get; set; }
     }
}