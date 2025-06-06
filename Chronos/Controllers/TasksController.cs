using Microsoft.AspNetCore.Mvc;

namespace Chronos.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
