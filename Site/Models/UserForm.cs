using System;
using System.ComponentModel.DataAnnotations;
using Site.Helpers;

namespace Site.Models
{
    public class UserForm
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        [MinAge(MinAge = 18, ErrorMessage = "Min age is 18")]
        public string DateOfBirth { get; set; }

        [Display(Name = "Publishe Date")]
        [Required(ErrorMessage = "Published date is required")]
        [DateRange(ErrorMessage = "Invalid published date")]
        public string PublishedDate { get; set; }
    }
}