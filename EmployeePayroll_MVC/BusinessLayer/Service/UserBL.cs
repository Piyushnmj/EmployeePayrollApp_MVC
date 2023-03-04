using BusinessLayer.Interface;
using CommonLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL iuserRL;

        public UserBL(IUserRL iuserRL)
        {
            this.iuserRL = iuserRL;
        }

        public EmployeeModel AddEmployee(EmployeeModel empModel)
        {
            try
            {
                return iuserRL.AddEmployee(empModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return iuserRL.GetAllEmployees();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                return iuserRL.GetEmployeeData(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeModel UpdateEmployeeDetail(EmployeeModel empModel)
        {
            try
            {
                return iuserRL.UpdateEmployeeDetail(empModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployeeDetail(int Id)
        {
            try
            {
                return iuserRL.DeleteEmployeeDetail(Id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
