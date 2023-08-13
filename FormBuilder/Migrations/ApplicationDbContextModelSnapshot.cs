﻿// <auto-generated />
using System;
using FormBuilder.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FormBuilder.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FormBuilder.Models.AttributeSchema", b =>
                {
                    b.Property<Guid>("EntitySchemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LogicalName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("AttributeSchemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AttributeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSearchable")
                        .HasColumnType("bit");

                    b.Property<int?>("MaxLen")
                        .HasColumnType("int");

                    b.Property<int?>("MinLen")
                        .HasColumnType("int");

                    b.Property<Guid?>("OptionSetTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EntitySchemaId", "LogicalName");

                    b.HasIndex("AttributeTypeId");

                    b.HasIndex("OptionSetTypeId");

                    b.ToTable("AttributeSchemas");
                });

            modelBuilder.Entity("FormBuilder.Models.AttributeType", b =>
                {
                    b.Property<Guid>("AttributeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AttributeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SqlType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttributeTypeId");

                    b.ToTable("AttributeTypes");
                });

            modelBuilder.Entity("FormBuilder.Models.EntityFroms", b =>
                {
                    b.Property<Guid>("EntityFromsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EntityFromsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EntitySchemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FromJson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityFromsId");

                    b.HasIndex("EntitySchemaId");

                    b.ToTable("EntityFroms");
                });

            modelBuilder.Entity("FormBuilder.Models.EntitySchema", b =>
                {
                    b.Property<Guid>("EntitySchemaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityCode")
                        .HasColumnType("int");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EntitySchemaId");

                    b.HasIndex("EntityName")
                        .IsUnique();

                    b.ToTable("entitySchemas");
                });

            modelBuilder.Entity("FormBuilder.Models.OptionSetType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsGlobal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OptionSets");
                });

            modelBuilder.Entity("FormBuilder.Models.OptionSetValue", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("OptionSetTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Name", "Value", "OptionSetTypeId");

                    b.HasIndex("OptionSetTypeId");

                    b.ToTable("OptionSetValues");
                });

            modelBuilder.Entity("FormBuilder.Models.Tables.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("FormBuilder.Models.Tables.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FormBuilder.Models.AttributeSchema", b =>
                {
                    b.HasOne("FormBuilder.Models.AttributeType", "AttributeType")
                        .WithMany("AttributeSchemas")
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormBuilder.Models.EntitySchema", "EntitySchema")
                        .WithMany("AttributeSchemas")
                        .HasForeignKey("EntitySchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormBuilder.Models.OptionSetType", "OptionSetType")
                        .WithMany("AttributeSchemas")
                        .HasForeignKey("OptionSetTypeId");

                    b.Navigation("AttributeType");

                    b.Navigation("EntitySchema");

                    b.Navigation("OptionSetType");
                });

            modelBuilder.Entity("FormBuilder.Models.EntityFroms", b =>
                {
                    b.HasOne("FormBuilder.Models.EntitySchema", "EntitySchema")
                        .WithMany("EntityFroms")
                        .HasForeignKey("EntitySchemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntitySchema");
                });

            modelBuilder.Entity("FormBuilder.Models.OptionSetValue", b =>
                {
                    b.HasOne("FormBuilder.Models.OptionSetType", "OptionSetType")
                        .WithMany("OptionSetValues")
                        .HasForeignKey("OptionSetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OptionSetType");
                });

            modelBuilder.Entity("FormBuilder.Models.Tables.Employee", b =>
                {
                    b.HasOne("FormBuilder.Models.Tables.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("FormBuilder.Models.AttributeType", b =>
                {
                    b.Navigation("AttributeSchemas");
                });

            modelBuilder.Entity("FormBuilder.Models.EntitySchema", b =>
                {
                    b.Navigation("AttributeSchemas");

                    b.Navigation("EntityFroms");
                });

            modelBuilder.Entity("FormBuilder.Models.OptionSetType", b =>
                {
                    b.Navigation("AttributeSchemas");

                    b.Navigation("OptionSetValues");
                });

            modelBuilder.Entity("FormBuilder.Models.Tables.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
