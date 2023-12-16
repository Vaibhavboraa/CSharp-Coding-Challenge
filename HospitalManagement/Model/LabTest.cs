using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Model
{
    public class LabTest
    {
        private int testId;
        private int appointmentId;
        private string testName;
        private string testResult;

        public int TestId
        {
            get { return testId; }
            set { testId = value; }
        }

        public int AppointmentId
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }

        public string TestResult
        {
            get { return testResult; }
            set { testResult = value; }
        }

        public LabTest()
        {
           
        }

        public LabTest(int testId, int appointmentId, string testName, string testResult)
        {
            TestId = testId;
            AppointmentId = appointmentId;
            TestName = testName;
            TestResult = testResult;
        }

        public override string ToString()
        {
            return $"{TestName} (ID: {TestId}, Appointment ID: {AppointmentId}, Result: {TestResult})";
        }
    }
}
