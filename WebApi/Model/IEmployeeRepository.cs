﻿//criação de interface para implementar o padrão REPOSITORY
namespace WebApi.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        List<Employee> Get();
    }
}
