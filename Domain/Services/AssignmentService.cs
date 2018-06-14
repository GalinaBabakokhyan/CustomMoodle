using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Model;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Domain.Services
{
    public class AssignmentService
    {
        private readonly AssignmentRepository _assignmentRepository;
        private readonly CourseRepository _courseRepository;

        public AssignmentService(AssignmentRepository assignmentRepository, CourseRepository courseRepository)
        {
            _assignmentRepository = assignmentRepository;
            _courseRepository = courseRepository;
        }

        public async Task<AssignmentCreateModel> BuildAssignmentModel(int instructorId)
        {
            var courses = await _courseRepository.GetCourses(instructorId);
            
            return new AssignmentCreateModel
            {
                InstructorId = instructorId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(15),
                Courses =  courses.Select(c =>  new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Title
                }).ToList(),
            };
        }

        public async Task AddAssignment(AssignmentCreateModel assignmentCreateModel)
        {
            var assignment = new Assignment
            {
                CourseId = assignmentCreateModel.CourseId,
                InstructorId = assignmentCreateModel.InstructorId,
                StartDate = assignmentCreateModel.StartDate,
                EndDate = assignmentCreateModel.EndDate,
                Description = assignmentCreateModel.Description,
                CreationDate = DateTime.Now
            };
            await _assignmentRepository.CreateAssignment(assignment);
        }

        public async Task<IEnumerable<AssignmentGridModel>> GetAssignmentsGridInfo(int userId, ClaimTypes clientType)
        {
            List<Assignment> assignments;
            if (clientType == ClaimTypes.Student)
            {
                assignments = await _assignmentRepository.GetStudentAssignments(userId);
            }
            else
            {
                assignments = await _assignmentRepository.GetInstructorAssignments(userId);
            }
            return assignments.Select(a => new AssignmentGridModel
            {
                AssignmentId = a.Id,
                CourseTitle = a.Course.Title,
                Description = a.Description,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                InstructorName = a.Instructor.FirstName + " " + a.Instructor.LastName + " " + a.Instructor.SecondName
            }).ToList();
        }

        public async Task<SubmitedAssignment> GetSubmitedAssignment(int id) =>
            await _assignmentRepository.GetSubmitedAssignment(id);
        
        public async Task<List<SubmitedAssignment>> GetSubmitedAssignments(int assignmentId) =>
            await _assignmentRepository.GetSubmitedAssignments(assignmentId);
        
        public async Task AddSubmitedAssignmen(AssignmentSubmitModel submitModel)
        {
            
            var submitedAssignment = new SubmitedAssignment
            {
                AssignmentId = submitModel.AssignmentId,
                StudentId = submitModel.StudentId,
                FilePath = submitModel.FilePath,
                Description = submitModel.Description,
                SumbitionDate = DateTime.Now
            };
            await _assignmentRepository.SaveSubmitedAssignments(submitedAssignment);
        }

        public async Task GradeSubmitedAssignment(int id, Grade grade) =>
            await _assignmentRepository.GradeSubmitedAssignments(id, grade);
    }
}