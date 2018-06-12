using System.Linq;
using System.Threading.Tasks;
using CustomMoodle.Models;
using Domain.Entities;
using Domain.Model;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomMoodle.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly StudentService _studentService;
        private const int PageSize = 3;
        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["FirstNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "first_name_desc" : "first_name";
            ViewData["SecondNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "second_name_desc" : "second_name";
            ViewData["LastNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "last_name";

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            var students = _studentService.GetStudentUsers();
            if (!string.IsNullOrEmpty(searchString))
                students = students.Where(s => s.LastName.Contains(searchString)
                                               || s.FirstName.Contains(searchString)
                                               || s.SecondName.Contains(searchString));
            switch (sortOrder)
            {
                case "first_name_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "second_name_desc":
                    students = students.OrderByDescending(s => s.SecondName);
                    break;
                case "last_name_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "first_name":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "second_name":
                    students = students.OrderBy(s => s.SecondName);
                    break;
                case "last_name":
                    students = students.OrderBy(s => s.LastName);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }

            var totalCount = students.Count();
            var filteredStudentUsers = await PagedList<ApplicationUser>.InstallPaging(students, page ?? 1, PageSize);
            var studentModels = await _studentService.CreateStudentModel(filteredStudentUsers);
            
            return View(PagedList<Student>.Create(studentModels, totalCount, page ?? 1, PageSize));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var student = await _studentService.GetStudentModel((int)id);

            if (student == null) return NotFound();

            return View(student);
        }
    }
}