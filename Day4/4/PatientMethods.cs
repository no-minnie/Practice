public partial class Patient // кл слово partial
{
    public override string ToString()
    {
        return $"Имя: {Name}, Возраст: {Age}, Диагноз: {Diagnosis}";
    }
}