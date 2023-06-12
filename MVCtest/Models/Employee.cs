using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;
using MvcCustomValidationAttribute_Demo.CustomValidation;
namespace MVCtest.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter department name.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Please enter contact.")]
        [DataType(DataType.PhoneNumber)]
        public long  Contact { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Please enter hire date.")]
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [CustomHireDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        public DateTime HireDate { get; set; }

    }
}
