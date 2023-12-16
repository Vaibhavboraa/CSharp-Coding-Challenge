using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    public class Medication
    {
        private int medicationId;
        private int appointmentId;
        private string medicationName;
        private string dosage;

        public int MedicationId
        {
            get { return medicationId; }
            set { medicationId = value; }
        }

        public int AppointmentId
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public string MedicationName
        {
            get { return medicationName; }
            set { medicationName = value; }
        }

        public string Dosage
        {
            get { return dosage; }
            set { dosage = value; }
        }

        public Medication()
        {
           
        }

        public Medication(int medicationId, int appointmentId, string medicationName, string dosage)
        {
            MedicationId = medicationId;
            AppointmentId = appointmentId;
            MedicationName = medicationName;
            Dosage = dosage;
        }

        public override string ToString()
        {
            return $"{MedicationName} (ID: {MedicationId}, Appointment ID: {AppointmentId})";
        }
    }
}
