using DelegatesEvents3;
    class Program
    {
        static void Main(string[] args)
        {
            // объекты
            VolumeControl volumeControl = new VolumeControl();
            Display display = new Display();
            SpeakerSystem speakerSystem = new SpeakerSystem();

            // обработчики на событие
            volumeControl.VolumeChanged += display.ShowVolume;
            volumeControl.VolumeChanged += speakerSystem.AdjustVolume;

            //и зменяем громкость, что вызывает событие
            volumeControl.Volume = 50;
            volumeControl.Volume = 100;

            Console.ReadKey(); 
        }
    }
