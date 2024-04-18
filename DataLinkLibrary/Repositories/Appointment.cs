/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using DataLinkLibrary.Models;

namespace DataLinkLibrary.Repositories;

public interface IAppointmentRepository
{
    Appointment? GetById(int id);
    IEnumerable<Appointment> GetAll();
    public void Schedule(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime);
    public void UpdateSchedule(int id, DateTime appointmentDateTime);
    public void Unschedule(int id);
}

public class AppointmentRepository : IAppointmentRepository
{
    private readonly List<Appointment> _appointments;

    public AppointmentRepository()
    {
        _appointments = [];
    }

    public Appointment? GetById(int id)
    {
        return _appointments.FirstOrDefault(a => a.Id == id);
    }

    public IEnumerable<Appointment> GetAll()
    {
        return _appointments;
    }

    public void Schedule(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime)
    {
        _appointments.Add(new Appointment { Id = id, Doctor = doctor, Patient = patient, AppointmentDateTime = appointmentDateTime });
    }

    public void UpdateSchedule(int id, DateTime appointmentDateTime)
    {
        var existingAppointment = GetById(id);

        if (existingAppointment != null)
        {
            existingAppointment.AppointmentDateTime = appointmentDateTime;
        }
    }

    public void Unschedule(int id)
    {
        var appointmentToDelete = GetById(id);

        if (appointmentToDelete != null)
        {
            var relatedDoctorAppointments = appointmentToDelete.Doctor.Appointments;

            relatedDoctorAppointments.Remove(appointmentToDelete);
            _appointments.Remove(appointmentToDelete);
        }
    }
}
