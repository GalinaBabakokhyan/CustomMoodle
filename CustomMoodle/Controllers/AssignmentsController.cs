using System.Threading.Tasks;
using Domain.Entities;
using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomMoodle.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly AssignmentService _assignmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AssignmentsController(AssignmentService assignmentService, UserManager<ApplicationUser> userManager)
        {
            _assignmentService = assignmentService;
            _userManager = userManager;
        }
    
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var instructorId = int.Parse(_userManager.GetUserId(User));
            return View(await _assignmentService.BuildAssignmentModel(instructorId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AssignmentCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Validation not passed!");
                return View(model);
            }

            await _assignmentService.AddAssignment(model);
            return RedirectToAction("Index");
        }
    }
}