using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class InstructorRepository
    {
        private readonly CustomMoodleDbContext dbContext;

        public InstructorRepository(CustomMoodleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<ApplicationUser>> GetInstructors()
        {
            return await dbContext.Users.Include(u => u.Claims)
                .Where(u => u.Claims.Any(x => x.ClaimValue == ClaimTypes.Teacher.ToString()))
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetInstructor(int instructorId)
        {
            return await dbContext.Users.Include(u => u.Claims)
                .SingleOrDefaultAsync(u =>
                    u.Id == instructorId && u.Claims.Any(x => x.ClaimValue == ClaimTypes.Teacher.ToString()));
        }
    }
}