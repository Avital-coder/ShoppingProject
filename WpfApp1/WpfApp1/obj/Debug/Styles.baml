   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5      7 clr-namespace:WpfApp1.ConvertorsWpfApp1.Convertors  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a  �� 
TargetType   ComboBoxTrigger  MaterialDesignComboBox �� BasedOn �� Triggers �� Binding �� ElementName �� Path �� Value �� Property �� Value  roundedCornersBorder  textFont # roundedCornersButtonTransparent " MaterialDesignRaisedDarkButton+   %MaterialDesignThemes.Wpf.ButtonAssist+  %MaterialDesignThemes.Wpf.ShadowAssist  roundedCornersButton  roundedCornersButtonBase  textBoxInError	 P� Property
 P� Value �� Self �� RelativeSource 	 
ShapeStyle 
 validationTemplate�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      FmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      localclr-namespace:WpfApp1  5      ,Convert clr-namespace:WpfApp1.Convertors  5      %*  &	        7  &	 �     &	 x    &	 �    7  &	 �    7  &	 �    7  &	 �    &		 �    &	
 N    �� 5      "  ��6   8    5   
   �� 5	       6   �� $ 	ItemsList��$ SelectedIndex� -16X   .a�5
      ��  � {� .  67   5      5      �� 5      "  ��6   .�5   
   ��  �@��CornerRadius$ 20��6)   �� 5   
    � ��$ 6q�6,   �� 5   
    �@J�Opacity$	 0.7Q�6$   �� 5   
    � ��
 �����6'   5      �� 5      "  ��6   .�5   
   ��  � ��$3 -/CareManagment;component/Fonts/Heebo-Bold.ttf)�6'   5      �� 5      "  ��6   8   .�5   
   ��  �@  CornerRadius$ 20��6E   �� 5   
    � ��$ 0q�6,   �� 5   
    �@ ShadowDepth$ Depth0=�6D   �� 5   
    � ��
 �   �6'   �� 5    
    � ��
 ���� 6'   5!      �� 5#      "  ��6   8   .�5$   
   ��  �@  CornerRadius$ 20��6E   �� 5%   
    � ��$ 0q�6,   �� 5&   
    �@ ShadowDepth$ Depth0=�6D   �� 5'   
    � �� �#EC55786'   �� 5(   
    � ��
 �   �6'   5)      �� 5+      "  ��6   8   .�5,   
   ��  �@  CornerRadius$ 20��6E   �� 5-   
    � ��$ 0q�6,   �� 5.   
    �@ ShadowDepth$ Depth0=�6D   �� 5/   
    � �� �#42A5F56'   �� 50   
    � ��
 �����6'   51      �� 53      "  ��6#    55   
   P� 56      	 �@=�HasError
 . . �57      ��  �@�ToolTip 6,   �� # Z $&  (Validation.Errors)/ErrorContent�58      5:      �� 5=      "  F�6   .�5>   
   ��  � �� �	#FF5B9BD56!   �� 5?   
    �@��Stretch$
 Fill=�6$   �� 5@   
    � �� �	#FFEDF1F66#   5A      �� 5C      .R�5D   
   ]� .+�5E      �� 
���  ��$��20(�6)   !6:   �� 5F      5G      5H      5L      