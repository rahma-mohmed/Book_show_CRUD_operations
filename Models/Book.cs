using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace TaskIT.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Book Title: ")]
        [Required(ErrorMessage ="Book Title is required")]
        public string Title { get; set; }
        [Display(Name = "Book Description: ")]
        public string Description { get; set; }
        [Display(Name = "Book Author: ")]
        public string Author { get; set; }
        [Required(ErrorMessage ="Book Image is required")]
        [RegularExpression(@"\w+\.(jpg|png)" , ErrorMessage ="Image extention must be .jpg or .png")]
        [DisplayName("Book Image: ")]
        public string Image { get; set; }
        [DisplayName("Book Url: ")]
        public string BookUrl { get; set; }
    }
}
