using HospitalManagement.Model;
using HospitalManagement.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        public string connectionString;
        SqlCommand cmd = null;
        public AppointmentRepo()
        {
            connectionString = DbConnUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public Appointment getAppointmentById(int appointmentId)
        {
            Appointment appointment = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE appointment_id = @AppointmentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            appointment = new Appointment
                            {
                                AppointmentId = (int)reader["appointment_id"],
                                PatientId = (int)reader["patient_id"],
                                DoctorId = (int)reader["doctor_id"],
                                AppointmentDate = Convert.ToDateTime(reader["appointment_date"]),
                                Description = reader["description"].ToString()
                            };
                        }
                    }
                }
            }

            return appointment;
        }



        public List<Appointment> getAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE patient_id = @PatientId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = (int)reader["appointment_id"],
                                PatientId = (int)reader["patient_id"],
                                DoctorId = (int)reader["doctor_id"],
                                AppointmentDate = Convert.ToDateTime(reader["appointment_date"]),
                                Description = reader["description"].ToString()
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public List<Appointment> getAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE doctor_id = @DoctorId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = (int)reader["appointment_id"],
                                PatientId = (int)reader["patient_id"],
                                DoctorId = (int)reader["doctor_id"],
                                AppointmentDate = Convert.ToDateTime(reader["appointment_date"]),
                                Description = reader["description"].ToString()
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public void scheduleAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "INSERT INTO Appointments (patient_id, doctor_id, appointment_date, description) " +
                               "VALUES (@PatientId, @DoctorId, @AppointmentDate, @Description)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void updateAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                string query = "UPDATE Appointments " +
                               "SET patient_id = @PatientId, doctor_id = @DoctorId, " +
                               "appointment_date = @AppointmentDate, description = @Description " +
                               "WHERE appointment_id = @AppointmentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);
                    command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);

                    command.ExecuteNonQuery();
                }
            }



        }
        public void CancelAppointment(int appointmentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    Appointment appointment = getAppointmentById(appointmentId);


                    if (appointment != null)
                    {

                        string deleteQuery = "DELETE FROM Appointments WHERE appointment_id = @AppointmentId";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@AppointmentId", appointmentId);
                            deleteCommand.ExecuteNonQuery();
                        }

                        Console.WriteLine($"Appointment {appointmentId} canceled successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"Appointment with ID {appointmentId} not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error canceling appointment: {ex.Message}");

            }
        }
    }
}
