using Microsoft.AspNetCore.Mvc;

namespace ElearningSystem.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
