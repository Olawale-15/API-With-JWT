using Microsoft.EntityFrameworkCore;
using SchoolNewApi.Entities;

namespace SchoolNewApi.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option):base(option)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
