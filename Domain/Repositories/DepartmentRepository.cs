using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class DepartmentRepository
    {
        private readonly CustomMoodleDbContext dbContext;

        public DepartmentRepository(CustomMoodleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Department> Get(int departmentId)
        {
            return await dbContext.Departments.Include(d => d.Instructor)
                .SingleOrDefaultAsync(d => d.Id == departmentId);
        }
        
        public async Task<ICollection<Department>> GetDepartments()
        {
            return await dbContext.Departments.Include(d => d.Instructor).ToListAsync();        
        }
    }
}