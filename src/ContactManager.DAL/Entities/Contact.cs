using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace ContactManager.DAL.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        [StringLength(256, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DateTime DateOfBirth { get; set; }
        
        [Required]
        public bool Married { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"((\+38)?\(?\d{3}\)?[\s\.-]?(\d{7}|\d{3}[\s\.-]\d{2}[\s\.-]\d{2}|\d{3}-\d{4}))", ErrorMessage = "Not a valid phone number")]
        [Required]
        public string Phone { get; set; }
        
        [Required]
        public decimal Salary { get; set; }
    }
}
