   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      '    !WpfApp1.Views.PriceComparisonView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Views     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6O   ��5      �� 5   
     �� Opacity$
  0.18Q�6    �� ImageSource$. (/WpfApp1;component/Images/background.png��6$   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��169* �6   �� 5      $
��414* �6   �� 5      $��9* �6   �� 5      $	��94* �6   �� 5      $	��10* �6   �� 5      $
��104* �6    � RowDefinitions 5   
   �� 5      $	��84* �6   �� 5      $��0* �6   �� 5      $
��214* �6   �� 5      $
��146* �6   �� 5      $��5* �6   .+�5!   
      WpfApp1.Views.SideBarView  $��5��6   $��0��6-   $��6��6=    K� ZIndex$ 1��6Q   $��-11,0,3,-3.4q�6b   �� 5#   
   $��0��6   $��
ExtraBlack"�6!   $#��Choose QR code to see details��69   $��Center=�6^   $��28(�6y   $��Center=�6�   $ 0��6�   $��60��6�   $��167,23,78.4,1q�6�   $	��441��6�   $��4��6�   �� 5$   
   $��0��6   $��2��6"   $ 0��62   $��	0.8,0,3,1q�6C   .+�5%      �� $�� ��6   $��Center=�6    $��15(�6;   $��Center=�6I   $
��Wrap=�6f    �� TextAlignment$ Center=�6z   $��LeftToRight=�6�   5&      � 5(   
   
�������$��2��6"    J� Opacity$	 0.7Q�63   $��2��6A   $��109.2,0,168.2,94.8q�6N   $��1��6j   .+�5)      �� -   5        $��FileNameTextBox��5*   >   $
��Left=�5)      $��43��61   $��	30,10,0,0q�6=    �� TextWrapping$
 Wrap=�6P   $�� ��5*      $	��Top=�6   $	��282��62   6>   �� 5+      -   5         ��Name$ BrowseButton��5+      $��Browse a file��6+   $
��Left=�6C   $��
339,13,0,0q�5,      $	��Top=�6%   $	��118��6=   	 J� RenderTransformOrigin$	 1.047,0.821&�5-      $��40��65   �� 5.      $
��Left=�6   $��47��63   $��	30,90,0,0q�6?   $
��Wrap=�5/      $��Product Name:��6(   $��13(�6=   $��
ExtraBlack"�6K   $	��Top=�6c   $	��102��50      �� 51      -   5        $��
TextBlock1��53       $
��Left=�51      $��13(�64   $��47��6B   $��132,90,-276,0q�6N   $
��Wrap=�52      $�� ��6(   $	��Top=�60   $	��281��53      6    �� 54      $
��Left=�6   $��47��63   $��13(�6@   $��
ExtraBlack"�6N   $��
30,140,0,0q�6f   $
��Wrap=�55      $��Description:��6(   $	��Top=�6<   $��85��56      �� 57      -   5        $��
TextBlock2��59       $
��Left=�57      $��13(�63   $��51��6A   $��132,140,0,-22q�6M   $
��Wrap=�58      $�� ��6(   $	��Top=�60   $	��282��59      6    �� 5:      $
��Left=�6   $��47��63   $��13(�6@   $��
ExtraBlack"�6N   $��
30,190,0,0q�6f   $
��Wrap=�5;      $��
Shop Name:��6(   $	��Top=�6:   $��86��5<      �� 5=      -   5        $��
TextBlock3��5?       $
��Left=�5=      $��13(�63   $��45��6A   $��132,190,0,-66q�6M   $
��Wrap=�5>      $�� ��6(   $	��Top=�60   $	��330��5?      6    �� 5@      $
��Left=�6   $��47��63   $��13(�6@   $��
ExtraBlack"�6N   $��30,240,0,-112q�6f   $
��Wrap=�5A      $��Branch:��6(   $	��Top=�67   $��75��5B      �� 5C      -   5        $��
TextBlock4��5E       $
��Left=�5C      $��13(�63   $��39��6A   $��132,240,0,-104q�6M   $
��Wrap=�5D      $�� ��6(   $	��Top=�60   $	��328��5E      6    �� 5F      $
��Left=�6   $��47��63   $��13(�6@   $��
ExtraBlack"�6N   $��30,290,0,-158q�6f   $
��Wrap=�5G      $��Price:��6(   $	��Top=�66   $��75��5H      �� 5I      -   5        $��
TextBlock5��5K       $
��Left=�5I      $��13(�63   $��43��6A   $��132,290,0,-152q�6M   $
��Wrap=�5J      $�� ��6(   $	��Top=�60   $	��333��5K      6    �� 5L      -   5        $��
TextBlock6��5L      $
��Fill=�6&   $	��Top=�65   $	��110��6M   $
��Left=�6Y   $	��100��6t   $��30,320,0,-200q�6�   5N      5O      5P      