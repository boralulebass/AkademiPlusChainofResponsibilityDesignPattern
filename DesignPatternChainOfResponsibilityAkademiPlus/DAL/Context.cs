using Microsoft.EntityFrameworkCore;

namespace DesignPatternChainOfResponsibilityAkademiPlus.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D0HPTG1\\SQLEXPRESS;initial Catalog=DbAkademiPlusChainOfResp;integrated security=true;");
        }

        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
