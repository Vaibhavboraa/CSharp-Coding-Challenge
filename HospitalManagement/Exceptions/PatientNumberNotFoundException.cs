﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Exceptions
{
    internal class PatientNumberNotFoundException:Exception
    {
        public PatientNumberNotFoundException()
        {
        }

        public PatientNumberNotFoundException(string message)
            : base(message)
        {
        }

        public PatientNumberNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
