using HospitalManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    internal interface IAppointmentRepo
    {
        public Appointment getAppointmentById(int appointmentId);
        public List<Appointment> getAppointmentsForPatient(int patientId);
        public List<Appointment> getAppointmentsForDoctor(int doctorId);
        public void scheduleAppointment(Appointment appointment);
        public void updateAppointment(Appointment appointment);
        public void CancelAppointment(int appointmentId);




    }
}
