using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_4.DataAccess;

namespace EFDataAccessLibrary.Migrations
{
    [DbContext(typeof(Context)), Migration("AddedValidation")]
    internal class AddedValidationBase
    {
        public  void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDataAccessLibrary.Models.Department", b =>
            {
                b.Property<int>("DepartmentId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("DepartmentName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(50)");

            });

            modelBuilder.Entity("EFDataAccessLibrary.Models.Employee", b =>
            {
                b.Property<int>("EmployeeId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("EmployeeName")
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar(200)");

                b.Property<int?>("Department")
                    .HasColumnType("string");

        
            });

            
#pragma warning restore 612, 618
        }
    }

    [DbContext(typeof(Context))]
    [Migration("20220810052352_AddedValidation")]
    partial class AddedValidation : AddedValidationBase
    {
    }
}
