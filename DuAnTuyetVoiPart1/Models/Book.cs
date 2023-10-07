using System.ComponentModel.DataAnnotations;

namespace DuAnTuyetVoiPart1.Models
{
    public class Book
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        public double Price { get; set; }
    }
}
