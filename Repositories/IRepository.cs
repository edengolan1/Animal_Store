using ProjectAspNet.Models;

namespace ProjectAspNet.Repositories
{
    public interface IRepository
    {
        IEnumerable<Animal> GetTwoBiggerComment();
        IEnumerable<Category> GetAnimalsCategory();
        Animal GetDetailsAnimals(int animalId);
        void AddComment(Comment comment);
        public void EditComment(Comment comment);
        void DeleteAnimal(int animalId);
        void AddAnimal(Animal animal);
        IEnumerable<Category> GetCategories();
        public int GetCategoryIdByName(string categoryName);
        void UpDateAnimal(Animal animal);
        void CreateNewImage(Animal animal);
        string GetUniqueFileName(string fileName);
    }
}
