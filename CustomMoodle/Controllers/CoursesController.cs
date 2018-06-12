using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ClaimTypes = Domain.Model.ClaimTypes;

namespace CustomMoodle.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly CourseService _courseService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoursesController(CourseService courseService, UserManager<ApplicationUser> userManager)
        {
            _courseService = courseService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAllCourses());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourse((int) id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public IActionResult Enroll(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var studentId = int.Parse(_userManager.GetUserId(User));
                if (_courseService.TryToEnroll(studentId, (int) id, out var errorMessage))
                {
                    ViewData["SuccessMessage"] = "You have been successfully enrolled!";
                    return RedirectToAction("Index");
                }

                ViewData["ErrorMessage"] = "You are already enroled to this class!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}