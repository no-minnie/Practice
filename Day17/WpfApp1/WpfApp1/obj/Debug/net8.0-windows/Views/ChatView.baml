   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:HotelBookingApp.ViewsHotelBookingApp.Views  5      G(clr-namespace:HotelBookingApp.ViewModelsHotelBookingApp.ViewModels  5      G(clr-namespace:HotelBookingApp.ConvertersHotelBookingApp.Converters  5      $    HotelBookingApp.Views.ChatView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:HotelBookingApp.Views     5      7vm(clr-namespace:HotelBookingApp.ViewModels     5      ?
converters(clr-namespace:HotelBookingApp.Converters     5      $	��200��5   7     � 	Resources  5      9   3HotelBookingApp.Converters.BoolToAlignmentConverter "  SentReceivedAlignmentConverter   SentAlignment   ReceivedAlignment5   /HotelBookingApp.Converters.BoolToBrushConverter # SentReceivedBackgroundConverter   	TrueBrush   
FalseBrush # SentReceivedForegroundConverter  ChatMessageTemplate �� CornerRadius �� Padding �� 	Converter J� Opacity	 �� StringFormat
 �� 
TargetType  ChatSendButtonStyle �� Property �� Value �� 
TargetType ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 /     &	 d     &	 �     7  7   7  7  &	 e      5   
   $ Right=�6U   $
 Left=�6k     5   
    �	#FFE4EAF5 �	#FFF0F2F56h     5   
    �	#FF1F1F1F �	#FF1F1F1F6h   �� 5   
   .R�5      �� $ 8��6�   $
 10,6q�6�   $	��5,4q�6�   $	��300��6
  ��6   �� *IsSentByUser+8   ��6u   �� *IsSentByUser+8  ._�5      �� .+�5      �� $
��Wrap=�69   ��6    �� *	Message+��6M   �� *IsSentByUser+8  �� 5      $��10(�6U   $��Right=�6c   $	 0.7Q�6   $��0,2,0,0q�6�   ��6    �� *	Timestamp+$	 	{0:HH:mm}����6�   �� *IsSentByUser+8  5      5      5      �� 5   
   "
 ��6   .�5      ��  � ��$
 12,6q�6(   �� 5       � ��$ 0q�6'   �� 5       � ��$ 13(�6)   �� 5       � �� �	#FFC5C6E06+   �� 5       � �� �	#FF2F2F2F6+   �� 5       � ��$ 0q�60   �� 5        � ��$ 80��6)   �� 5!       � ��$ 32��6*   �� 5"       �@�Cursor$
 Hand��6'   �� 5#       � �� 5$      �� 5%      " ��6&   .R�5&      �� $ border��6!   #��z��61   $ 4��6[   ._�5'      �� $��Center=�6/   $��Center=�6L   #��z��6g   5(       5)      P� 5*       �@J�IsMouseOver$
 True��6=   . �5+   "   �� $ border��6)    � �� �	#FFD5D6E86S   5,      P� 5-       � ��$
 True��6;   . �5.   "   �� $ border��6)    � �� �	#FFB5B6D06S   5/      P� 50       � {�$ False��6;   . �51   "   �� $ border��6)    � �� �	#FFD8DAE26S   �� 52   "    � �� �	#FF9090906?   53      55      57      58      59      .��5:      � 
������� � RowDefinitions 5;   
   �� 5<      $
��Auto �6   �� 5=      $��* �6   �� 5>      $
��Auto �6   .+�5@   
   �� $��0��6    �� Padding$	 5,3q�6C   ���	#FFF5F7FA���	#FF607080 �� TextAlignment$ Center=�6   $��11(�6�   ��6!   �� *ConnectionStatus+6�   �� 5A   
   -   5         ��Name$ MessagesListBox��5A      $��1��6   #��[ 6Y   $��0q�6�   $��Disabled=�6�   $��Stretch=�6�   ��68   �� *
Messages+��5B      �� 5C      "
 ��6   .�5D      ��  � ��$ 0q�60   �� 5E       � ��$ 0q�6/   �� 5F       � �� 5G      �� 5H      " ��6.   .R�5I   "   �� 5J      5L      5M      5O      �� 5P   
   $��2��6   ���	#FFE0E0E0$��0,1,0,0q�66   $ 8q�6P   ._�5Q      � {�6   �� *IsConnected+ � ColumnDefinitions 5R      �� 5S      $��* �6'   �� 5T      $
��Auto �6'   .+�5V      �� -   5         ��Name$ MessageInput��5V   *   $��0��6    �� AcceptsReturn$ False��6�    �� TextWrapping$
 Wrap=�6�   $��80��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $��0,0,8,0q�6�   $��Center=�6�   $��13(�6  $	��5,4q�6"  ���	#FFD0D0D0��6@   �� *CurrentMessage+ �� UpdateSourceTrigger$ PropertyChanged=�.��6H   J� InputBindings 5W      �� 5X      
 �� Key$ Enter��6%    �� Command 61   �� *SendCommand+.��5Y   -   5Z      �� 5[      $��1��6   $��Отправить��6)   #��[ 6]   ��6=   �� *SendCommand+6]   5\      5]      5^      5_      