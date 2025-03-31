namespace Task22
{
    public class SedanBuilder : ICarBuilder
    {
        private Car _car = new Car();

        public void SetModel(string model)
        {
            _car.Model = model;
        }

        public void SetBodyStyle(string bodyStyle)
        {
            _car.BodyStyle = bodyStyle;
        }

        public void SetEngine(string engine)
        {
            _car.Engine = engine;
        }

        public void SetWheels(int wheels)
        {
            _car.Wheels = wheels;
        }

        public void SetColor(string color)
        {
            _car.Color = color;
        }

        public Car GetResult() { return _car; }
    }
}