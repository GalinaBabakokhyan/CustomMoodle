using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCourses() => await _courseRepository.GetCourses();
        public async Task<Course> GetCourse(int courseId) => await _courseRepository.GetCourse(courseId);

        public bool TryToEnroll(int studentId, int courseId, out string errorMessage)
        {
            errorMessage = string.Empty;
            var isAny = _courseRepository.IsAnyEntrollment(studentId, courseId);
            if (isAny)
            {
                errorMessage = "You are already enrolled in this course";
                return false;
            }
            _courseRepository.CreateEnrollment(studentId, courseId);
            return true;
        }
    }
}