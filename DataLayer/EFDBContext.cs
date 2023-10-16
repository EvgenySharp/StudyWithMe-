using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer(@"Server = (LocalDB)\MSSQLLocalDB;Database=StudyWithMeDB;Trusted_Connection=True;MultipleActiveResultSets=True", b => b.MigrationsAssembly("DataLayer"));
            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
