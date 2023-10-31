using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]//rota de funcionário para acessar os métodos abaixo
    public class EmployeeController : ControllerBase //ControllerBase é mais adequado para API
    {
        private readonly IEmployeeRepository _employeeRepository; //chamando a interface IEmployeeRepository
        //necessário colocar esta variável dentro do contrutor
        public EmployeeController(IEmployeeRepository employeeRepository)//contrutor
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));//variávl da interface
        }
        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)//parâmetros são passados pela classe EmployeeViewModel 
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, null);
            _employeeRepository.Add(employee);
            return Ok();
        }
        [HttpGet]
        public IActionResult Get([FromQuery] EmployeeViewModel employeeView)
        {
            var employess = _employeeRepository.Get();
            return Ok(employess);
        }
    }
}
