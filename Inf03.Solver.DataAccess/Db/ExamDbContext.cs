using Microsoft.EntityFrameworkCore;
using Inf03.Solver.DataAccess.Model;

namespace Inf03.Solver.DataAccess.Db;
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) 
        {

        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inf03QuestionModel>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Inf03QuestionModel>()
            .Property(ExamProperty => ExamProperty.Id)
            .HasColumnName("id")
            .HasColumnType("bigint")
            .IsRequired();

        modelBuilder.Entity<Inf03QuestionModel>()
            .Property(ExamProperty => ExamProperty.Title)
            .HasColumnName("title")
            .HasColumnType("text");
        modelBuilder.Entity<Inf03QuestionModel>()
            .Property(ExamProperty => ExamProperty.CorrectAnswer)
            .HasColumnName("correct_answer")
            .HasColumnType("text");

        base.OnModelCreating(modelBuilder);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    public virtual DbSet<Inf03QuestionModel> exam { get; set; }
    }
