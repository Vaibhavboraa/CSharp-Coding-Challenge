using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    public class Billing
    {
        private int billId;
        private int patientId;
        private int doctorId;
        private int appointmentId;
        private DateTime billDate;
        private decimal amount;
        private string paymentStatus;

        public int BillId
        {
            get { return billId; }
            set { billId = value; }
        }

        public int PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }

        public int DoctorId
        {
            get { return doctorId; }
            set { doctorId = value; }
        }

        public int AppointmentId
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public DateTime BillDate
        {
            get { return billDate; }
            set { billDate = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string PaymentStatus
        {
            get { return paymentStatus; }
            set { paymentStatus = value; }
        }

        public Billing()
        {
            
        }

        public Billing(int billId, int patientId, int doctorId, int appointmentId, DateTime billDate, decimal amount, string paymentStatus)
        {
            BillId = billId;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentId = appointmentId;
            BillDate = billDate;
            Amount = amount;
            PaymentStatus = paymentStatus;
        }

        public override string ToString()
        {
            return $"Billing {BillId} (Patient: {PatientId}, Doctor: {DoctorId}, Appointment: {AppointmentId}, Amount: {Amount}, Status: {PaymentStatus})";
        }
    }

}
