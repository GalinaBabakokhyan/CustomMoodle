using System.Linq;
using System.Threading.Tasks;
using CustomMoodle.Models;
using Domain.Entities;
using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomMoodle.Controllers
{
    [Authorize]
    public class InstructorsController : Controller
    {
        private readonly InstructorService _instructorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public InstructorsController(InstructorService instructorService,
            UserManager<ApplicationUser> userManager)
        {
            _instructorService = instructorService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var viewModel = new InstructorViewModel { Instructors = await _instructorService.GetAllInstructors() };
            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;
                var instructor = viewModel.Instructors.Single(i => i.InstructorId == id.Value);
                viewModel.Courses = instructor.Courses;
            }

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;
                var selectedCourse = viewModel.Courses.Single(x => x.Id == courseId);
                viewModel.Enrollments = selectedCourse.Enrollments;
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _instructorService.BuildInstructorModel((int) id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }
    }
}