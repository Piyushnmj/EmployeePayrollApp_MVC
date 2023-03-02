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
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
