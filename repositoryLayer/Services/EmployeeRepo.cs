using CommonLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRepo :IEmployeeRepo
    {
        //Employee employee = new Employee();
        List<Employee> employeePayList = new List<Employee>();

        //sql connection
        SqlConnection con = new SqlConnection();
        readonly string connectionString;
        
        private readonly IConfiguration _configuration;
        public EmployeeRepo(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString= _configuration.GetConnectionString("EmployeeDbCs");
            con.ConnectionString = connectionString;

        }
        //connection sql
     
       
        /// <summary>
        /// View the Employee List
        /// </summary>
        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                this.con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ImageLink=rdr["ImageLink"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt64(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Note =rdr["Note"].ToString();
                    employeePayList.Add(employee);
                }
                return employeePayList;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
        /// <summary>
        /// Add Employee
        /// </summary>
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@ImageLink", employee.ImageLink);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Note", employee.Note);

                con.Open();
                cmd.ExecuteNonQuery();

                return employee;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
            
        }
        /// <summary>
        /// UpdateEmployeeList
        /// </summary>
        public Employee UpdateEmployee(Employee employee)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType =CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@ImageLink", employee.ImageLink);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Department", employee.Department);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employee.StartDate);
                cmd.Parameters.AddWithValue("@Note", employee.Note);
                this.con.Open();
                cmd.ExecuteNonQuery();

                return employee;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close() ;
            }
            
        }
        /// <summary>
        /// Delete Data From Employee
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType =CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                this.con.Open();
                int a = cmd.ExecuteNonQuery();
                if (a>0)
                    Console.WriteLine("Delete Employee");
                else
                    Console.WriteLine("Not Delete Employee");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
        }
        /// <summary>
        /// Detail Data Of Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Employee GetEmployeeById(int id)
        {
            try
            {
                Employee employee = new Employee();
                string query = "Select * from tableEmployee where id="+id;
                SqlCommand cmd = new SqlCommand(query, con);
                this.con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    employee.Id = Convert.ToInt32(rdr["Id"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ImageLink=rdr["IamgeLink"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt64(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Note=rdr["Note"].ToString();

                }

                return employee;
            }
            catch(Exception ex)
            {
              throw new Exception(ex.Message);
            }
            finally
            {
                this.con.Close();
            }
            
        }
    }
}
