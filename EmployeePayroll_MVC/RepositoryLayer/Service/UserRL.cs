using CommonLayer.Model;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Service
{
    public class UserRL : IUserRL
    {
        IConfiguration iconfig;

        public UserRL(IConfiguration iconfig)
        {
            this.iconfig = iconfig;
        }

        public EmployeeModel AddEmployee(EmployeeModel empModel)
        {
            try
            {
                using (SqlConnection objConnection = new SqlConnection(iconfig.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand objCommand = new SqlCommand("AddEmployee", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    objCommand.Parameters.AddWithValue("@Name", empModel.Name);
                    objCommand.Parameters.AddWithValue("@Profile_Image", empModel.Profile_Image);
                    objCommand.Parameters.AddWithValue("@Gender", empModel.Gender);
                    objCommand.Parameters.AddWithValue("@Department", empModel.Department);
                    objCommand.Parameters.AddWithValue("@Salary", empModel.Salary);
                    objCommand.Parameters.AddWithValue("@StartDate", empModel.StartDate);
                    objCommand.Parameters.AddWithValue("@Notes", empModel.Notes);

                    objConnection.Open();
                    int result = objCommand.ExecuteNonQuery();
                    objConnection.Close();

                    if (result != 0)
                    {
                        return empModel;
                    }
                    else
                    {
                        return null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
