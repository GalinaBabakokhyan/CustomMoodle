using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class CourseRepository
    {
        private readonly CustomMoodleDbContext dbContext;

        public CourseRepository(CustomMoodleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Course> GetCourse(int courseId)
        {
            return await dbContext.Courses
                .Include(d => d.Enrollments)
                .Include(c => c.Department)
                .ThenInclude(d => d.Instructor)
                .SingleOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<ICollection<Course>> GetCourses()
        {
            return await dbContext.Courses
                .Include(d => d.Enrollments)
                .Include(c => c.Department)
                .ThenInclude(d => d.Instructor)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<Course>> GetCourses(int instructorId)
        {
            return await dbContext.Courses
                .Include(d => d.Enrollments)
                .ThenInclude(d => d.Student)
                .Include(c => c.Department)
                .ThenInclude(d => d.Instructor)
                .Where(x => x.Department.Instructor.Id == instructorId)
                .ToListAsync();
        }

        public bool IsAnyEntrollment(int studentId, int courseId)
        {
            return dbContext.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId);
        }

        public void CreateEnrollment(int studentId, int courseId)
        {
            dbContext.Enrollments.Add(new Enrollment
            {
                CourseId = courseId,
                StudentId =  studentId,
                EnrollmentDate = DateTime.Now
            });
            dbContext.SaveChanges();
        }
    }
}