   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5   	   '    !WpfApp1.Views.BookingDialogWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfApp1.Views     5   	     � SizeToContent$  WidthAndHeight=�5	   	   $	��380��6(   $	��370��67    � WindowStartupLocation$ CenterOwner=�5
   	    � ShowInTaskbar$ False��6-    � 
ResizeMode$ CanResizeWithGrip=�6C    � Title 5   	   �� *WindowTitle+ +� FocusedElement 5   	   ��  �� ElementName$ txtClientName�� � 	Resources 5         DialogBackgroundBrush �� Color-   'WpfApp1.Views.BoolToBackgroundConverter ! ReadOnlyToBackgroundConverter4   .WpfApp1.Views.StringNullOrEmptyToBoolConverter $  StringNullOrEmptyToBoolConverter	 �� 
TargetType
 �� Property �� Value(  "System.Windows.Controls.DatePicker  ErrorTextBlockStyle �� Triggers �� Binding �� 	Converter �� Value��%  &	        &	 #     &	 6     '�� I     '�� �     '  V    '�� �    &	 8    7  �� 5   
   $ 	#FFE6F0FA��68     5   
   6*     5   
   61   �� 5   
   "	 ��6   .�5      �� 
 � ��$ Center=�62   �� 5      
 � ��$ Right=�64   �� 5      
 � ��$ 0,0,5,0q�6'   5      �� 5   
   "	 ��6   .�5      �� 
 � ��$	 0,3q�6'   �� 5      
 � ��$ Center=�69   5      �� 5   
   "	  6   .�5      �� 
 � ��$	 0,3q�6'   �� 5      
 � ��$ Center=�69   5      �� 5   
   "	 ��6   .�5      �� 
 � ��$ 80��6&   �� 5       
 � ��$ 5,0,0,0q�6'   5!      �� 5"   
   "	 ��6,   .�5#      �� 
 � ��
 �  ��6+   �� 5$      
 � ��$
 Wrap=�6-   �� 5%      
 � ��$ 0,10,0,5q�6'   �� 5&      
 � y�$ 	Collapsed=�6+   �� 5'      
 � ��$ 20��6*   �� 5(      
 � ��$	 Top=�62    5)      �� 5*       6   �� *ErrorMessage+8   	 False6|   .a�5+      �� 
 � y�$ Visible=�63   5,      5.      5/      .��51      �� #��[  6    �� Padding$ 15q�6A   ._�52   
   �  � RowDefinitions 53      �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $��* �6    �� 58      $
��Auto �6    .+�5;      �� $��0��6   $��16(�6B   $
��Bold"�6P   $��0,0,0,15q�6b   $��Center=�6t   ��6%   �� *WindowTitle+6t   � 5=      $��1��6    � ColumnDefinitions 5>      �� 5?      $
��Auto �6'   �� 5@      $��* �6'    5B      �� 5C      $
��Auto �6$   �� 5D      $
��Auto �6$   �� 5E      $
��Auto �6$   �� 5F      $
��Auto �6$   .+�5H      �� $��0��6   $��0��6%   $��_Имя клиента:��65    �� Target 6M   �� $ txtClientName���� 5I      -   5         ��Name$ txtClientName��5I   7   $��0��6   $��1��6'   ��6N   �� *
ClientName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5J      $��1��6   $��0��6%   $!��Номер _комнаты:��65    6O   �� $ txtRoomNumber���� 5K      -   5        $ txtRoomNumber��5K   7   $��1��6   $��1��6'   ��6N   �� *
RoomNumber+$ PropertyChanged=� �� 
IsReadOnly 6�   �� *IsRoomNumberReadOnly+��6�   �� *IsRoomNumberReadOnly+# [ �� 5L      $��2��6   $��0��6%   $��_Дата заезда:��65    6M   �� $ dpStartDate��  5M      -   5          Name$ dpStartDate��5M   :   $��2��6   $��1��6*      SelectedDate 6O   �� *	StartDate+$ PropertyChanged=��� 5N      $��3��6   $��0��6%   $��Дата вые_зда:��65    6M   �� $ 	dpEndDate��  5O      -   5        $ 	dpEndDate��5O   :   $��3��6   $��1��6*    6M   �� *	EndDate+$ PropertyChanged=�5P      �� 5R      $��2��6   #��[ 6C   ��6%   �� *ErrorMessage+6C   �� 5T      $��4��6    �� Orientation$ 
Horizontal=�6&   $��Right=�6?   $��Bottom=�6[   $��0,15,0,0q�6v   .+�5U      �� $	��_OK��6    �� 	IsDefault$
 True��6'   ��68   �� *SaveCommand+�� 5V      $��_Отмена��6    �� IsCancel$
 True��6+   ��6;   �� *CancelCommand+5W      5X      5Y      5Z      