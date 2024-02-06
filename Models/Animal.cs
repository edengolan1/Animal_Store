
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectAspNet.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Animal Name is required.")]
        [StringLength(20, ErrorMessage = "Animal Name cannot be longer than 20 characters.")]

        public string? AnimalName { get; set; }
        [Required(ErrorMessage = "Animal Age is required.")]
        [Range(0, 30, ErrorMessage = "Age should be between 0 and 30")]
        public int Age { get; set; }
        public string? PictureName { get; set; }
        [Required(ErrorMessage = "Animal Description is required.")]
        [StringLength(80, ErrorMessage = "Description cannot be longer than 80 characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please Choose Animal Category!")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Comment>? Comment { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
        public Animal()
        {
            Comment = new List<Comment>();
        }
    }
}
