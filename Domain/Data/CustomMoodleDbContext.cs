using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public class CustomMoodleDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public CustomMoodleDbContext(DbContextOptions options)
            : base(options)
        {}
        
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<SubmitedAssignment>  SubmitedAssignments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Assignment>().ToTable("Assignment");
            modelBuilder.Entity<SubmitedAssignment>().ToTable("SubmitedAssignment");
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Instructor)
                .WithMany()
                .HasForeignKey(m => m.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<Enrollment>()
                .HasOne(a => a.Student)
                .WithMany()
                .HasForeignKey(m => m.StudentId)
                .OnDelete(DeleteBehavior.Restrict); 
            modelBuilder.Entity<SubmitedAssignment>()
                .HasOne(s => s.Assignment)
                .WithMany(s => s.SubmitedAssignments)
                .HasForeignKey(s => s.AssignmentId);
            modelBuilder.Entity<SubmitedAssignment>()
                .HasOne(s => s.Student)
                .WithMany()
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict); 
            
           
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Roles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<IdentityUserClaim<int>>(entity => { entity.ToTable("UserClaims"); });
            modelBuilder.Entity<IdentityUserRole<int>>(entity => { entity.ToTable("UserRoles"); });
            modelBuilder.Entity<IdentityUserLogin<int>>(entity => { entity.ToTable("UserLogins"); });
            modelBuilder.Entity<IdentityRoleClaim<int>>(entity => { entity.ToTable("RoleClaims"); });
            modelBuilder.Entity<IdentityUserToken<int>>(entity => { entity.ToTable("UserTokens"); });
        }
    }
}
