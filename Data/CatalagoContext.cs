using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CatalagoContext : DbContext
    {
        public CatalagoContext(DbContextOptions<CatalagoContext> options)
        :base(options){}
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
