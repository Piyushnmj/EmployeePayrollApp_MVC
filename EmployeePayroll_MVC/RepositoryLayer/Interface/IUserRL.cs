using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        public EmployeeModel AddEmployee(EmployeeModel empModel);
        public IEnumerable<EmployeeModel> GetAllEmployees();
        public EmployeeModel GetEmployeeData(int? id);
        public EmployeeModel UpdateEmployeeDetail(EmployeeModel empModel);
        public bool DeleteEmployeeDetail(int Id);
    }
}
