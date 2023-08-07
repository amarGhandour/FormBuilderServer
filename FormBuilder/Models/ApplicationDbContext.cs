using FormBuilder.Models.Tables;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EntitySchema> entitySchemas { get; set; }

        public DbSet<AttributeSchema> AttributeSchemas { get; set; }

        public DbSet<EntityFroms> EntityFroms { get; set; }

        public DbSet<AttributeType> AttributeTypes { get; set; }


        // tables entities
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
