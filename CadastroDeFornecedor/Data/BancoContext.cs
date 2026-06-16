using Microsoft.EntityFrameworkCore;
using Estagio.Models;

namespace Estagio.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<FornecedorModel> Fornecedores { get; set; }

    }
}
