using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    public class ApiDbContext : DbContext
    {
        // Configura o contexto do banco de dados utilizando as opções fornecidas.
        public ApiDbContext(DbContextOptions options) : base(options) { }

        // Define uma tabela de usuários no banco de dados, mapeada para a entidade User.
        public DbSet<User> Users { get; set; }

        // Configura o comportamento do modelo(model: Representação dos dados) durante a criação do esquema(do banco: Tabela, colunas, FK, PK....).
        // Aplica todas as configurações de entidades encontradas no assembly atual.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        }
    }
}
