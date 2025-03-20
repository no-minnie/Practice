namespace Task1 
{
    public class TimeConverter
    {
        private int days;//поле для хранения количества дней 

        public TimeConverter(int days)
        {
            this.days = days;
        }

        public int GetWeeks() // метод для получения количества полных недель
        {
            return days / 7;
        }
    }
}