using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class StudentRepository
    {
        private readonly CustomMoodleDbContext dbContext;

        public StudentRepository(CustomMoodleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ApplicationUser>> GetAllStudentsListAsync()
        {
            return await dbContext.Users
                .Include(u => u.Claims)
                .Where(u => u.Claims.Any(c => c.ClaimValue == "Student"))
                .ToListAsync();
        }
        
        public async Task<ApplicationUser> GetStudentAsync(int studentId)
        {
            return await dbContext.Users
                .Include(u => u.Claims)
                .SingleOrDefaultAsync(u => u.Claims.Any(c => c.ClaimValue == "Student") && u.Id == studentId);
        }

        public IQueryable<ApplicationUser> GetAllStudentsQueryable() =>
            dbContext.Users;

        public async Task<ICollection<Enrollment>> GetStudentEnrollments(int studentId)
        {
            return await dbContext.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }
    }
}