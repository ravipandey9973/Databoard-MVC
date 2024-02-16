using Databoard.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Databoard.Data
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):base(options) 
        {
            
        }
        public DbSet<School> Borad { get; set; }
    }
}
