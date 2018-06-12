using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Model;
using Domain.Repositories;

namespace Domain.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IQueryable<ApplicationUser> GetStudentUsers() => _studentRepository.GetAllStudentsQueryable();

        public async Task<List<Student>> CreateStudentModel(IEnumerable<ApplicationUser> studentUsers)
        {
            var students = new List<Student>();
            foreach (var student in studentUsers)
            {
                students.Add(new Student
                {
                    FirstName = student.FirstName,
                    SecondName = student.SecondName,
                    LastName = student.LastName,
                    StudentId = student.Id,
                    Enrollments = await _studentRepository.GetStudentEnrollments(student.Id)
                });
            }

            return students;
        }

        public async Task<Student> GetStudentModel(int studentId)
        {
            var studentUser = await _studentRepository.GetStudentAsync(studentId);
            if (studentUser == null)
                return null;
            return new Student
            {
                FirstName = studentUser.FirstName,
                SecondName = studentUser.SecondName,
                LastName = studentUser.LastName,
                StudentId = studentUser.Id,
                Enrollments = await _studentRepository.GetStudentEnrollments(studentId)
            };
        }
    }
}