using Microsoft.EntityFrameworkCore;
using TodoApi.Entities;


namespace TodoApi.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {

        }
        // Entidade é uma classe no meu programa, e uma tabela no banco de dados
        public DbSet<Tarefa> Tarefas { get; set; } // entidade
    }

}

