//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace EISNT_UFCD0815.DataAccess.Data
//{
//    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//    {
//        public AppDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            string? connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EISNT_UFCD0815;Trusted_Connection=True;MultipleActiveResultSets=true";
//            optionsBuilder.UseSqlServer(connectionString);

//            return new AppDbContext(optionsBuilder.Options);
//        }
//    }
//}
