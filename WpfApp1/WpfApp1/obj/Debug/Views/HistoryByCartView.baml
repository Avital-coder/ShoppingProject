   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 6�   %    WpfApp1.Views.HistoryByCartView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  69   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  6�   ��5      �� 5   
     �� Opacity$
  0.18Q�6    �� ImageSource$. (/WpfApp1;component/Images/background.png��6$   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $
��0.1* �6   �� 5      $
��0.9* �6   �� 5      $
��0.1* �6   �� 5      $
��0.1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��0.1* �6   �� 5      $��7* �6   �� 5       $
��0.1* �6   �� 5!      $��1* �6   .+�5$   
      WpfApp1.Views.SideBarView  $��5��6   $��0��6-   $��9��6=    K� ZIndex$ 1��6Q   $��
0,0,0,-0.4q�6b   �� 5&   
   $��0��6   $��2��6!   $��Your products over time��61   $��
ExtraBlack"�6P   $��Center=�6h   $��30(�6�   $��Center=�6�   $ 0��6�   $��73.8,4,29.2,4.8q�6�   $��2��6�   $	��397��6�   �� 5'   
   $��0��6   $��1��6"   $��3��62   $��10.4,0,369.2,342q�6F   $��3��6`   .+�5(      �� $�� ��6   $��Center=�6    $��15(�6;   $��Center=�6I   $
��Wrap=�6f    �� TextAlignment$ Center=�6z   $��LeftToRight=�6�   �� 5)      $��How many months ago?��6   $	��Top=�64   $��15(�6L   $
��Left=�6Z   $
��Wrap=�6u   $ Center=�6�   $��LeftToRight=�6�   �� 5*      $��20(�6?   $	��Top=�6M   $
��Left=�6e   $��LeftToRight=�6�   $��44��6�   $	��160��6�   ��6   �� *NumOfMonthsList+ �� SelectedItem 6�   �� *NumberOfMounths+6�   5+      � 5.   
   $��2��6   $��2��6   $��2��63   
������� J� Opacity$	 0.7Q�6T   $��99.8,0.4,10.2,0q�6b   .+�5/      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6w   	   Series	 6!   �� *SeriesCollection+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   AxisY 51        LiveCharts.Wpf.Axis     Title$ 	Cart size��6      FontSize$ 14Q�61      
FontWeight$ 
ExtraBlack"�6?      LabelFormatter 6W   �� *
YFormatter+$
 TwoWay=�$ PropertyChanged=�6�      AxisX 54        $ Month��6   $ 14Q�6-   $ 
ExtraBlack"�6;      Labels 6S   �� *Labels+$
 TwoWay=�$ PropertyChanged=�6�   56      57      59      5:      