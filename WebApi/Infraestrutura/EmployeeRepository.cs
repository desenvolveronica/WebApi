using WebApi.Model;

namespace WebApi.Infraestrutura
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _contexto = new ConnectionContext(); //chamando a classe do ConnectionContext
        public void Add(Employee employee)
        {
            _contexto.Employees.Add(employee);
            _contexto.SaveChanges();
        }

        public List<Employee> Get()
        {
            return _contexto.Employees.ToList();
        }
        public Employee? Get(int id)
        {
            return _contexto.Employees.Find(id);//find para encontrar
        }
    }
}
