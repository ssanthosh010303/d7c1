/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using DataLinkLibrary.Models;

namespace DataLinkLibrary.Repositories;

public interface IDoctorRepository
{
    Doctor? GetById(int id);
    IEnumerable<Doctor> GetAll();
    void Add(int id, string name, string specialization);
    void Update(int id, string name, string specialization);
    void Delete(int id);
    bool IsAvailable(int doctorId, DateTime appointmentDateTime);
    Patient? GetPatientDetailsAtScheduledTime(int doctorId, DateTime appointmentDateTime);
}

public class DoctorRepository : IDoctorRepository
{
    private readonly List<Doctor> _doctors;

    public DoctorRepository()
    {
        _doctors = [];
    }

    public Doctor? GetById(int id)
    {
        return _doctors.FirstOrDefault(doctor => doctor.Id == id);
    }

    public IEnumerable<Doctor> GetAll()
    {
        return _doctors;
    }

    public void Add(int id, string name, string specialization)
    {
        if (!_doctors.Any(doctor => doctor.Id == id))
            _doctors.Add(new Doctor { Id = id, Name = name, Specialization = specialization });
    }

    public void Update(int id, string name, string specialization)
    {
        var existingDoctor = GetById(id);

        if (existingDoctor != null)
        {
            existingDoctor.Name = name;
            existingDoctor.Specialization = specialization;
        }
    }

    public void Delete(int id)
    {
        var doctorToDelete = GetById(id);

        if (doctorToDelete != null) _doctors.Remove(doctorToDelete);
    }

    public Patient? GetPatientDetailsAtScheduledTime(int doctorId, DateTime appointmentDateTime)
    {
        var doctor = GetById(doctorId);

        if (doctor != null)
            return doctor.Appointments.FirstOrDefault(appointment => appointment.AppointmentDateTime == appointmentDateTime)?.Patient;
        return null;
    }

    public bool IsAvailable(int doctorId, DateTime appointmentDateTime)
    {
        var doctor = GetById(doctorId);

        return doctor != null && !_doctors.Any(doctor => doctor.Id == doctorId
            && doctor.Appointments.Any(appointment => appointment.AppointmentDateTime == appointmentDateTime));
    }
}
