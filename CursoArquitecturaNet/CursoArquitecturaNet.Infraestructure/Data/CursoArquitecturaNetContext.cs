using CursoArquitecturaNet.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoArquitecturaNet.Infraestructure.Data
{
    public class CursoArquitecturaNetContext : DbContext
    {
        public CursoArquitecturaNetContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
