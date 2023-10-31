namespace WebApi.ViewModel
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public string Age { get; set; }

        public IFormFile Photo { get; set; }//com o tipo IFormFile conseguimos acessar todas as propriedades do arquivo
    }
}
