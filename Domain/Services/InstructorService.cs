using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Model;
using Domain.Repositories;

namespace Domain.Services
{
    public class InstructorService
    {
        private readonly InstructorRepository _instructorRepository;
        private readonly CourseRepository _courseRepository;

        public InstructorService(InstructorRepository professorRepository, CourseRepository courseRepository)
        {
            _instructorRepository = professorRepository;
            _courseRepository = courseRepository;
        }

        public async Task<ICollection<Instructor>> GetAllInstructors()
        {
            var instructors = new List<Instructor>();
            var allInstructorUsers = await _instructorRepository.GetInstructors();
            foreach (var instructor in allInstructorUsers)
            {
                instructors.Add(await BuildInstructorModel(instructor));
            }

            return instructors;
        }

        public async Task<Instructor> BuildInstructorModel(ApplicationUser instructor)
        {
            var courses = await _courseRepository.GetCourses(instructor.Id);
            return new Instructor
            {
                FirstName = instructor.FirstName,
                SecondName = instructor.SecondName,
                LastName = instructor.LastName,
                InstructorId = instructor.Id,
                CardNumber = instructor.CardNumber,
                Courses = courses
            };
        }
        public async Task<Instructor> BuildInstructorModel(int instructorId)
        {
            var instructor = await _instructorRepository.GetInstructor(instructorId);
            if (instructor == null)
                return null;
            var courses = await _courseRepository.GetCourses(instructor.Id);
            return new Instructor
            {
                FirstName = instructor.FirstName,
                SecondName = instructor.SecondName,
                LastName = instructor.LastName,
                InstructorId = instructor.Id,                
                CardNumber = instructor.CardNumber,
                Courses = courses
            };
        }
    }
}