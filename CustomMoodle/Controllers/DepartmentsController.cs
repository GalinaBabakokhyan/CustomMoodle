using System.Threading.Tasks;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomMoodle.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentsController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.GetAllDepartments());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _departmentService.GetDepurtment((int) id));
        }
    }
}