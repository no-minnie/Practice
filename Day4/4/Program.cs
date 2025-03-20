//Система управления медицинскими записями
public class Program
{
    public static void Main(string[] args)
    {
        Hospital hospital = new Hospital(); // создаем больницу

        Patient patient1 = new Patient { Name = "Мальвина", Age = 30, Diagnosis = "Грипп" }; // пациентов
        Patient patient2 = new Patient { Name = "Артемон", Age = 75, Diagnosis = "Артрит" };
        Patient patient3 = new Patient { Name = "Пьеро", Age = 40, Diagnosis = "Грипп" };
        Patient patient4 = new Patient { Name = "Арлекин", Age = 30, Diagnosis = "Астма" };
        Patient patient5 = new Patient { Name = "Тортила", Age = 20, Diagnosis = "Деменция" };
        Patient patient6 = new Patient { Name = "Буратино", Age = 71, Diagnosis = "Грипп" };

        hospital.AddPatient(patient1); // пациентов в больницу
        hospital.AddPatient(patient2);
        hospital.AddPatient(patient3);
        hospital.AddPatient(patient4);
        hospital.AddPatient(patient5);
        hospital.AddPatient(patient6);

        List<Patient> fluPatients = hospital.GetPatientsByDiagnosis("Грипп"); // пациенты с гриппом
        Console.WriteLine("Пациенты с гриппом:");
        foreach (var patient in fluPatients)
        {
            Console.WriteLine(patient);
        }

        Patient oldestPatient = hospital.GetOldestPatient(); // самый старый пациент
        Console.WriteLine($"\nСамый старый пациент: {oldestPatient}"); 
    }
}