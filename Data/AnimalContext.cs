using Microsoft.EntityFrameworkCore;
using ProjectAspNet.Models;

namespace ProjectAspNet.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options)
        {
        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, CategoryName = "Dogs" },
                new { CategoryId = 2, CategoryName = "Cats" },
                new { CategoryId = 3, CategoryName = "Birds" },
                new { CategoryId = 4, CategoryName = "Fished" },
                new { CategoryId = 5, CategoryName = "Reptiles" }
                );
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, AnimalName = "Border Collie", Age = 11, PictureName = "dogbordercollie.jpg", Description = "its the smartest dog in the world", CategoryId = 1 },
                new { AnimalId = 2, AnimalName = "German Shepherd", Age = 1, PictureName = "DogGermanShepherd.jpg", Description = "its a big dog", CategoryId = 1 },
                new { AnimalId = 3, AnimalName = "Siamese", Age = 3, PictureName = "CatSiamese.jpg", Description = "its a friendly cat", CategoryId = 2 },
                new { AnimalId = 4, AnimalName = "Regdol", Age = 5, PictureName = "CatRegdol.jpg", Description = "the regdol cat is very calm", CategoryId = 2 },
                new { AnimalId = 5, AnimalName = "Parrot", Age = 10, PictureName = "parrot.jpg", Description = "parrot its very smart bird that can even learn how to talk like a person", CategoryId = 3 },
                new { AnimalId = 6, AnimalName = "Eagle", Age = 6, PictureName = "BirdEagle.jpg", Description = "eagles are large , power full birds with heavy heads and beaks", CategoryId = 3 },
                new { AnimalId = 7, AnimalName = "Shark", Age = 7, PictureName = "Shark.jpg", Description = "sharkes are the biggest fish", CategoryId = 4 },
                new { AnimalId = 8, AnimalName = "Gold Fish", Age = 4, PictureName = "GoldFish.jpg", Description = "its a fish that is raised at home has a pet ", CategoryId = 4 },
                new { AnimalId = 9, AnimalName = "Ant", Age = 5, PictureName = "ReptileAnt.jpg", Description = "its reptile that can befound anywhere", CategoryId = 5 },
                new { AnimalId = 10, AnimalName = "Snake", Age = 12, PictureName = "RepliteSnake.jpg", Description = "its an animal that can be dangerous to humans and bite", CategoryId = 5 }
                );
            modelBuilder.Entity<Comment>().HasData(
                new { CommentId = 2, CommentText = "its a Smart dog!", AnimalId = 1 },
                new { CommentId = 3, CommentText = "its a very cute", AnimalId = 2 },
                new { CommentId = 4, CommentText = "its a small cat", AnimalId = 3 },
                new { CommentId = 5, CommentText = "its a blue eyes", AnimalId = 4 },
                new { CommentId = 6, CommentText = "its can fly", AnimalId = 5 },
                new { CommentId = 7, CommentText = "its scary", AnimalId = 6 },
                new { CommentId = 8, CommentText = "he has a big mouth", AnimalId = 7 },
                new { CommentId = 9, CommentText = "it has a beatiful color", AnimalId = 8 },
                new { CommentId = 10, CommentText = "he is very small", AnimalId = 9 },
                new { CommentId = 11, CommentText = "he is very small", AnimalId = 9 },
                new { CommentId = 12, CommentText = "he is very long", AnimalId = 10 },
                new { CommentId = 13, CommentText = "its can fly", AnimalId = 6 },
                new { CommentId = 14, CommentText = "its a beautiful Parrot", AnimalId = 5 }
                );
        }
    }
}
