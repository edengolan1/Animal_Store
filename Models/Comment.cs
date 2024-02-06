using System.ComponentModel.DataAnnotations;

namespace ProjectAspNet.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required(ErrorMessage = "Comment text is required.")]
        [StringLength(60, ErrorMessage = "Comment text must be at most 60 characters.")]
        public string? CommentText { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}
