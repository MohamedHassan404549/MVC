using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;


namespace MVCBIG.Models
{
    public class CampanyContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.; Initial Catalog=BIG_COMPANY; Integrated Security=True; Encrypt=False;");

        }
        public virtual DbSet<Employee>? Employees { get; set; }
        public virtual DbSet<Department>? Departments { get; set; }
        public virtual DbSet<Dept_Loc>? Dept_Locs { get; set; }
        public virtual DbSet<Depandent>? Depandents { get; set; }
        public virtual DbSet<Project>? Projects { get; set; }
        public virtual DbSet<Works_ON>? Works_ONs { get; set; }
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depandent>()
                .HasKey(d => new { d.ESSN, d.DEPENDENTNAME }); // Composite primary key

            modelBuilder.Entity<Dept_Loc>()
                .HasKey(dl => new { dl.Dnumber, dl.Location }); // Composite primary key




            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department) // Define the relationship with Department
                .WithMany(d => d.Employees) // Define the inverse navigation property in Department
                .HasForeignKey(e => e.Dnumber) // Use the foreign key property Dnumber in Employee
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading delete

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Works_ON>()
                .HasKey(w => new { w.ESSN, w.PNO }); // Composite primary key

            modelBuilder.Entity<Works_ON>()
                .HasOne(w => w.Employee)
                .WithMany(e => e.Works_ON)
                .HasForeignKey(w => w.ESSN);

            modelBuilder.Entity<Works_ON>()
                .HasOne(w => w.Project)
                .WithMany(p => p.Works_ON)
                .HasForeignKey(w => w.PNO);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dept_Loc>()
                 .HasKey(dl => new { dl.Dnumber, dl.Location });

            modelBuilder.Entity<Dept_Loc>()
                .HasOne(dl => dl.Department)
                .WithMany(d => d.Locations) // Assuming that 'Locations' is the navigation property in the 'Department' entity
                .HasForeignKey(dl => dl.Dnumber);






        }
       
        

    }
}