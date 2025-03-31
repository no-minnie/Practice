namespace Task22
{
    public class CarDirector
    {
        private ICarBuilder _builder;

        public CarDirector(ICarBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder), "Строитель не может быть null.");
        }

        public CarDirector() { }

        public void Construct()
        {
            _builder.SetModel("Generic Model");
            _builder.SetBodyStyle("Generic Body");
            _builder.SetEngine("Generic Engine");
            _builder.SetWheels(4);
            _builder.SetColor("Generic Color");
        }

        public Car Construct(string model, string bodyStyle, string engine, int wheels, string color)
        {
            _builder.SetModel(model);
            _builder.SetBodyStyle(bodyStyle);
            _builder.SetEngine(engine);
            _builder.SetWheels(wheels);
            _builder.SetColor(color);
            return _builder.GetResult();
        }


        public void SetBuilder(ICarBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder), "Строитель не может быть null.");
        }

        public Car BuildCar()
        {
            return _builder.GetResult();
        }
    }
}