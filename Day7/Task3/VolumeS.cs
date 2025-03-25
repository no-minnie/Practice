namespace DelegatesEvents3
{
    public class Display
    {
        //обработчики события изменения громкости
        public void ShowVolume(int newVolume)
        {
            Console.WriteLine($"Уровень громкости: {newVolume}");
        }
    }

    public class SpeakerSystem
    {
        public void AdjustVolume(int newVolume)
        {
            Console.WriteLine($"Динамики настроены на громкость: {newVolume}");
        }
    }
}