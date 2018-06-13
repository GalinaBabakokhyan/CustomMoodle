using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;

namespace Domain.Repositories
{
    public class AssignmentRepository
    {
        private readonly CustomMoodleDbContext dbContext;

        public AssignmentRepository(CustomMoodleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAssignment(Assignment newAssignment)
        {
            await dbContext.Assignments.AddAsync(newAssignment);
            await dbContext.SaveChangesAsync();
        }
    }
}