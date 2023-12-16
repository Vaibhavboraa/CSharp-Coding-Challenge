using HospitalManagement.Exceptions;
using HospitalManagement.Model;
using HospitalManagement.Repository;


while (true)
{

    Console.WriteLine("<----------------------------WELCOME TO AIIMS HOSPITAL-----------------------------> \n\n");
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Patient Related Operations");
    Console.WriteLine("2. Appointment Related Operations");

    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("Patient Related Operations:");
            Console.WriteLine("1. Get Patient by ID");
            Console.WriteLine("2. List all Patients");
            Console.WriteLine("3. Add a Patient");
            Console.WriteLine("4. Update a Patient");
            Console.WriteLine("5. Delete a Patient");

            int patientOption = Convert.ToInt32(Console.ReadLine());

            switch (patientOption)
            {
                case 1:
                    getPatientById();
                    break;

                case 2:

                    getAllPatients();
                    break;

                case 3:
                    addPatient();
                    break;

                case 4:
                    updatePatient();
                    break;

                case 5:
                    DeletePatient();
                    break;

                default:
                    Console.WriteLine("Invalid option for Patient Related Operations.");
                    break;
            }
            break;

        case 2:
            Console.WriteLine("Appointment Related Operations:");
            Console.WriteLine("1. Get Appointment by ID");
            Console.WriteLine("2. Get Appointments for a Patient");
            Console.WriteLine("3. Get Appointments for a Doctor");
            Console.WriteLine("4. Schedule an Appointment");
            Console.WriteLine("5. Update an Appointment");
            Console.WriteLine("6. Cancel an Appointment");

            int appointmentOption = Convert.ToInt32(Console.ReadLine());

            switch (appointmentOption)
            {
                case 1:
                    getAppointmentByID();


                    break;

                case 2:
                    getAppointmentsForPatient();
                    break;

                case 3:
                    getAppointmentForDoctor();
                    break;

                case 4:
                    ScheduleAppointment();
                    break;

                case 5:
                    UpdateAppointment();
                    break;

                case 6:
                    CancelAppointment();
                    break;

                default:
                    Console.WriteLine("Invalid option for Appointment Related Operations.");
                    break;
            }
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }


}















#region


//1.

