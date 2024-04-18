/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using DataLinkLibrary.Models;

namespace DataLinkLibrary.Repositories;

public interface IPatientRepository
{
    Patient? GetById(int id);
    IEnumerable<Patient> GetAll();
    void Add(int id, string name, string contactNumber);
    void Update(int id, string name, string contactNumber);
    void Delete(int id);
}

public class PatientRepository : IPatientRepository
{
    private readonly List<Patient> _patients;

    public PatientRepository()
    {
        _patients = [];
    }

    public Patient? GetById(int id)
    {
        return _patients.FirstOrDefault(patient => patient.Id == id);
    }

    public IEnumerable<Patient> GetAll()
    {
        return _patients;
    }

    public void Add(int id, string name, string contactNumber)
    {
        if (!_patients.Any(patient => patient.Id == id))
            _patients.Add(new Patient { Id = id, Name = name, ContactNumber = contactNumber });
    }

    public void Update(int id, string name, string contactNumber)
    {
        var existingPatient = GetById(id);

        if (existingPatient != null)
        {
            existingPatient.Name = name;
            existingPatient.ContactNumber = contactNumber;
        }
    }

    public void Delete(int id)
    {
        var patientToDelete = GetById(id);

        if (patientToDelete != null) _patients.Remove(patientToDelete);
    }
}
