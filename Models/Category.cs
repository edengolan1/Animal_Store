namespace ProjectAspNet.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public virtual ICollection<Animal>? Animals { get; set; }
    }
}
