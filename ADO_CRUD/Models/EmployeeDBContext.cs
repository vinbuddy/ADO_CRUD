using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace ADO_CRUD.Models
{
    public class EmployeeDBContext
    {
        string connectStr = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Employee> GetEmployees()
        {
            List<Employee> employeeList = new List<Employee>();

            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT * FROM Employee";
            cmd.Connection = connection;

            connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader();

            // Get rows in table
            while(dataReader.Read())
            {
                Employee employee = new Employee();

                employee.name = dataReader["NAME"].ToString();
                employee.city = dataReader["CITY"].ToString();
                employee.id = dataReader["ID"].ToString();
                employee.gender = dataReader["GENDER"].ToString();
                employee.age = Convert.ToInt32(dataReader["AGE"].ToString());
                employee.salary = float.Parse(dataReader["SALARY"].ToString());

                employeeList.Add(employee);
            }

            connection.Close();

            return employeeList;

        }

        public bool AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Employee(ID, NAME, GENDER, AGE, SALARY, CITY) VALUES (@id, @name, @gender, @age, @salary, @city)";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@id", employee.id);
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@age", employee.age);
            cmd.Parameters.AddWithValue("@salary", employee.salary);
            cmd.Parameters.AddWithValue("@city", employee.city);



            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            // Success
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Employee SET ID = @id, NAME = @name, GENDER = @gender, AGE =  @age, SALARY = @salary, CITY = @city WHERE ID = @id";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@id", employee.id);
            cmd.Parameters.AddWithValue("@name", employee.name);
            cmd.Parameters.AddWithValue("@gender", employee.gender);
            cmd.Parameters.AddWithValue("@age", employee.age);
            cmd.Parameters.AddWithValue("@salary", employee.salary);
            cmd.Parameters.AddWithValue("@city", employee.city);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            // Success
            if (result > 0)
            {
                return true;
            }

            return false;
        }
        public bool DeleteEmployee(string id)
        {
            SqlConnection connection = new SqlConnection(connectStr);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE FROM Employee WHERE ID = @id";
            cmd.Connection = connection;

            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            // Success
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}