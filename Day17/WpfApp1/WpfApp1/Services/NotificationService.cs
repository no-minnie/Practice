using System.IO.MemoryMappedFiles;
using System.Text;

namespace HotelBookingApp.Services
{
    public class NotificationService
    {
        private MemoryMappedFile _mmf;
        private MemoryMappedViewAccessor _accessor;

        public NotificationService()
        {
            _mmf = MemoryMappedFile.CreateOrOpen("HotelNotifications", 1024);
            _accessor = _mmf.CreateViewAccessor();
        }

        public void SendNotification(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            _accessor.WriteArray(0, buffer, 0, buffer.Length);
        }

        public string ReadNotification()
        {
            byte[] buffer = new byte[1024];
            _accessor.ReadArray(0, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer).TrimEnd('\0');
        }

        public void Dispose()
        {
            _accessor?.Dispose();
            _mmf?.Dispose();
        }
    }
}