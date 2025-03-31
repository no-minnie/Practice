namespace Task3
{
    using System;
    using System.Collections.Generic;
    using Task3;

    public class SmartHomeHub
    {
        private List<IDevice> _devices = new List<IDevice>();
        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                NotifyDevices(); 
            }
        }

        public void Attach(IDevice device)
        {
            _devices.Add(device);
        }

        public void Detach(IDevice device)
        {
            _devices.Remove(device);
        }

        private void NotifyDevices()
        {
            foreach (var device in _devices)
            {
                device.Update(State);
            }
        }
    }
}