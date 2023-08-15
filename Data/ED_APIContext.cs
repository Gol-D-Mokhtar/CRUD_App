using CRUD_App.models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_App.Data
{
    public class ED_APIContext : DbContext
    {
        public ED_APIContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EmployeeData> EmployeeData { get; set; }
    }
}
