public class Hospital
{
    private List<Patient> patients = new List<Patient>(); // список пациентов

    public void AddPatient(Patient patient)
    {
        patients.Add(patient); // добавить пациента в список
    }

    public List<Patient> GetPatients()
    {
        return patients; 
    }

    public List<Patient> GetPatientsByDiagnosis(string diagnosis) // бизнес-логика получить пациентов по диагнозу
    {
        return patients.Where(p => p.Diagnosis.Equals(diagnosis, StringComparison.OrdinalIgnoreCase)).ToList();   // LINQ для фильтрации пациентов по диагнозу
    }

    public Patient GetOldestPatient()    // бизнес-логика получить самого старого пациента
    {
        return patients.OrderByDescending(p => p.Age).FirstOrDefault(); // LINQ для сортировки пациентов по возрасту (в убывающем порядке) и выбираем первого
    }
}