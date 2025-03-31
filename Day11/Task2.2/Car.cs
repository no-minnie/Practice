namespace Task22
{
    public class Car
    {
        public string Model { get; set; }
        public string BodyStyle { get; set; }
        public string Engine { get; set; }
        public int Wheels { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return $"Модель: {Model}, Кузов: {BodyStyle}, Двигатель: {Engine}, Колёса: {Wheels}, Цвет: {Color}";
        }
    }
}