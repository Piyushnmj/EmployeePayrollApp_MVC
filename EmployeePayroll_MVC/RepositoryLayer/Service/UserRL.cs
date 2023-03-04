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
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> objList = new List<EmployeeModel>();

                using (SqlConnection objConnection = new SqlConnection(iconfig.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand objCommand = new SqlCommand("GetAllEmployee", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    objConnection.Open();
                    SqlDataReader objReader = objCommand.ExecuteReader();

                    while(objReader.Read())
                    {
                        EmployeeModel empModel = new EmployeeModel();

                        empModel.Id = Convert.ToInt32(objReader["Id"]);
                        empModel.Name = objReader["Name"].ToString();
                        empModel.Profile_Image = objReader["Profile_Image"].ToString();
                        empModel.Gender = objReader["Gender"].ToString();
                        empModel.Department = objReader["Department"].ToString();
                        empModel.Salary = Convert.ToInt64(objReader["Salary"]);
                        empModel.StartDate = Convert.ToDateTime(objReader["StartDate"]);
                        empModel.Notes = objReader["Notes"].ToString();

                        objList.Add(empModel);
                    }
                    objConnection.Close();
                }
                return objList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            EmployeeModel empModel = new EmployeeModel();

            using (SqlConnection objConnection = new SqlConnection(iconfig.GetConnectionString("EmployeePayrollMVC")))
            {
                SqlCommand objCommand = new SqlCommand("GetEmployeeById", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;

                objCommand.Parameters.AddWithValue("@Id", id);

                //string sqlQuery = "SELECT * FROM PayrollDetails WHERE Id= " + id;
                //SqlCommand objCommand = new SqlCommand(sqlQuery, objConnection);

                objConnection.Open();
                SqlDataReader objReader = objCommand.ExecuteReader();

                while (objReader.Read())
                {
                    empModel.Id = Convert.ToInt32(objReader["Id"]);
                    empModel.Name = objReader["Name"].ToString();
                    empModel.Profile_Image = objReader["Profile_Image"].ToString();
                    empModel.Gender = objReader["Gender"].ToString();
                    empModel.Department = objReader["Department"].ToString();
                    empModel.Salary = Convert.ToInt64(objReader["Salary"]);
                    empModel.StartDate = Convert.ToDateTime(objReader["StartDate"]);
                    empModel.Notes = objReader["Notes"].ToString();
                }
            }
            return empModel;
        }

        public EmployeeModel UpdateEmployeeDetail(EmployeeModel empModel)
        {
            try
            {
                using (SqlConnection objConnection = new SqlConnection(iconfig.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand objCommand = new SqlCommand("UpdateEmployeeDetails", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    objCommand.Parameters.AddWithValue("@Id", empModel.Id);
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteEmployeeDetail(int Id)
        {
            try
            {
                using (SqlConnection objConnection = new SqlConnection(iconfig.GetConnectionString("EmployeePayrollMVC")))
                {
                    SqlCommand objCommand = new SqlCommand("DeleteEmployeeDetails", objConnection);
                    objCommand.CommandType = CommandType.StoredProcedure;

                    objCommand.Parameters.AddWithValue("@Id", Id);

                    objConnection.Open();
                    int result = objCommand.ExecuteNonQuery();
                    objConnection.Close();

                    if (result != 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
