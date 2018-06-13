using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CustomMoodle.Extensions;
using CustomMoodle.Models;
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
            if (TempData["Message"] == null)
            {
                return View(await _courseService.GetAllCourses());
            }

            ViewBag.Message = TempData.Get<AlertViewModel>("Message");
            TempData.Remove("Message");

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
                    TempData.Put("Message",
                        new AlertViewModel(AlertType.Success, "Success", "You have been successfully enrolled!"));
                    return RedirectToAction("Index");
                }
                TempData.Put("Message",
                    new AlertViewModel(AlertType.Danger, "Error", "You are already enroled to this class!"));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData.Put("Message",
                    new AlertViewModel(AlertType.Danger, "Error", "Something went wrong!"));
                return RedirectToAction("Index");
            }
        }
    }
}