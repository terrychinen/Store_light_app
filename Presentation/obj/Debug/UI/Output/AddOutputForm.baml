   M S B A M L   `   `   `  ����G  CPresentation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Presentation.UI.OutputPresentation.UI.Output  5   	   *    $Presentation.UI.Output.AddOutputForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   0local$clr-namespace:Presentation.UI.Output  5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6<     � Title$  Crear salida��5	   	   $	��600��6   $	��800��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��0��6   $��CREAR SALIDA��6   $��23(�64   $��Center=�6B   6a   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��2* �6#   60   �� 5      $��* �6#   6/   �� 5      $��2* �6#   60   .+�5      �� $��0��6   $��	Almacén:��6$   $��18(�67   $��20, 15, 0, 0q�6E   6]   �� 5      -   5        $��cb_store��5   '   $��1��6   $��0, 0, 0, 30q�67   $	��200��6L    �� 
IsEditable .  �� Text$ Seleccione el almacén��6j   $
��Left=�6�   �� 5"      $��2��6   $��	Ambiente:��6$   $��18(�68   $��20, 15, 0, 0q�6F   �� 5#      -   5        $��cb_environment��5#   '   $��3��6   $��0, 0, 0, 30q�6=   $	��200��6R    . $ Seleccione el ambiente��6p   $
��Left=�6�   5%      � 5'   
   $��2��6    5(      �� 5)      $��3* �6#   60   �� 5*      $��5* �6#   60   �� 5+      $��* �6#   6/   �� 5,      $��3* �6#   60   �� 5-      $��6* �6#   60   .+�50      �� $��0��6   $��Mercancía:��6$   $��18(�69   $��20, 15, 0, 0q�6G   6_   �� 51      -   5        $��cb_commodity��51      $��0, 0, 0, 20q�6+   $	��200��6@   -  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation$
 None=�6�    �� IsTextSearchEnabled .  $��1��6�    . $��30��6�   �� 53      -   5        $��lb_stock��53      $��3��6$   $��Stock:��64   $��16(�6E   $��30, 15, 0, 0q�6S   $
��Left=�6i   �� 55      $��4��6   $��	Cantidad:��6$   $��18(�68   $��30, 15, 0, 0q�6F   �� 56      -   5        $��txt_quantity��56      $��5��6*   $��20, 0, 0, 30q�6:   $��50��6P   $��28��6[   57      � 59   
   $��3��6    5:      �� 5;      $��* �6#   6/   �� 5<      $��2* �6#   60   �� 5=      $��* �6#   6/   �� 5>      $��2* �6#   60   .+�5A      �� $��0��6   $��Entrega:��6$   $��18(�67   $��20, 15, 0, 0q�6E   6]   �� 5B      -   5        $��cb_employee_gives��5B   '   $��1��6   $ Seleccione el empleado��6@   $��0, 0, 0, 30q�6^   $	��200��6s    . $
��Left=�6�   �� 5E      $��2��6   $��Recibe:��6$   $��18(�66   $��30, 15, 0, 0q�6D   �� 5F      -   5        $��cb_employee_receives��5F   '   $��3��6   $ Seleccione el empleado��6C   $��0, 0, 0, 30q�6a   $	��200��6v    . $
��Left=�6�   5H      � 5J   
   $��4��6    5K      �� 5L      $
��0.8* �6#   62   �� 5M      $��* �6#   6/   �� 5N      $
��0.5* �6#   62   �� 5O      $��2* �6#   60   .+�5S      �� $��0��6   $��Fecha Salida: ��6$   $��18(�6=   $��20, 30, 0, 0q�6K   6c   &   Xceed.Wpf.Toolkit.DateTimePicker  5U      -   5        $��	txt_order��5U   "   $��1��63   ,  &Xceed.Wpf.Toolkit.Primitives.InputBase	   TextAlignment$
	 left=�6C   &   Xceed.Wpf.Toolkit.DateTimeUpDown
   Format$
 Custom=�6X   $��30��6h      FormatString$ dd/MM/yyyy HH:mm:ss��6t   �� 5W      $��2��6   $��Lote:��6$   $��18(�64   $��30, 15, 0, 0q�6B   $
��Left=�6Y   �� 5X      -	   5         ��Name$ txt_message��5X   m   $��3��6   
�������$��0, 0, 20, 0q�6@   $	��400��6U   $��90��6a    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn .  �� 
AcceptsTab . 6�   5Y      �� 5[   
   -
   5        $��5��5[      $��
0, 0, 0, 0q�6   $	��220��63   $��40��6?   $��Crear��6K   $��Center=�6\   6�   5]      5^      