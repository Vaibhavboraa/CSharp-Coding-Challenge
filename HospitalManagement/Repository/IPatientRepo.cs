using HospitalManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository
{
    internal interface IPatientRepo
    {
        public Patient getPatientById(int patientId);
        public List<Patient> getAllPatients();
        public void addPatient(Patient patient);
        public void updatePatient(Patient patient);
        public void deletePatient(int patientId);

    }
}
