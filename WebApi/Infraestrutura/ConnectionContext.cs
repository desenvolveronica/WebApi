using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Infraestrutura
{
    public class ConnectionContext : DbContext
    {
        //faz o mapeamento onde procura a tabela employee e mapeia junto com a classe
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //sobrepor:override
          => optionsBuilder.UseNpgsql(
              "Server=localhost;" +
              "Port=5433 ;Database=employee_sample;" + 
              "User Id=postgres;" +
              "Password=32924468Ve@;");
        
    }
    //Database=employee_sample : nome do banco
}
