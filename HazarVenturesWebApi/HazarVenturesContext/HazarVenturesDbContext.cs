using HazarVenturesWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HazarVenturesWebApi.HazarVenturesContext
{
    public class HazarVenturesDbContext :DbContext
    {
        public HazarVenturesDbContext(DbContextOptions<HazarVenturesDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Lecturer)
                .WithOne(l => l.User)
                .HasForeignKey<Lecturer>(l => l.UserId);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Student)
                .WithOne(s => s.User)
                .HasForeignKey<Student>(s => s.UserId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
