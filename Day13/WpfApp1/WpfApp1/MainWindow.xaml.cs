using System.Windows;

namespace HotelBookingWPF
{
    public partial class MainWindow : Window
    {
        private List<Room> rooms = new List<Room>();
        private int? selectedRoomNumber = null;
        public MainWindow()
        {
            InitializeComponent();

            rooms.Add(new Room { RoomNumber = 101, RoomType = "Одиночный", Price = 50.00m });
            rooms.Add(new Room { RoomNumber = 102, RoomType = "Двойной", Price = 80.00m });
            rooms.Add(new Room { RoomNumber = 201, RoomType = "Люкс", Price = 150.00m });
            rooms.Add(new Room { RoomNumber = 202, RoomType = "Люкс", Price = 160.00m });
            rooms.Add(new Room { RoomNumber = 301, RoomType = "Семейный", Price = 200.00m });
            rooms.Add(new Room { RoomNumber = 302, RoomType = "Семейный", Price = 210.00m });

            roomsDataGrid.ItemsSource = rooms;
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fullNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите ФИО.", "Ошибка");
                return;
            }

            if (checkInDatePicker.SelectedDate == null || checkOutDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Пожалуйста, выберите даты заезда и выезда.", "Ошибка");
                return;
            }

            if (checkInDatePicker.SelectedDate > checkOutDatePicker.SelectedDate)
            {
                MessageBox.Show("Дата заезда должна быть раньше даты выезда.", "Ошибка");
                return;
            }

            if (checkInDatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Дата заезда не может быть в прошлом.", "Ошибка");
                return;
            }

            Room selectedRoom = roomsDataGrid.SelectedItem as Room;

            if (selectedRoom == null)
            {
                MessageBox.Show("Пожалуйста, выберите номер комнаты.", "Ошибка");
                return;
            }

            selectedRoomNumber = selectedRoom.RoomNumber;

            string fullName = fullNameTextBox.Text;
            DateTime checkInDate = (DateTime)checkInDatePicker.SelectedDate;
            DateTime checkOutDate = (DateTime)checkOutDatePicker.SelectedDate;

            MessageBox.Show($"Бронирование для {fullName} номера {selectedRoomNumber} с {checkInDate:d} по {checkOutDate:d} успешно выполнено!", "Подтверждение");
        }
    }
}