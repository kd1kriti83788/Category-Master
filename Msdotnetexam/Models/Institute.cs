using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Msdotnetexam.Models
{
    [Table("Institute")]
    public class Institute
    {
        [Column("Code", TypeName = "varchar(10)")]
        [Key]
        public string Code { get; set; }

        [Column("Name", TypeName = "varchar(100)")]
        public string Name { get; set; }


        [Column("Pin", TypeName = "varchar(10)")]
        public string Pin { get; set; }
    }

    [Table("Courses")]
    public class Courses
    {
        [Column("Id", TypeName = "int")]
        [Key]
        public int Id { get; set; }

        [Column("Course", TypeName = "varchar(100)")]
        public string Course { get; set; }


        [Column("Fees", TypeName = "int")]
        public int StockQuantity { get; set; }



        [Column("Code", TypeName = "varchar(10)")]
        public string Code { get; set; }
    }

    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Institute> Institute { get; set; }

        public DbSet<Courses> Courses { get; set; }

    }
}
