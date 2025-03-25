using DelegatesEvents3;
    public class VolumeControl
    {
        private int _volume;

        // событие, которое вызывается при изменении громкости
        public event VolumeChangedEventHandler VolumeChanged;

        public int Volume
        {
            get { return _volume; }
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                    OnVolumeChanged(_volume); //вызов события
                }
            }
        }

        //метод для вызова 
        protected virtual void OnVolumeChanged(int newVolume)
        {
            VolumeChanged?.Invoke(newVolume);
        }
    }
