using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomMoodle.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}