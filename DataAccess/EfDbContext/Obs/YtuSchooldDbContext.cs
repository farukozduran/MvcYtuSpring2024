﻿using Entities.CommonEntities;
using Entities.ObsEntities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EfDbContext.Obs
{
    public class YtuSchooldDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-670OPH6\\PANJUTORIALSSQL;" +
                "database=YtuSchooldDb;trusted_connection=true;" +
                "MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }

        public DbSet<Course>? Courses { get; set; }
        public DbSet<Department>? Departments { get; set; }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<ExamResult>? ExamResults { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Instructor>? Instructors { get; set; }
        public DbSet<InstructorCourse>? InstructorCourses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<StudentCourse>? StudentCourses { get; set; }
        public DbSet<User>? Users { get;set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
