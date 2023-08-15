using FormBuilder.Controllers.Api;
using FormBuilder.Models.Tables;
using FormBuilder.ViewModels.EntityForm;
using Microsoft.EntityFrameworkCore;
using FormBuilder.Models;

namespace FormBuilder.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EntitySchema> entitySchemas { get; set; }

        public DbSet<AttributeSchema> AttributeSchemas { get; set; }

        public DbSet<EntityFroms> EntityFroms { get; set; }

        public DbSet<AttributeType> AttributeTypes { get; set; }

        public DbSet<OptionSetType> OptionSets { get; set; }    
        public DbSet<OptionSetValue> OptionSetValues { get; set; }

       


        // tables entities
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<EntityView> EntityViews { get; set; }

        public DbSet<Lookup> Lookups { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region entity schema
            modelBuilder.Entity<EntitySchema>().HasKey(entitySchema => entitySchema.EntitySchemaId);
            modelBuilder.Entity<EntitySchema>().Property(entitySchema => entitySchema.EntityName).IsRequired();
            modelBuilder.Entity<EntitySchema>().Property(entitySchema => entitySchema.DisplayName).IsRequired();

            modelBuilder.Entity<EntitySchema>().HasIndex(entitySchema => entitySchema.EntityName).IsUnique();

            modelBuilder.Entity<EntitySchema>().HasMany(entitySchema => entitySchema.AttributeSchemas)
                .WithOne(attributeSchema => attributeSchema.EntitySchema)
                .HasForeignKey(attributeSchema => attributeSchema.EntitySchemaId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<EntitySchema>().HasMany(entitySchemas => entitySchemas.EntityFroms)
                .WithOne(entityForm => entityForm.EntitySchema)
                .HasForeignKey(entityForm => entityForm.EntitySchemaId);
            #endregion


            #region attribute schema

            modelBuilder.Entity<AttributeSchema>()
                .HasKey(attributeSchema => new {attributeSchema.EntitySchemaId, attributeSchema.LogicalName});

            modelBuilder.Entity<AttributeSchema>().Property(attributeShcema => attributeShcema.DisplayName).IsRequired();
            modelBuilder.Entity<AttributeSchema>().Property(attributeShcema => attributeShcema.LogicalName).IsRequired();
            modelBuilder.Entity<AttributeSchema>().Property(attributeShcema => attributeShcema.AttributeSchemaId).IsRequired();
            modelBuilder.Entity<AttributeSchema>().Property(attributeShcema => attributeShcema.AttributeTypeId).IsRequired();
            modelBuilder.Entity<AttributeSchema>().Property(attributeShcema => attributeShcema.EntitySchemaId).IsRequired();


            #endregion

            #region attriubte type

            modelBuilder.Entity<AttributeType>().HasKey(attriubteType => attriubteType.AttributeTypeId);
            modelBuilder.Entity<AttributeType>().Property(attributeType => attributeType.SqlType).IsRequired();
            modelBuilder.Entity<AttributeType>().Property(attributeType => attributeType.AttributeName).IsRequired();

            modelBuilder.Entity<AttributeType>().HasMany(attributeType => attributeType.AttributeSchemas)
             .WithOne(attributeSchema => attributeSchema.AttributeType)
             .HasForeignKey(attributeSchema => attributeSchema.AttributeTypeId);



            #endregion


            #region entity form
            modelBuilder.Entity<EntityFroms>().HasKey(entityForm => entityForm.EntityFromsId);
            modelBuilder.Entity<EntityFroms>().Property(entityForm => entityForm.EntityFromsName).IsRequired();
            modelBuilder.Entity<EntityFroms>().Property(entityForm => entityForm.FromJson).IsRequired();


            #endregion


            #region option set
            modelBuilder.Entity<OptionSetType>().HasKey(optionSet => optionSet.Id);
            modelBuilder.Entity<OptionSetType>().Property(optionSet => optionSet.Name).IsRequired();
            modelBuilder.Entity<OptionSetType>().Property(optionSet => optionSet.IsGlobal).HasDefaultValue(true);


            modelBuilder.Entity<OptionSetType>().HasMany(optionSet => optionSet.OptionSetValues)
                .WithOne(optionSetValue => optionSetValue.OptionSetType)
                .HasForeignKey(optionSetValue => optionSetValue.OptionSetTypeId);

            modelBuilder.Entity<OptionSetType>().HasMany(optionSet => optionSet.AttributeSchemas)
               .WithOne(attriubeSchema => attriubeSchema.OptionSetType)
               .HasForeignKey(attriubeSchema => attriubeSchema.OptionSetTypeId);

            #endregion


            #region option set value 

            modelBuilder.Entity<OptionSetValue>().HasKey(optionSetValue => new {optionSetValue.Name, optionSetValue.Value, optionSetValue.OptionSetTypeId});
            modelBuilder.Entity<OptionSetValue>().Property(optionSetValue => optionSetValue.Name).IsRequired();
            modelBuilder.Entity<OptionSetValue>().Property(optionSetValue => optionSetValue.Value).IsRequired();

            #endregion



        }





    }
}
