using Microsoft.AspNetCore.Mvc;
using ProjectAspNet.Models;
using ProjectAspNet.Repositories;

namespace ProjectAspNet.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository _myRepository;
        public AnimalController(IRepository myRepository)
        {
            _myRepository = myRepository;
        }
        public IActionResult Index()
        {
            return View(_myRepository.GetTwoBiggerComment());
        }
        public IActionResult Category()
        {
            return View(_myRepository.GetAnimalsCategory());
        }
        public IActionResult DetailsAnimal(int animalId)
        {
            return View(_myRepository.GetDetailsAnimals(animalId));
        }
        [HttpPost]
        public IActionResult AddComment(int animalId, Comment newComment)
        {
            if (ModelState.IsValid)
            {
                newComment.AnimalId = animalId;
                _myRepository.AddComment(newComment);
                return RedirectToAction("DetailsAnimal", new { animalId = animalId });
            }
            return RedirectToAction("DetailsAnimal", new { animalId = animalId });
        }
        public IActionResult Admin()
        {
            return View(_myRepository.GetAnimalsCategory());
        }
        [HttpPost]
        public IActionResult DeleteAnimal(int animalId)
        {
            _myRepository.DeleteAnimal(animalId);
            return RedirectToAction("Admin");
        }
        [HttpGet]
        public IActionResult NewAnimal()
        {
            ViewBag.Categories = _myRepository.GetCategories();
            return View(new Animal());
        }
        [HttpPost]
        public IActionResult AddAnimal(Animal animal)
        {
            if (ModelState.IsValid)
            {
                foreach (var comment in animal.Comment!)
                {
                    _myRepository.AddComment(comment);
                }
                _myRepository.AddAnimal(animal);
                return RedirectToAction("DetailsAnimal", new { animalId = animal.AnimalId });
            }
            ViewBag.Categories = _myRepository.GetCategories();
            return View("NewAnimal");
        }
        public IActionResult EditAnimal(int animalId)
        {
            var animal = _myRepository.GetDetailsAnimals(animalId);
            ViewBag.Categories = _myRepository.GetCategories();
            return View(animal);
        }
        [HttpPost]
        public IActionResult UpDate(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.Comment != null)
                {
                    foreach (var comment in animal.Comment)
                    {
                        Console.WriteLine($"Number of comments: {animal.Comment.Count} ");
                        _myRepository.EditComment(comment);
                    }
                }
                _myRepository.UpDateAnimal(animal);
                return RedirectToAction("DetailsAnimal", new { animalId = animal.AnimalId });
            }
            ViewBag.Categories = _myRepository.GetCategories();
            return View("EditAnimal", animal);
        }
    }
}
