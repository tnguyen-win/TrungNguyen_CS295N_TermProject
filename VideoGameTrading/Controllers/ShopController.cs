using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameTrading.Models;

namespace VideoGameTrading.Controllers {
    public class ShopController : Controller {
        public IActionResult Index() => View();

        public IActionResult Product() => View();

        public IActionResult Cart() => View();
    }
}
