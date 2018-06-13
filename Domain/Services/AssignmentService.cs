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
    }
}