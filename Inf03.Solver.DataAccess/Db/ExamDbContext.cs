using Microsoft.EntityFrameworkCore;
using Inf03.Solver.DataAccess.Model;

namespace Inf03.Solver.DataAccess.Db;
    public class ExamDbContext : ExamDbOperator
    { 
        public ExamDbContext(DbContextOptions options) : base(options) 
        {
    
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(await Service.JsonConnectionStringDeserialize());
        base.OnConfiguring(optionsBuilder);
    }
    DbSet<ExamModel> exam { get; set; }
    }
