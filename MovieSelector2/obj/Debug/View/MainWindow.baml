   M S B A M L   `   `   `  ����I  EMovieSelector2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MovieSelector2.ViewMovieSelector2.View  5   	   ]3clr-namespace:MovieSelector2.View.ControlProperties%MovieSelector2.View.ControlProperties  5   	   C&clr-namespace:MovieSelector2.ViewModelMovieSelector2.ViewModel  5   	   $    MovieSelector2.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:MovieSelector2.View     5   	   Dctrl3clr-namespace:MovieSelector2.View.ControlProperties     5   	   5vm&clr-namespace:MovieSelector2.ViewModel     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bie9http://schemas.microsoft.com/expression/2010/interactions  5
   	     � Title$   ��5   	   $	��600��6   $	��800��6    � Icon$9 3/MovieSelector2;component/Iconleak-Atrous-Movie.ico��6+    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ MainWindowVM� � 	Resources 5      .   (MovieSelector2.View.BoolToColorConverter  BoolToColorConverter5   /MovieSelector2.View.BoolToOppositeBoolConverter  BoolToOppositeBoolConverter3   -MovieSelector2.View.BoolToVisibilityConverter  BoolToVisibilityConverter,   &MovieSelector2.View.EnumToIntConverter  EnumToIntConverter,   &MovieSelector2.View.IntToBoolConverter  IntToBoolConverter-   'MovieSelector2.View.IntToColorConverter  IntToColorConverter2   ,MovieSelector2.View.IntToVisibilityConverter  IntToVisibilityConverter6   0MovieSelector2.View.NotNullToVisibilityConverter   NotNullToVisibilityConverter.	   (MovieSelector2.View.NullToFalseConverter 	 NullToFalseConverter��%  &	       &	      &	 &     &	 9     &	 L     &	 _     &	 r     &	 �     &		 �       5   
   6%     5   
   6,     5   
   6*     5   
   6#     5   
   6#     5   
   6$     5   
   6)     5   
   6-   	  5   
   6%   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   o� $��0��6    o� 
IsMainMenu . .@�5       m� $
��File��6   m� 5!      $
��Help��6   5"       � 5#   
   -   5          �Name$ 	mainFrame��5#      $��1��6#   	  � NavigationUIVisibility$	 Hidden=�60   �� 5$   
   $��3��6   $��10��6"   5%      5&      