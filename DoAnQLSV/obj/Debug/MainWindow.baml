   M S B A M L   `   `   `  ����C  ?DoAnQLSV, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DoAnQLSVDoAnQLSV  5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466J6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPFFontAwesome.WPF 5   	       DoAnQLSV.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:DoAnQLSV     5   	   Efa6clr-namespace:FontAwesome.WPF;assembly=FontAwesome.WPF     5   	   -   5          � Title$  Quản Lý Sinh Viên��5	   	   $	��700��6#   $
��1210��60    � AllowsTransparency . 
������  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $��r0c0i Linotte)�5   	    � Icon$ ./Images/6.png��5   	   .��5      ��  �� CornerRadius$ 10��6   }�. ._�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��4* �6#   .+�5      �� ���#132c33$ 	10,0,0,10��6*   ._�5      �  � RowDefinitions 5       �� 5!      �� 5"      $��4* �6(   .+�5%      �� $��2��6   5'      �� 5+       �� Orientation$ 
Horizontal=�6!   .+�5,      �� ���#fff$��60��63   $��60��6>   $
 1000��6J   $��25, 0, 0, 0q�6^   ._�5-      �� $��./Images/6.png��6$   $��60��6<   5.      �� 5/      $��
10,55,0,55q�6$   $��MY CLASS��50       $��Center=�51       $��25(�52       $��Heavy"�53       ���#fff54       55      �� 59      $��1��6!   .+�5;      �� -   5        	 ��Name$	 btnLop��5;   !   $��	0,20,0,20q�61      ButtonToolLeftMenu#��[  6D   ��5<      �� 5=   "   $ 
Horizontal=�6-   .+�5>   &   "  FontAwesome.WPF.ImageAwesome  $��0, 0 , 20, 0q�66   
   Icon$
 Group=�6L   $��20��6Y   $
��Left=�6d      
Foreground �#fff6   �� 5?   &   $��Lớp��60   $��Center=�6;   $��20(�6V   ���#fff6d   5@   #   5B      �� 5D      -   5        $	 	btnGhiChu��5D   !   $��	0,20,0,20q�64   #��[  6G   ��5E      �� 5F   "   $ 
Horizontal=�6-   .+�5G   &     $��0, 0 , 20, 0q�66   $
 AddressBook=�6L   $��20��6_   $
��Left=�6j    �#fff6�   �� 5H   &   $��Ghi Chú��60   $��Center=�6?   $��20(�6Z   ���#fff6h   5I   #   5K      �� 5M      -   5        $	 	btnCaiDat��5M   !   $��	0,20,0,20q�64   #��[  6G   ��5N      �� 5O   "   $ 
Horizontal=�6-   .+�5P   &     $��0, 0 , 20, 0q�66   $	
 Cog=�6L   $��20��6W   $
��Left=�6b    �#fff6}   �� 5Q   &   $��Cài Đặt��60   $��Center=�6?   $��20(�6Z   ���#fff6h   5R   #   5T      �� 5V      -   5        $	 btnDangXuat��5V   !   $��	0,20,0,20q�66   #��[  6I   ��5W      �� 5X   "   $ 
Horizontal=�6-   .+�5Y   &     $��0, 0 , 20, 0q�66   $
 SignOut=�6L   $��20��6[   $
��Left=�6f    �#fff6�   �� 5Z   &   $��Đăng Xuất��60   $��Center=�6A   $��20(�6\   ���#fff6j   5[   #   5]      5_      5a      5b      �� 5h      -   5         ��Name$ backgroundMain��5h   S   ���#d9fce8$��1��6*   $ 	0,14,14,0��6:   ._�5j      �  5k      �� 5l      $��* �6(   �� 5m      $	��15* �6(   .+�5r      �� $ 
Horizontal=�6!   $��Right=�6:   .+�5s      �� -   5        $	 btnMinimize��5s   !     ButtonToolTopTheme#��[ 66   $��
0, 0, 5, 0q�5t      ���#fff2005x      �� 5z      -   5        $	 btnMaximize��5z   !   #��[ 66   $��
0, 0, 5, 0q�5{      ���#32ff7e5~      �� 5�      -	   5        $	 btnExit��5�   !   #��[ 62   $��0, 0, 15, 0q�5�      ���#ff4d4d5�      5�      �� 5�      $��1��6   $ 10, 10, 10, 10��6*   $��
20,0,15,15q�6H   ._�5�      �� ��6)   �� 5�      5�      5�      5�      5�      5�      