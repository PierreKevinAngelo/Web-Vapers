using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace WebAPIVapers.Data
{
    public class ClassContext : DbContext
    {
        public ClassContext()
        {

        }

        public ClassContext(DbContextOptions<ClassContext> options) : base(options) {}
        public DbSet<Master_Customer> Master_Customer { get; set; }
        public DbSet<Master_Barang> Master_Barang { get; set; }
        public DbSet<Master_Supplier> Master_Supplier { get; set; }
    }
}
