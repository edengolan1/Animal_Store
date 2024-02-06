using Microsoft.EntityFrameworkCore;
using ProjectAspNet.Data;
using ProjectAspNet.Models;

namespace ProjectAspNet.Repositories
{
    public class MyRepository : IRepository
    {
        private AnimalContext _animalContext;
        public MyRepository(AnimalContext animalContext)
        {
            _animalContext = animalContext;
        }
        public IEnumerable<Category> GetCategories()
        {
            return _animalContext.Categories!.ToList();
        }
        public int GetCategoryIdByName(string categoryName)
        {
            return _animalContext.Categories!
                .Where(c => c.CategoryName == categoryName)
                .Select(c => c.CategoryId)
                .FirstOrDefault();
        }
        public void AddAnimal(Animal animal)
        {
            CreateNewImage(animal);
            _animalContext.Add(animal);
            _animalContext.SaveChanges();
        }

        public void AddComment(Comment comment)
        {
            _animalContext.Comments!.Add(comment);
            _animalContext.SaveChanges();
        }
        public void DeleteAnimal(int animalId)
        {
            var animalToDelete = _animalContext.Animals!.Find(animalId);
            if (animalToDelete != null)
            {
                _animalContext.Animals.Remove(animalToDelete);
                _animalContext.SaveChanges();
            }
        }
        public IEnumerable<Category> GetAnimalsCategory()
        {
            var animals = _animalContext.Categories!.Include(a => a.Animals).ToList();
            return animals;
        }

        public Animal GetDetailsAnimals(int animalId)
        {
            var animal = _animalContext.Animals!.Include(a => a.Category).Include(b => b.Comment)
            .SingleOrDefault(a => a.AnimalId == animalId);
            _animalContext?.Entry(animal).Collection(a => a!.Comment!).Load();
            return animal!;
        }

        public IEnumerable<Animal> GetTwoBiggerComment()
        {
            var animals = _animalContext.Animals!.Include(a => a.Category).ToList();
            var getTwoAnimals = animals.OrderByDescending(a => a.Comment!.Count).Take(2);
            return getTwoAnimals;
        }

        public void UpDateAnimal(Animal animal)
        {
            CreateNewImage(animal);
            _animalContext.Update(animal);
            _animalContext.SaveChanges();
        }
        public void CreateNewImage(Animal animal)
        {
            if (animal.formFile != null)
            {
                var uniqueFileName = GetUniqueFileName(animal.formFile.FileName);
                var imagePath = Path.Combine("wwwroot/images", uniqueFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    animal.formFile.CopyTo(stream);
                }
                animal.PictureName = uniqueFileName;
            }
        }
        public string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                + "_"
                + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
        public void EditComment(Comment comment)
        {
            _animalContext.Comments!.Update(comment);
            _animalContext.SaveChanges();
        }
    }
}
