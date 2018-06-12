using System;
using System.Linq;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public static class DbSeeder
    {
        public static void Initialize(CustomMoodleDbContext context)
        {
            context.Database.EnsureCreated();
            AddUsers(context);
            AddDepartments(context);
            AddCourses(context);
            AddAssignment(context);
        }

        private static void AddUsers(CustomMoodleDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

//            const string passwordHashWithSalt =
//                "AQAAAAEAACcQAAAAEHUqogecuVnLeZD02GukTWQpxV/juJGiBUNGJ+/u+QKabQrk8XH0Blo4HN55qtM1eA==";
            var users = new ApplicationUser[]
            {
                //Teachers
                new ApplicationUser
                {
                    FirstName = "Георгий",
                    SecondName = "Алексеевич",
                    LastName = "Мороз",
                    AccessFailedCount = 0,
                    CardNumber = "teacher1",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "teacher1@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "TEACHER1@MYMAIL.COM",
                    UserName = "teacher1",
                    NormalizedUserName = "TEACHER1",
                   // PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Teacher", ClaimType = "1"}}
                },
                new ApplicationUser
                {
                    FirstName = "Андрей",
                    SecondName = "Николаевич",
                    LastName = "Субочев",
                    AccessFailedCount = 0,
                    CardNumber = "teacher2",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "teacher2@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "TEACHER2@MYMAIL.COM",
                    UserName = "teacher2",
                    NormalizedUserName = "TEACHER2",
                    //PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Teacher", ClaimType = "1"}}
                },
                new ApplicationUser
                {
                    FirstName = "Алина",
                    SecondName = "Сергеевна",
                    LastName = "Бодрова",
                    AccessFailedCount = 0,
                    CardNumber = "teacher3",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "teacher3@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "TEACHER3@MYMAIL.COM",
                    UserName = "teacher3",
                    NormalizedUserName = "TEACHER3",
                    //PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Teacher", ClaimType = "1"}}
                },
                //Students
                new ApplicationUser
                {
                    FirstName = "Галина",
                    SecondName = "Арменовна",
                    LastName = "Бабакохян",
                    AccessFailedCount = 0,
                    CardNumber = "student1",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "student1@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "STUDENT1@MYMAIL.COM",
                    UserName = "student1",
                    NormalizedUserName = "STUDENT1",
                   // PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Student", ClaimType = "2"}}
                },
                new ApplicationUser
                {
                    FirstName = "Алина",
                    SecondName = "Анатольевна",
                    LastName = "Саблина",
                    AccessFailedCount = 0,
                    CardNumber = "student2",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "student2@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "STUDENT2@MYMAIL.COM",
                    UserName = "student2",
                    NormalizedUserName = "STUDENT2",
                    //PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Student", ClaimType = "2"}}
                },

                new ApplicationUser
                {
                    FirstName = "Дмитрий",
                    SecondName = "Максимович",
                    LastName = "Братчиков",
                    AccessFailedCount = 0,
                    CardNumber = "student3",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "student3@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "STUDENT3@MYMAIL.COM",
                    UserName = "student3",
                    NormalizedUserName = "STUDENT3",
                    //PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Student", ClaimType = "2"}}
                },
                new ApplicationUser
                {
                    FirstName = "Полина",
                    SecondName = "Сергеевна",
                    LastName = "Барбарисова",
                    AccessFailedCount = 0,
                    CardNumber = "student4",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "student4@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "STUDENT4@MYMAIL.COM",
                    UserName = "student4",
                    NormalizedUserName = "STUDENT4",
                   // PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Student", ClaimType = "2"}}
                },
                new ApplicationUser
                {
                    FirstName = "Виктор",
                    SecondName = "Дмитриевич",
                    LastName = "Сутямов",
                    AccessFailedCount = 0,
                    CardNumber = "student5",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "student5@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "STUDENT5@MYMAIL.COM",
                    UserName = "student5",
                    NormalizedUserName = "STUDENT5",
                   // PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Student", ClaimType = "2"}}
                },
                new ApplicationUser
                {
                    FirstName = "Анастасия",
                    SecondName = "Валерьевна",
                    LastName = "Золотухина",
                    AccessFailedCount = 0,
                    CardNumber = "student6",
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    Email = "student6@mymail.com",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    LockoutEnd = null,
                    NormalizedEmail = "STUDENT6@MYMAIL.COM",
                    UserName = "student6",
                    NormalizedUserName = "STUDENT6",
                    //PasswordHash = passwordHashWithSalt,
                    PhoneNumber = null,
                    PhoneNumberConfirmed = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Claims = {new IdentityUserClaim<int> {ClaimValue = "Student", ClaimType = "2"}}
                },
            };
            foreach (var user in users)
            {
                user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, "zaq1@WSX");
            }
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void AddDepartments(CustomMoodleDbContext context)
        {
            if (context.Departments.Any())
                return;
            var departments = new[]
            {
                new Department
                {
                    Name = "Лингвистика",
                    InstructorId = context.Users.Single(u => u.CardNumber == "teacher1").Id,
                    StartDate = DateTime.Parse("2018-01-15")
                },
                new Department
                {
                    Name = "Бизнес-информатика",
                    InstructorId = context.Users.Single(u => u.CardNumber == "teacher2").Id,
                    StartDate = DateTime.Parse("2018-01-15")
                },
                new Department
                {
                    Name = "Филология",
                    InstructorId = context.Users.Single(u => u.CardNumber == "teacher3").Id,
                    StartDate = DateTime.Parse("2018-01-15")
                }
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
        }

        private static void AddCourses(CustomMoodleDbContext context)
        {
            if (context.Courses.Any())
                return;
            var departments = context.Departments.ToList();
            var courses = new Course[]
            {
                new Course
                {
                    Title = "Древнерусская литература",
                    Credits = 2,
                    DepartmentId = departments.Single(s => s.Name == "Лингвистика").Id
                },
                new Course
                {
                    Title = "Испанский язык",
                    Credits = 3,
                    DepartmentId = departments.Single(s => s.Name == "Лингвистика").Id
                },
                new Course
                {
                    Title = "Диахроническая лингвистика",
                    Credits = 4,
                    DepartmentId = departments.Single(s => s.Name == "Лингвистика").Id
                },
                new Course
                {
                    Title = "Анализ данных для лингвистов",
                    Credits = 2,
                    DepartmentId = departments.Single(s => s.Name == "Лингвистика").Id
                },
                new Course
                {
                    Title = "Программирование",
                    Credits = 5,
                    DepartmentId = departments.Single(s => s.Name == "Бизнес-информатика").Id
                },
                new Course
                {
                    Title = "Дискретная математика",
                    Credits = 4,
                    DepartmentId = departments.Single(s => s.Name == "Бизнес-информатика").Id
                },
                new Course
                {
                    Title = "Анализ и совершенствование бизнес-процессов",
                    Credits = 2,
                    DepartmentId = departments.Single(s => s.Name == "Бизнес-информатика").Id
                },
                new Course
                {
                    Title = "Институциональная экономика",
                    Credits = 3,
                    DepartmentId = departments.Single(s => s.Name == "Бизнес-информатика").Id
                },
                new Course
                {
                    Title = "Латинский язык",
                    Credits = 2,
                    DepartmentId = departments.Single(s => s.Name == "Филология").Id
                },
                new Course
                {
                    Title = "Палеография",
                    Credits = 5,
                    DepartmentId = departments.Single(s => s.Name == "Филология").Id
                },
                new Course
                {
                    Title = "Правила чтения: Русская поэзия",
                    Credits = 1,
                    DepartmentId = departments.Single(s => s.Name == "Филология").Id
                },
                new Course
                {
                    Title = "Техника биографических разысканий",
                    Credits = 2,
                    DepartmentId = departments.Single(s => s.Name == "Филология").Id
                }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }

        private static void AddAssignment(CustomMoodleDbContext context)
        {
            if (context.Assignments.Any())
                return;
            var courses = context.Courses.ToList();
            var teachers = context.Users
                .Include(u => u.Claims)
                .Where(u => u.Claims.Any(c => c.ClaimType == "1"))
                .ToList();
            var assignments = new[]
            {
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Древнерусская литература").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-03-18"),
                    EndDate = DateTime.Parse("2018-03-25"),
                    Description = "Изучить Локальные летописные своды",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Древнерусская литература").Id,
                    CreationDate = DateTime.Parse("2018-04-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-04-25"),
                    Description = "Повесть временных лет как основа региональных летописных традиций",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Древнерусская литература").Id,
                    CreationDate = DateTime.Parse("2018-05-15"),
                    StartDate = DateTime.Parse("2018-05-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "«Слово о полку Игореве», его значение",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Испанский язык").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-03-18"),
                    EndDate = DateTime.Parse("2018-03-25"),
                    Description = "ДействительныйH залог",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Испанский язык").Id,
                    CreationDate = DateTime.Parse("2018-04-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-04-25"),
                    Description = "ДействительныйH залог",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Испанский язык").Id,
                    CreationDate = DateTime.Parse("2018-05-15"),
                    StartDate = DateTime.Parse("2018-05-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "ДействительныйH залог",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Диахроническая лингвистика").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-03-18"),
                    EndDate = DateTime.Parse("2018-03-25"),
                    Description = "Семантические изменения",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Диахроническая лингвистика").Id,
                    CreationDate = DateTime.Parse("2018-04-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Фонетические изменения",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Диахроническая лингвистика").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Неполнота лингвистической реконструкции",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Анализ данных для лингвистов").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-03-18"),
                    EndDate = DateTime.Parse("2018-03-25"),
                    Description = "Изучить Ридж- и лассо-регрессию",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Анализ данных для лингвистов").Id,
                    CreationDate = DateTime.Parse("2018-04-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Байесовская проверка гипотез",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher1").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Программирование").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Relational model basics",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Программирование").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-03-18"),
                    EndDate = DateTime.Parse("2018-03-25"),
                    Description = "Communicating with databases",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Программирование").Id,
                    CreationDate = DateTime.Parse("2018-04-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Developing a demo application using code-first approach",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Дискретная математика").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Освоить Бинарные отношения и их свойства",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Дискретная математика").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-03-18"),
                    EndDate = DateTime.Parse("2018-03-25"),
                    Description = "ЛинейныйH порядок и частичный порядок",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Дискретная математика").Id,
                    CreationDate = DateTime.Parse("2018-04-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Изучить Способы задания логических функций",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Анализ и совершенствование бизнес-процессов").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Эталонные и референтные модели",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Анализ и совершенствование бизнес-процессов").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Совершенствование процессов",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher2").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Латинский язык").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Латинские существительные. III склонение",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher3").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Латинский язык").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Винительный и родительный падежи",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher3").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Палеография").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Глаголица и кириллица",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher3").Id
                },
                new Assignment
                {
                    CourseId = courses.Single(c => c.Title == "Палеография").Id,
                    CreationDate = DateTime.Parse("2018-03-15"),
                    StartDate = DateTime.Parse("2018-04-18"),
                    EndDate = DateTime.Parse("2018-05-25"),
                    Description = "Славянская и русская палеография",
                    InstructorId = teachers.Single(i => i.CardNumber == "teacher3").Id
                }
            };
            context.Assignments.AddRange(assignments);
            context.SaveChanges();
        }
    }
}