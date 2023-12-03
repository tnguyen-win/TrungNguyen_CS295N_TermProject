using VideoGameTrading.Data;
using VideoGameTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace VideoGameTrading.Controllers {
    public class ShopController : Controller {
        readonly IRegistryRepository repository;

        public ShopController(IRegistryRepository r) => repository = r;

        // Homepage

        [HttpGet]
        public IActionResult Index() {
            var items = repository.GetItems();

            return View(items);
        }

        //[HttpPost]
        //public IActionResult Index(string title) {
        //    List<Item> items = (from m in repository.GetItems() select m).ToList();

        //    return View("Index", items);
        //}

        // Cart

        [HttpGet]
        public IActionResult Cart() {
            List<Item> items = (from m in repository.GetItems()
                                where m.InCart == true
                                select m).ToList();

            return View(items);
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
            model.ReleaseYear = 1234;
            model.AgeRange ??= "Everyone";
            model.Condition ??= "Good";
            model.From.Name ??= "John Smith";

            // Originals
            model.InCart = false;
            model.Price = Math.Round((double)(1 + (rnd.NextDouble() * (100 - 1))), 2);

            repository.StoreItem(model);

            return RedirectToAction("index", new { model.ItemId });
        }

        // Card

        //[HttpPut]
        //public IActionResult Card(Item model) {
        //    return RedirectToAction("shop");
        //}

        // Error

        public IActionResult Error() => View();
    }
}
