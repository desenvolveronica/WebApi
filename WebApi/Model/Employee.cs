using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Model
{
    [Table("employee")] //representação da tabela criada no banco
    public class Employee
    {
        [Key]
        public int id { get; private set; } 
        public string name { get; private set; }
        public int age { get; private set; }
        public string photo { get; private set; }
        //props representam as colunas da tabela 

        //como as propriedades são setadas como private é necessário criar o construtor abaixo
        public Employee(string name, int age, string photo)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.age = age;
            this.photo = photo;
        }

    }
}
