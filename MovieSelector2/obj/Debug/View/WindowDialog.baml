   M S B A M L   `   `   `  ����I  EMovieSelector2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MovieSelector2.ViewMovieSelector2.View  5   	   &     MovieSelector2.View.WindowDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MovieSelector2.View     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	   -   5          �Name$  window��5	   v   $	��120��6   $	��200��6'    � SizeToContent$ WidthAndHeight=�63    � WindowStartupLocation$ CenterOwner=�6R   .��5
      �  � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��2��6   $��
10,10,10,0q�6)   .+�5      �� $
��10,0q�6   $��1q�6#   
�������67   �� 5      $��Center=�60   $��Center=�6M    �� TextAlignment$ Center=�6h   ��6   �� *Tekst+6h   �� 5      $
��10,2q�6   $��1q�6#   
�������67   5      �� 5   
   $��1��6   $��Center=�6   $��Center=�6;   $��60��6V   $��10q�6a   $
��true��6�   ��6m   �� *ClickCommand+.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Ikonki/accept.png��6   $��16��63   $��16��6>   �� 5      $	��TAK��6   $��2q�6'   $��Center=�62   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5         	EventName$ Click��6!   .  (System.Windows.Interactivity.TriggerBase	   Actions.	 5      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction  
   
MethodName$
 Close��6V      TargetObject 6*   ��  �� ElementName$ window��6V   5       5"      �� 5#   
   $��1��6   $��1��6   $��Center=�6.   $��Center=�6K   $��60��6f   $��10q�6q   $��false��6�   ��6}   �� *ClickCommand+.��5$      �� $ 
Horizontal=�6   .+�5%      �� $��Ikonki/cancel.png��6   $��16��63   $��16��6>   �� 5&      $	��NIE��6   $��2q�6'   $��Center=�62   5'       5(        5)      $ Click��6!   .	 5*        $
 Close��6V    6*   �� $ window��6V   5+      5-      5/      50      