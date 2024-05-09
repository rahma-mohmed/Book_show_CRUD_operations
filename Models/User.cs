using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace TaskIT.Models
{
    public class User 
    {
         public int Id { get; set; }

         [Required(ErrorMessage ="Name is required")]
         [Display(Name = "User Name:")]
         public string Name { get; set; }

         [Required(ErrorMessage = "Password is required")]
         [DataType(DataType.Password)]
         [Display(Name = "Password:")]
         public string Password { get; set; }


         [Display(Name = "RePassword")]
         [Required(ErrorMessage = "this failed is required")]
         [DataType(DataType.Password)]
         [Compare("Password", ErrorMessage ="Confirm password doesn't match, try again")]
         public string RePassword { get; set; }

         [Required(ErrorMessage = "Email is required")]
         //[EmailAddress]
         [RegularExpression(@"\w+\@gmail.com", ErrorMessage = "invalid email, must contain @")]
         [Display(Name = "Email:")]
         public string Email { get; set; }
    }
}

