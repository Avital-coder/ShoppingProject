   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5          WpfApp1.Views.ContactView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Views     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  68   ��5	      �� 5
   
     �� Opacity$	  0.2Q�6    �� ImageSource$. (/WpfApp1;component/Images/background.png��6#   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.3* �6   �� 5      $
��3.2* �6   �� 5      $
��0.5* �6   �� 5      $
��1.5* �6   �� 5      $
��0.5* �6   .+�5   
   � $��1��6   $��78.2,32,151.2,-32.4q�6    $��3��6=    � RowDefinitions 5      �� 5      $
��0.8* �6    �� 5      $��1* �6    �� 5      $
��0.5* �6    �� 5      $
��0.4* �6    �� 5      $
��0.1* �6    �� 5      $
��0.5* �6    �� 5      $
��0.1* �6    �� 5      $��1* �6    �� 5       $
��0.5* �6    �� 5!      $
��0.1* �6     5$      �� 5%      $��1* �6#   �� 5&      $
��1.5* �6#   �� 5'      $��1* �6#   .+�5*      �� $��0��6   $��Center=�6%   $��Center=�6@   $��Call us��5+      $��45(�6'      textFont#��[  65   $
��Bold"�6W   $��0,46,12.8,62.4q�6i   $��2��6�   $	��144��6�   $��1��6�   �� 5-      $��Center=�6   $��Center=�63   $
��Wrap=�5.       �� TextAlignment$ Center=�6,   $��We want to hear from you!��5/      $��25(�69   #��[  6G   $
��Bold"�6i   $��1��6{   $��3��6�   $��10,46,9.8,21.2q�6�   $	��345��6�   $��68��6�   $��2��6�   �� 50      $��Center=�6   $��Center=�63   $
��Wrap=�51      $ Center=�6,   $7��1Please choose your preferred way of contact below��52      $��22(�6Q   #��[  6_   $
��Bold"�6�   $��2��6�   $��-60,23.6,-60.2,4.2q�6�   $��2��6�   $��3��6�   $	��485��6�   �� 53      $��Center=�6   $��Center=�63   $
��Wrap=�54      $ Center=�6,   $#��Feel free to call any time :)��55      $��22(�6=   #��[  6K   $
��Bold"�6m   $��3��6   $��-60,25,-60.2,11.6q�6�   $��3��6�   $��3��6�   $	��485��6�   �� 57        MaterialDesignIconButton#��[ 6   $	��100��6G   $	��100��6T   $��2��6|   $��42,0,118.8,52q�6�   $��4��6�   $��4��6�   ��6`   �� *	Calling+.��59      '  !MaterialDesignThemes.Wpf.PackIcon  $��70��6*   $��70��66      Kind$ Phone=�6A   ���#EC55786e   5:      �� 5<      #��[ 6   $	��100��6G   $	��100��6T   $��2��6}   $��1��6�   $��91,0,69.8,52q�6�   $��4��6�   $��4��6�   ��6`   �� *
Emailing+.��5=        $��70��6*   $��70��66   $ Email=�6A   ���#EC55786e   5>      5?      5C      5E      