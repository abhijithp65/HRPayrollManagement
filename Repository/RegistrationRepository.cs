using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HRPayrollManagement.Models;

namespace HRPayrollManagement.Repository
{
    public class RegistrationRepository
    {
        private readonly string connectionString;
        private SqlConnection connection;

        public RegistrationRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["GetDatabaseConnection"].ToString();
            Connection();
        }

        private void Connection()
        {
            connection = new SqlConnection(connectionString);
        }

        public void InsertRegistration(Registration registration)
        {
            using (connection)
            {
                connection.Open();
                string storedProcedure = "SPI_Registration";
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@FirstName", registration.FirstName);
                command.Parameters.AddWithValue("@LastName", registration.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", registration.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", registration.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", registration.PhoneNumber);
                command.Parameters.AddWithValue("@EmailAddress", registration.EmailAddress);
                command.Parameters.AddWithValue("@Address", registration.Address);
                command.Parameters.AddWithValue("@State", registration.State);
                command.Parameters.AddWithValue("@City", registration.City);
                command.Parameters.AddWithValue("@Username", registration.Username);
                command.Parameters.AddWithValue("@Password", registration.Password);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateRegistration(Registration registration)
        {
            using (connection)
            {
                connection.Open();
                string storedProcedure = "SPU_Registration";
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", registration.Id);
                command.Parameters.AddWithValue("@FirstName", registration.FirstName);
                command.Parameters.AddWithValue("@LastName", registration.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", registration.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", registration.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", registration.PhoneNumber);
                command.Parameters.AddWithValue("@EmailAddress", registration.EmailAddress);
                command.Parameters.AddWithValue("@Address", registration.Address);
                command.Parameters.AddWithValue("@State", registration.State);
                command.Parameters.AddWithValue("@City", registration.City);
                command.Parameters.AddWithValue("@Username", registration.Username);
                command.Parameters.AddWithValue("@Password", registration.Password);

                command.ExecuteNonQuery();
            }
        }

        public Registration SelectRegistrationByUsername(string username)
        {
            using (connection)
            {
                connection.Open();
                string storedProcedure = "SPS_RegistrationByUsername";
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Username", username);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Registration
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                        Gender = reader["Gender"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        EmailAddress = reader["EmailAddress"].ToString(),
                        Address = reader["Address"].ToString(),
                        State = reader["State"].ToString(),
                        City = reader["City"].ToString(),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                }
                return null;
            }
        }

        public void DeleteRegistrationByUsername(string username)
        {
            using (connection)
            {
                connection.Open();
                string storedProcedure = "SPD_RegistrationByUsername"; 
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Username", username);

                command.ExecuteNonQuery();
            }
        }

       

        public void ChangePassword(string username, string newPassword)
        {
            using (connection)
            {
                connection.Open();
                string storedProcedure = "SPU_ChangePassword"; 
                SqlCommand command = new SqlCommand(storedProcedure, connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@NewPassword", newPassword);

                command.ExecuteNonQuery();
            }
        }

    }
}