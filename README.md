# Day-7 Challenge-1: Data Abstraction Layer Implementation for a 3-tier Doctor Appointment System

- **Author:** Sakthi (Sandy) Santhosh
- **Created on:** 17/04/2024

## Description

This .NET solution is a part of 3-tier architecture-based application. The goal of the application is to manage doctors and patients with appointments. This .NET solution implements the 3rd layer of the architecture, that is the data abstraction layer. It provides an interface to the second layer (business logic layer) that the layer can use. This decouples low-level code from high-level code, adhering to dependency inversion, which is one of the principles in the SOLID principles.

## Build

Open a shell instance on your machine, navigate to the project folder and run the following command:

```bash
dotnet build --project ./DataLinkLibrary/DataLinkLibrary.csproj
```

This will output the assembly as DLL to `/DataLinkLibrary/bin/` folder.

## Logic

### Interface: `IAppointmentRepository` (implemented by `AppointmentRepository`)

1. **`GetById(int id)`:** This method retrieves an appointment by its unique identifier. It searches through the list of appointments and returns the one with the matching ID, if found.
2. **`GetAll()`**: This method returns all appointments available in the repository. It provides a complete list of appointments without any filtering.
3. **`Schedule(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime)`:** This method is used to schedule a new appointment. It takes parameters like the appointment ID, doctor, patient, and the date and time of the appointment. It creates a new appointment object and adds it to the list of appointments.
4. **`UpdateSchedule(int id, DateTime appointmentDateTime)`:** This method updates the schedule of an existing appointment identified by its ID. It changes the date and time of the appointment to the provided value.
5. **`Unschedule(int id)`:** This method removes a scheduled appointment from the repository. It first retrieves the appointment by its ID, then removes it from both the main list of appointments and the list of appointments associated with the doctor.

### Interface: `IDoctorRepository` (implemented by `DoctorRepository`)

1. **`GetById(int id)`:** This method retrieves a doctor by their unique identifier. It searches through the list of doctors and returns the one with the matching ID, if found.
2. **`GetAll()`:** This method returns all doctors available in the repository. It provides a complete list of doctors without any filtering.
3. **`Add(int id, string name, string specialization)`:** This method adds a new doctor to the repository. It creates a new doctor object with the provided ID, name, and specialization, then adds it to the list of doctors if it doesn't already exist.
4. **`Update(int id, string name, string specialization)`:** This method updates the details of an existing doctor. It modifies the name and specialization of the doctor identified by the provided ID.
5. **`Delete(int id)`:** This method deletes a doctor from the repository based on their ID. It removes the doctor from the list of doctors.
6. **`IsAvailable(int doctorId, DateTime appointmentDateTime)`:** This method checks if a doctor is available at a specified date and time. It verifies whether the doctor has any appointments scheduled at the given time.
7. **`GetPatientDetailsAtScheduledTime(int doctorId, DateTime appointmentDateTime)`:** This method retrieves the details of the patient scheduled for an appointment with the specified doctor at the given date and time. It returns the patient associated with the appointment if there is one, otherwise, it returns null.

### Interface `IPatientRepository` (implemented by `PatientRepository`)

1. **`GetById(int id)`:** This method retrieves a patient by their unique identifier. It searches through the list of patients and returns the one with the matching ID, if found.
2. **`GetAll()`:** This method returns all patients available in the repository. It provides a complete list of patients without any filtering.
3. **`Add(int id, string name, string contactNumber)`:** This method adds a new patient to the repository. It creates a new patient object with the provided ID, name, and contact number, then adds it to the list of patients if it doesn't already exist.
4. **`Update(int id, string name, string contactNumber)`:** This method updates the details of an existing patient. It modifies the name and contact number of the patient identified by the provided ID.
5. **`Delete(int id)`:** This method deletes a patient from the repository based on their ID. It removes the patient from the list of patients.

## Information

### System

- **Operating System:** Debian Headless 12.0
- **Kernel:** `6.1.0-rpi4-rpi-v8`
- **Architecture:** `aarch64` (`arm64`)

### .NET Framework

- **SDK:** 8.0.204
- **Runtimes Installed:**
    - **ASP.NET:** 8.0.4
    - **.NET Core:** 8.0.4

## Contribution

This project was created for learning and development purposes only. Any contributions to the repository is discouraged.
