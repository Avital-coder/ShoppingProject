   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 6�   %    WpfApp1.Views.HistoryByShopView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  68   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  6�   ��5
      �� 5   
     �� Opacity$
  0.18Q�6    �� ImageSource$. (/WpfApp1;component/Images/background.png��6$   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��0.3* �6   �� 5      $
��0.5* �6   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $
��0.1* �6   �� 5      $
��0.9* �6   �� 5      $
��0.1* �6   �� 5      $
��0.1* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��0.1* �6   �� 5      $��7* �6   �� 5      $
��0.1* �6   �� 5       $��1* �6   .+�5#   
      WpfApp1.Views.SideBarView  $��5��6   $��0��6-   $��9��6=    K� ZIndex$ 1��6Q   $��
0,0,0,-0.4q�6b   �� 5%   
   $��0��6   $��2��6!   $"��Your visited shops over time��61   $��
ExtraBlack"�6U   $��Center=�6m   $��30(�6�   $��Center=�6�   $ 0��6�   $��74,4,72,4.8q�6�   $��4��6�   $	��454��6�   �� 5&   
   $��0��6   $��1��6"   $��3��62   $��10.4,0,369.2,342q�6F   $��3��6`   .+�5'      �� $�� ��6   $��Center=�6    $��15(�6;   $��Center=�6I   $
��Wrap=�6f    �� TextAlignment$ Center=�6z   $��LeftToRight=�6�   �� 5(      $��How many months ago?��6   $	��Top=�64   $��15(�6L   $
��Left=�6Z   $
��Wrap=�6u   $ Center=�6�   $��LeftToRight=�6�   �� 5)      $��20(�6?   $	��Top=�6M   $
��Left=�6e   $��LeftToRight=�6�   $��44��6�   $	��160��6�   ��6   �� *NumOfMonthsList+ �� SelectedItem 6�   �� *NumberOfMounths+6�   5*      � 5,   
   $��2��6   $��5��6   $��Center=�6-   $	��Top=�6J   $ 0��6b    5-      �� 5.      $��1* �6    �� 5/      $
��0.1* �6    �� 50      $��7* �6    .+�52      �� $��Which shops?��6   $��Center=�6,   $��15(�6G   $��Center=�6U   $
��Wrap=�6r   $ Center=�6�   $��LeftToRight=�6�   $��-2,-4,1.6,4q�6�   �� 53      �� 54      -   5         ��Name$ listView��54      $��2��6*   $��Stretch=�6u   $��Stretch=�6�   $��LeftToRight=�6�   $��0,0,-0.4,-303q�6�   ��67   �� *
ShopList+ �� NotifyOnSourceUpdated . ��55      �� 56      .R�57      �� $��Stretch=�6%   $��Stretch=�6A   	 �� Orientation$	 
Horizontal=�6_   .+�58      �� $��Right=�6'   $��Stretch=�6C   ��6_   �� 
 �� ElementName$
 listView�� �� Path$$ DataContext.UpdateGraphCommand���6�   �� �� 59      $�� ��6(   �� 5:      $��15(�69   $
��Left=�6G   $��Stretch=�6b   ��6(   �� 6b   5;      5<      5>      5?      � 5B   
   $��2��6   $��2��6   $��2��63   
������� J� Opacity$	 0.7Q�6T   $��99.8,0.4,10.2,0q�6c   .+�5C      #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�6w      Series 6!   �� *SeriesCollection+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�   AxisY 5E        LiveCharts.Wpf.Axis     Title$
 Shop��6      FontSize$ 14Q�6,      LabelFormatter 6:   �� *
YFormatter+$ TwoWay=�$ PropertyChanged=�6�      AxisX 5H        $ Month��6   $ 14Q�6-      Labels 6;   �� *Labels+$ TwoWay=�$ PropertyChanged=�6�   5J      5K      5M      5N      