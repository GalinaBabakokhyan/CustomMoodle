using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
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
                .Include(c => c.Department)
                .ThenInclude(d => d.Instructor)
                .Where(x => x.Department.Instructor.Id == instructorId)
                .ToListAsync();
        }

    }
}