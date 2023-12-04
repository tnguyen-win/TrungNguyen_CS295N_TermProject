using VideoGameTrading.Data;
using VideoGameTrading.Models;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameTrading.Controllers {
    public class ShopController : Controller {
        readonly IProductRepository repository;

        public ShopController(IProductRepository r) => repository = r;

        // Homepage

        [HttpGet]
        public IActionResult Index() {
            var items = repository.GetItems();

            return View(items);
        }

        [HttpPost]
        public IActionResult Index(string search, string genre, int releaseYearMin, int releaseYearMax, int priceMin, int priceMax, string ageRange, string condition) {
            Console.WriteLine($"\n\n\n\n{search}\n\n\n\n");

            List<Item> items = (from i in repository.GetItems() select i).ToList();

            var matchSearch = false;
            var matchGenre = false;
            var matchReleaseYear = false;
            var matchPrice = false;
            var matchAgeRange = false;
            var matchCondition = false;

            foreach (var i in repository.GetItems()) {
                if (i.Title == search) matchSearch = true;
                if (i.Genre == genre) matchGenre = true;
                if (i.ReleaseYear >= releaseYearMin & i.ReleaseYear <= releaseYearMax) matchReleaseYear = true;
                if (i.Price >= priceMin & i.Price <= priceMax) matchPrice = true;
                if (i.AgeRange == ageRange) matchAgeRange = true;
                if (i.Condition == condition) matchCondition = true;
            }

            // Search

            if (matchSearch) {
                items = (from i in repository.GetItems()
                         where i.Title == search
                         select i).ToList();
            }

            // Genre

            if (matchGenre) {
                items = (from i in repository.GetItems()
                         where i.Genre == genre
                         select i).ToList();
            }

            // Release Year

            if (matchReleaseYear) {
                items = (from i in repository.GetItems()
                         where i.ReleaseYear >= releaseYearMin & i.ReleaseYear <= releaseYearMax
                         select i).ToList();
            }

            // Price

            if (matchPrice) {
                items = (from i in repository.GetItems()
                         where i.Price >= priceMin & i.Price <= priceMax
                         select i).ToList();
            }

            // Age Range

            if (matchAgeRange) {
                items = (from i in repository.GetItems()
                         where i.AgeRange == ageRange
                         select i).ToList();
            }

            // Condition

            if (matchCondition) {
                items = (from i in repository.GetItems()
                         where i.Condition == condition
                         select i).ToList();
            }

            return View("index", items);
        }

        // Product

        public IActionResult Product() => View();

        [HttpGet("/shop/product/{id}")]
        public IActionResult Product(int id) {
            List<Item> items = (from m in repository.GetItems() select m).ToList();

            try {
                return View("product", items[id - 1]);
            } catch {
                return View("error");
            }
        }

        // Create

        public IActionResult Create() => View();


        [HttpPost]
        public IActionResult Create(Item model) {
            Random rnd = new();

            // Fallbacks
            model.Title ??= "Random title";
            model.Genre ??= "Lorem ipsum.";
            if (model.ReleaseYear == 0) model.ReleaseYear = 2023;
            if (model.Price == 0) model.Price = Math.Round((double)(1 + (rnd.NextDouble() * (100 - 1))), 2);
            model.AgeRange ??= "Everyone";
            model.Condition ??= "Good";
            model.From.Name ??= "John Smith";

            // Originals
            try {
                model.ItemId = repository.GetItems().Count + 1;
            } catch {
                // Fix for unit tests that can't access the repository method GetItems()
                model.ItemId = 0;
            }

            repository.StoreItem(model);

            return RedirectToAction("index");
        }

        // Error

        public IActionResult Error() => View();
    }
}
