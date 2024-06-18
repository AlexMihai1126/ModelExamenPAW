using Microsoft.EntityFrameworkCore;
using ModelExamen.Models;

namespace ModelExamen.ContextModels
{
    public class ProiectDBContext : DbContext
    {
        public DbSet<Zbor> Zboruri {  get; set; }
        public DbSet<Pilot> Piloti { get; set; }

        public ProiectDBContext(DbContextOptions<ProiectDBContext> options) : base(options) { }
    }
}
