using HospitalManagement.Exceptions;
using HospitalManagement.Model;
using HospitalManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HospitalManagement.Repository.PatientRepo;

namespace HospitalManagement.Repository
{
    public class PatientRepo : IPatientRepo
    {
        public string connectionString;
        SqlCommand cmd = null;
        public PatientRepo()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }


        public Patient getPatientById(int patientId)
        {
            Patient patient = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Patients WHERE patient_id = @PatientId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            patient = new Patient
                            {
                                PatientId = (int)reader["patient_id"],
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]),
                                Gender = reader["gender"].ToString(),
                                ContactNumber = reader["contact_number"].ToString(),
                                Address = reader["address"].ToString()
                            };
                        }
                        else
                        {

                            throw new PatientNumberNotFoundException($"Patient with ID {patientId} not found.");
                        }
                    }
                }
            }

            return patient;
        }


        
        public List<Patient> getAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Patients";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patient patient = new Patient
                            {
                                PatientId = (int)reader["patient_id"],
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                DateOfBirth = Convert.ToDateTime(reader["date_of_birth"]),
                                Gender = reader["gender"].ToString(),
                                ContactNumber = reader["contact_number"].ToString(),
                                Address = reader["address"].ToString()
                            };

                            patients.Add(patient);
                        }
                    }
                }
            }

            return patients;
        }


        public void addPatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Patients (first_name, last_name, date_of_birth, gender, contact_number, address) " +
                               "VALUES (@FirstName, @LastName, @DateOfBirth, @Gender, @ContactNumber, @Address)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                    command.Parameters.AddWithValue("@Address", patient.Address);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void updatePatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Patients " +
                               "SET first_name = @FirstName, " +
                               "  last_name = @LastName, " +
                               "  date_of_birth = @DateOfBirth, " +
                               "  gender = @Gender, " +
                               "  contact_number = @ContactNumber, " +
                               "  address = @Address " +
                               "WHERE patient_id = @PatientId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patient.PatientId);
                    command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                    command.Parameters.AddWithValue("@LastName", patient.LastName);
                    command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", patient.Gender);
                    command.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                    command.Parameters.AddWithValue("@Address", patient.Address);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void deletePatient(int patientId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Patients WHERE patient_id = @PatientId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Patient with ID {patientId} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Patient with ID {patientId} not found.");
                    }
                }
            }
        }

    }
}
