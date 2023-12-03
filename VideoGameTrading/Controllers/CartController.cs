using VideoGameTrading.Data;
using VideoGameTrading.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace VideoGameTrading.Controllers {
    public class CartController : Controller {
        readonly IProductRepository repository;

        public CartController(IProductRepository r) => repository = r;

        // Index

        [HttpGet]
        public IActionResult Index() {
            List<Item> items = (from m in repository.GetItems()
                                where m.InCart == true
                                select m).ToList();

            return View(items);
        }
    }
}
