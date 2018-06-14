using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CustomMoodle.Controllers
{
    [Authorize]
    public class AssignmentsController : Controller
    {
        private readonly AssignmentService _assignmentService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public AssignmentsController(AssignmentService assignmentService,
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment)
        {
            _assignmentService = assignmentService;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(_userManager.GetUserId(User));
            var isStudent = User.Claims.Any(u => u.Value == ClaimTypes.Student.ToString());
            return View(await _assignmentService.GetAssignmentsGridInfo(userId,
                isStudent ? ClaimTypes.Student : ClaimTypes.Teacher));
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

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var isStudent = User.Claims.Any(u => u.Value == ClaimTypes.Student.ToString());
            return RedirectToAction(isStudent ? "AssignmentSubmit" : "SubmitedAssignments", new {id = (int)id});
        }

        [HttpGet]
        public IActionResult AssignmentSubmit(int id)
        {
            return View(new AssignmentSubmitModel
            {
                AssignmentId = id
            });
        }

        [HttpPost]
        public async Task<IActionResult> AssignmentSubmit(AssignmentSubmitModel submitModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Validation not passed");
                return View(submitModel);
            }

            if (submitModel.AssignmentFile.ContentType != "application/zip"
                && submitModel.AssignmentFile.ContentType != "application/x-zip-compressed")
            {
                ModelState.AddModelError("", "Please upload zip file");
                return View(submitModel);
            }

            var studentId = int.Parse(_userManager.GetUserId(User));
            submitModel.StudentId = studentId;
            string assignmentFilePath =
                Path.Combine(_hostingEnvironment.WebRootPath, "Assignment_" + submitModel.AssignmentId);
            Directory.CreateDirectory(assignmentFilePath);
            string fileName = Path.Combine(assignmentFilePath, $"{studentId}.zip");
            if (System.IO.File.Exists(fileName))
            {
                ModelState.AddModelError("", "You have already submited your homework for this assignment");
                return View(submitModel);
            }

            HelperFunctions.FileHelpers.SaveToPhysicalLocation(submitModel.AssignmentFile, fileName);
            submitModel.FilePath = fileName;
            submitModel.AssignmentFile = null;
            await _assignmentService.AddSubmitedAssignmen(submitModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SubmitedAssignments(int id)
        {
            return View(await _assignmentService.GetSubmitedAssignments(id));
        }

        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submition = await _assignmentService.GetSubmitedAssignment((int)id);
            var file_type = "application/zip";
            // Имя файла - необязательно
            var fileName = $"{submition.Student.FirstName}-{submition.AssignmentId}.zip";
            return PhysicalFile(submition.FilePath, file_type, fileName);
        }
        public async Task<IActionResult> Grade(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Not yet implemented :( we had no time
            await _assignmentService.GradeSubmitedAssignment((int)id, Domain.Model.Grade.A);
            return RedirectToAction("Index");
        }
    }
}