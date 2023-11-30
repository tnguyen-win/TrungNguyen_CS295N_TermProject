using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoGameTrading.Models;

namespace VideoGameTrading.Controllers {
    public class ShopController : Controller {
        public IActionResult Index() => View();
    }
}
