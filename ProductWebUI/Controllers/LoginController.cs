using Microsoft.AspNetCore.Mvc;

namespace ProductWebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
