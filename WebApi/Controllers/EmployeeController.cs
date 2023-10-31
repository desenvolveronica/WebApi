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
        public IActionResult Add([FromForm] EmployeeViewModel employeeView)//parâmetros são passados pela classe EmployeeViewModel 
        {
            var filePhath = Path.Combine("Storage", employeeView.Photo.FileName);
            using Stream fileStreen = new FileStream(filePhath, FileMode.Create);//Stream permite que salve na memória e que depois pegue e coloque em alguma pasta do sistema
            employeeView.Photo.CopyTo(fileStreen);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePhath);
            _employeeRepository.Add(employee);
            return Ok();
        }
        [HttpPost]
        [Route("{id}/Donwload")]
        public IActionResult DonwloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");
        }
        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.Get();
            return Ok(employess);
        }
    }
}
