using HotelBookingApp.Models;
using Newtonsoft.Json;
using System.IO;

namespace HotelBookingApp.Services
{
    public class DataService
    {
        private readonly string _dataFilePath = "hotel_data.json";

        public HotelData LoadHotelData()
        {
            if (File.Exists(_dataFilePath))
            {
                string json = File.ReadAllText(_dataFilePath);
                return JsonConvert.DeserializeObject<HotelData>(json) ?? new HotelData();
            }
            return new HotelData();
        }

        public void SaveHotelData(HotelData data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_dataFilePath, json);
        }
    }
}