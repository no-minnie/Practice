   M S B A M L   `   `   `  ����  WpfApp1     HotelBookingWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Hotel Booking WPF��5   	   $	��450��6#   $	��800��60   ���#E0FFFF.��5      �  � ColumnDefinitions 5	   
   �� 5
      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ roomsDataGrid��5         AutoGenerateColumns$ False��6*   $��10q�6F   $��0��6R      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *
RoomNumber+6S     5      $ Тип��6%   $ * 6O    62   �� *
RoomType+6O     5      $ Цена��6%   $
 Auto 6]    63   �� *Price+ �� StringFormat$ C��6]   5      �� 5   
   $��1��6   $��10q�6%   .+�5      �� $��Бронирование��6   $
��Bold"�6+   $��16(�6=   �� 5      $��ФИО:��6   �� 5      -   5        	 ��Name$	 fullNameTextBox��5      $	��200��6/   �� 5      $��Дата заезда:��6   (  "System.Windows.Controls.DatePicker  5      -   5        
  Name$
 checkInDatePicker��5      $	��200��64   �� 5      $��Дата выезда:��6     5      -   5        $
 checkOutDatePicker��5      $	��200��65   �� 5      -   5         ��Name$ 
bookButton��5      $ ��Забронировать��6)   ���#FFDAB96Z   5      5      5      