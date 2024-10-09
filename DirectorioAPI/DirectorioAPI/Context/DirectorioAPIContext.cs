using DirectorioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DirectorioAPI.Context
{
    public class DirectorioAPIContext : DbContext
    {
        public DirectorioAPIContext(DbContextOptions<DirectorioAPIContext> options) : base(options)
        {
            
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
