using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Assignment>> GetStudentAssignments(int studentId)
        {
            return await dbContext.Assignments
                .Include(e => e.Instructor)
                .Include(e => e.Course)
                .ThenInclude(c => c.Enrollments)
                .Where(a => a.Course.Enrollments.Any(e => e.StudentId == studentId))
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<List<Assignment>> GetInstructorAssignments(int instrctorId)
        {
            return await dbContext.Assignments
                .Include(e => e.Instructor)
                .Include(e => e.Course)
                .Where(a => a.InstructorId == instrctorId)
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<SubmitedAssignment> GetSubmitedAssignment(int id)
        {
            return await dbContext.SubmitedAssignments
                .Include(s => s.Student)
                .Include(s => s.Assignment)
                .SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<List<SubmitedAssignment>> GetSubmitedAssignments(int assignmentId)
        {
            return await dbContext.SubmitedAssignments
                .Include(s => s.Student)
                .Where(s => s.AssignmentId == assignmentId)
                .ToListAsync();
        }
        
        public async Task GradeSubmitedAssignments(int id, Grade grade)
        {
            var submitedAssignment = await dbContext.SubmitedAssignments.FindAsync(id);
            submitedAssignment.Grade = grade;
            await dbContext.SaveChangesAsync();
        }
        
        public async Task SaveSubmitedAssignments(SubmitedAssignment newSubmitedAssignment)
        {
            await dbContext.SubmitedAssignments.AddAsync(newSubmitedAssignment);
            await dbContext.SaveChangesAsync();
        }
    }
}