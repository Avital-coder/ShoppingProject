   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   !localclr-namespace:WpfApp1  5   	     � Title$  Shopping��5	   	   $	��450��6   $	��800��6'    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowState$ 	Maximized=�5   	    � Icon$( "/WpfApp1;component/Images/logo.ico��5   	   ��5      �� 5   
    �� Opacity$	 0.9Q�6   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.1* �6    �� 5      $
��100* �6   �� 5      $
��0.1* �6    � RowDefinitions 5   
   �� 5      �� 5      $	��23* �6   �� 5      $��2* �6   �� 5      $
��386* �6   �� 5      $��8* �6   .+�5!   
   � $��1��6   $��1��6   
�������$��2��6?   $��0.2,0.2,0.6,1q�6S    5#      �� 5$      $	��50* �6#   �� 5%      $	��50* �6#   �� 5&      $
��0.1* �6#   .+�5)      � $��0��6   $��Center=�6#   $
��Left=�6>   
������  5+      �� 5,      $��1* �6'   �� 5-      $��1* �6'   �� 5.      $��1* �6'   .+�51      �� $��1��6   $��
ExtraBlack"�6R   $��Center=�6j    #  roundedCornersButtonTransparent#��[  6�   
���   �$��2��6�   $��0,-4,82.4,-4.8q�6�   ��6)   �� *DisplayContactUsView+.��52      �� $��
Contact Us��6    53      �� 55      $��3��6   $��
ExtraBlack"�6N   $��Center=�6f   #��[  6�   ��6)   �� *DisplayLoginView+.��56      �� $��Log In��6    57      59      � 5;      $��1��6   $��Center=�6#   
������  5=      �� 5>      $��1* �6'   �� 5?      $��1* �6'   �� 5@      $��1* �6'   �� 5A      $��1* �6'   5E      5G      � 5I   
   $��3��6   $��1��6   $��2��6,   $��0.2,0.6,0.6,0q�6@   .+�5K      �� $��
0,10,0,0.2q�6w   ��6   ��  �� Path$ Currents.CurrentViewModel� �� Current	 �� Source#	 Z 6w   5M      5O      5Q      