void getPatientById()
{
    PatientRepo patientRepo = new PatientRepo();

    try
    {
        Console.Write("Enter the patient ID: ");
        int patientIdToSearch;
        if (int.TryParse(Console.ReadLine(), out patientIdToSearch))
        {
            Patient patient = patientRepo.getPatientById(patientIdToSearch);

            if (patient != null)
            {
                Console.WriteLine("Patient found: " + patient);
            }
            else
            {
                Console.WriteLine($"Patient with ID {patientIdToSearch} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for patient ID.");
        }
    }
    catch (PatientNumberNotFoundException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");

    }
    catch (Exception ex)
    {

        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}


//2.


void getAllPatients()
{
    PatientRepo patientRepo = new PatientRepo();

    try
    {
        List<Patient> patients = patientRepo.getAllPatients();

        if (patients.Count > 0)
        {
            Console.WriteLine("All Patients:");

            foreach (Patient patient in patients)
            {
                Console.WriteLine(patient);
            }
        }
        else
        {
            Console.WriteLine("No patients found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}


//3.

void addPatient()
{
    PatientRepo patientRepo = new PatientRepo();

    try
    {

        Console.WriteLine("Enter patient details:");
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Date of Birth (YYYY-MM-DD): ");
        DateTime dateOfBirth;
        if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        {

            Console.Write("Gender: ");
            string gender = Console.ReadLine();

            Console.Write("Contact Number: ");
            string contactNumber = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();


            Patient newPatient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                ContactNumber = contactNumber,
                Address = address
            };


            patientRepo.addPatient(newPatient);

            Console.WriteLine("Patient added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter the date in the specified format.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error adding patient: {ex.Message}");
    }
}



//4.

void updatePatient()
{
    PatientRepo patientRepo = new PatientRepo();

    try
    {

        Console.Write("Enter the Patient ID to update: ");
        if (int.TryParse(Console.ReadLine(), out int patientId))
        {

            Patient existingPatient = patientRepo.getPatientById(patientId);

            if (existingPatient != null)
            {

                Console.WriteLine("Enter updated patient details:");
                Console.Write("First Name: ");
                existingPatient.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                existingPatient.LastName = Console.ReadLine();

                Console.Write("Date of Birth (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                {
                    existingPatient.DateOfBirth = dateOfBirth;

                    Console.Write("Gender: ");
                    existingPatient.Gender = Console.ReadLine();

                    Console.Write("Contact Number: ");
                    existingPatient.ContactNumber = Console.ReadLine();

                    Console.Write("Address: ");
                    existingPatient.Address = Console.ReadLine();


                    patientRepo.updatePatient(existingPatient);

                    Console.WriteLine("Patient updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid date format. ");
                }
            }
            else
            {
                Console.WriteLine($"Patient with ID {patientId} not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid Patient ID. Please enter a valid numeric ID.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating patient: {ex.Message}");
    }
}


//5. Delete Patient


void DeletePatient()
{
    PatientRepo patientRepo = new PatientRepo();

    try
    {
        
        Console.Write("Enter the Patient ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int patientIdToDelete))
        {
            
            patientRepo.deletePatient(patientIdToDelete);
        }
        else
        {
            Console.WriteLine("Invalid Patient ID. Please enter a valid numeric ID.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting patient: {ex.Message}");
    }

}














///////////////  APPOINTMENT


//1.

void getAppointmentByID()
{
    AppointmentRepo appointmentRepo = new AppointmentRepo();

    try
    {
        Console.WriteLine("Enter the Appointment ID to retrieve:");
        int appointmentIdToSearch = int.Parse(Console.ReadLine());

        Appointment appointment = appointmentRepo.getAppointmentById(appointmentIdToSearch);

        if (appointment != null)
        {
            Console.WriteLine("Appointment found: " + appointment);
        }
        else
        {
            Console.WriteLine($"Appointment with ID {appointmentIdToSearch} not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");

    }
}



//2. getAppointmentsForPatient

void getAppointmentsForPatient()
{

    AppointmentRepo appointmentRepo = new AppointmentRepo();

    try
    {
        Console.WriteLine("Enter the Patient ID to retrieve appointments:");
        int patientIdToSearch = int.Parse(Console.ReadLine());

        List<Appointment> appointments = appointmentRepo.getAppointmentsForPatient(patientIdToSearch);

        if (appointments.Count > 0)
        {
            Console.WriteLine($"Appointments found for Patient ID {patientIdToSearch}:");
            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment);
            }
        }
        else
        {
            Console.WriteLine($"No appointments found for Patient ID {patientIdToSearch}.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");

    }
}


//3. GetAppointmentForDoctor

void getAppointmentForDoctor()
{
    AppointmentRepo appointmentRepo = new AppointmentRepo();

    try
    {
        Console.WriteLine("Enter the Doctor ID to retrieve appointments:");
        int doctorIdToSearch = int.Parse(Console.ReadLine());

        List<Appointment> appointments = appointmentRepo.getAppointmentsForDoctor(doctorIdToSearch);

        if (appointments.Count > 0)
        {
            Console.WriteLine($"Appointments found for Doctor ID {doctorIdToSearch}:");
            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment);
            }
        }
        else
        {
            Console.WriteLine($"No appointments found for Doctor ID {doctorIdToSearch}.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");

    }
}


//4. Schedule Appointment



void ScheduleAppointment()
{
    AppointmentRepo appointmentRepo = new AppointmentRepo();
    try
    {
        Console.WriteLine("Enter patient ID:");
        int patientId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter doctor ID:");
        int doctorId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter appointment date and time (yyyy-MM-dd HH:mm):");
        DateTime appointmentDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null);

        Console.WriteLine("Enter appointment description:");
        string description = Console.ReadLine();

        Appointment newAppointment = new Appointment
        {
            PatientId = patientId,
            DoctorId = doctorId,
            AppointmentDate = appointmentDate,
            Description = description
        };

        appointmentRepo.scheduleAppointment(newAppointment);

        Console.WriteLine("Appointment scheduled successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        
    }
}







//5. Update appointment


void UpdateAppointment()
{
    AppointmentRepo appointmentRepo = new AppointmentRepo();

    try
    {
        Console.WriteLine("Enter appointment ID to update:");
        int appointmentId = int.Parse(Console.ReadLine());


        Appointment existingAppointment = appointmentRepo.getAppointmentById(appointmentId);

        if (existingAppointment != null)
        {
            Console.WriteLine($"Current appointment details: {existingAppointment}");

            Console.WriteLine("Enter new appointment date and time (MM-dd-yyyy HH:mm):");
            DateTime newAppointmentDate = DateTime.ParseExact(Console.ReadLine(), "MM-dd-yyyy HH:mm", null);


            Console.WriteLine("Enter new appointment description:");
            string newDescription = Console.ReadLine();


            existingAppointment.AppointmentDate = newAppointmentDate;
            existingAppointment.Description = newDescription;


            appointmentRepo.updateAppointment(existingAppointment);

            Console.WriteLine("Appointment updated successfully!");
        }
        else
        {
            Console.WriteLine($"Appointment with ID {appointmentId} not found.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

//6. Cancel Appointment

void CancelAppointment()
{
    AppointmentRepo appointmentRepo = new AppointmentRepo();

    try
    {
        Console.Write("Enter appointment ID to cancel: ");
        if (int.TryParse(Console.ReadLine(), out int appointmentId))
        {
            appointmentRepo.CancelAppointment(appointmentId);
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid appointment ID.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected error: {ex.Message}");
    }
}

#endregion