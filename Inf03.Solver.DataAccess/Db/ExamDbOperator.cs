using Microsoft.EntityFrameworkCore;

namespace Inf03.Solver.DataAccess.Db;
    public class ExamDbOperator : DbContext
    {
        protected readonly ExamDbContextService Service;
        public ExamDbOperator(DbContextOptions options) : base(options) 
        {
            Service = new ExamDbContextService();
        }
        
    }
