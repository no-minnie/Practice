namespace Task22
{
    public interface ICarBuilder
    {
        void SetModel(string model);
        void SetBodyStyle(string bodyStyle);
        void SetEngine(string engine);
        void SetWheels(int wheels);
        void SetColor(string color);
        Car GetResult();
    }
}