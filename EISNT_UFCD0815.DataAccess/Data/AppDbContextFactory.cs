//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace EISNT_UFCD0815.DataAccess.Data
//{
//    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
//    {
//        public AppDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
//            string? connectionString = "string";
//            optionsBuilder.UseSqlServer(connectionString);

//            return new AppDbContext(optionsBuilder.Options);
//        }
//    }
//}
