   M S B A M L   `   `   `  ����I  EMovieSelector2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MovieSelector2.ViewMovieSelector2.View  5      ]3clr-namespace:MovieSelector2.View.ControlProperties%MovieSelector2.View.ControlProperties  5      )    #MovieSelector2.View.EdycjaFilmuPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MovieSelector2.View     5      Dctrl3clr-namespace:MovieSelector2.View.ControlProperties     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bie9http://schemas.microsoft.com/expression/2010/interactions  5	        N� Title$  NowyFilmPage��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       $
��auto �6   �� 5!      $
��auto �6   �� 5"      $
��auto �6   �� 5#      $
��auto �6   �� 5$      $
��auto �6   .+�5&   
   �� $��2��6    �� Orientation$ 
Horizontal=�6)   .+�5'      ��    ImageButton#��[  6   $��Zapisz��6:     imgDisk<   6MovieSelector2.View.ControlProperties.ButtonProperties   Image# [ 6K   ��6�   �� *ZapiszFilmCommand+.  (System.Windows.Interactivity.Interaction   	Behaviors 5(      #   MovieSelector2.View.ClosePage  5)      5+      �� 5,      #��[  6   $��Pobierz dane z MovieDb��6:     imgDatabaseAdd# [ 6[    5-      *   $MovieSelector2.View.PobierzDaneFilmu  5.      50      �� 51      #��[  6   $��Anuluj��6:     
imgDoorOut# [ 6K    52        53      55      56      �� 57   
   $��1��6   $��Tytuł��6!     txtStyle#��[ 6.   �� 58   
   $��2��6   $��Tytuł oryginalny��6!   #��[ 69   �� 59   
   $��3��6   $��
Reżyseria��6!   #��[ 62   �� 5:   
   $��4��6   $��
Długość��6!   #��[ 60   �� 5;   
   $��5��6   $
��Kraj��6!   #��[ 6-   �� 5<   
   $��6��6   $	��Rok��6!   #��[ 6,   �� 5=   
   $��7��6   $��	Kategoria��6!   #��[ 62   �� 5>   
   $��8��6   $��Obsada��6!   #��[ 6/   �� 5?   
   $��9��6   $
��Opis��6!   #��[ 6-   �� 5@   
   $��10��6   $��
Ocena IMDb��6"   #��[ 64   �� 5A   
   $��11��6   $
��Link��6"   #��[ 6.   �� 5B   
   $��12��6   $��Poster link��6"   #��[ 65   �� 5C   
   $��13��6   $��	Źródło��6"   #��[ 60   �� 5D   
   $��15��6   $��Poster��6"   #��[ 60   �� 5E   
   $��1��6   $��1��6"     tbStyle#��[ 6y   ��6/   �� *FilmEdytowany.Tytul+ �� UpdateSourceTrigger$ PropertyChanged=�6y   �� 5F   
   $��1��6   $��2��6"   #��[ 6|   ��6/   �� *FilmEdytowany.TytulOrg+$ PropertyChanged=�6|   �� 5G   
   $��1��6   $��3��6"   #��[ 6}   ��6/   �� *FilmEdytowany.Rezyseria+$ PropertyChanged=�6}   �� 5H   
   $��1��6   $��4��6"   #��[ 6{   ��6/   �� *FilmEdytowany.Dlugosc+$ PropertyChanged=�6{   �� 5I   
   $��1��6   $��5��6"   #��[ 6x   ��6/   �� *FilmEdytowany.Kraj+$ PropertyChanged=�6x   �� 5J   
   $��1��6   $��6��6"   #��[ 6w   ��6/   �� *FilmEdytowany.Rok+$ PropertyChanged=�6w   �� 5K   
   $��1��6   $��7��6"   #��[ 6}   ��6/   �� *FilmEdytowany.Kategoria+$ PropertyChanged=�6}   �� 5L   
   $��1��6   $��8��6"   #��[ 6z   ��6/   �� *FilmEdytowany.Obsada+$ PropertyChanged=�6z   �� 5M   
   $��1��6   $��9��6"   #��[ 6x   ��6/   �� *FilmEdytowany.Opis+$ PropertyChanged=�6x   �� 5N   
   $��1��6   $��10��6"   #��[ 6   ��60   �� *FilmEdytowany.ImdbRating+$ PropertyChanged=�6   �� 5O   
   $��1��6   $��11��6"   #��[ 6y   ��60   �� *FilmEdytowany.Link+$ PropertyChanged=�6y   �� 5P   
   -   5         ��Name$ tbLinkPoster��5P      $��1��6(   $��12��68   #��[ 6�   ��6F   �� *FilmEdytowany.PosterLink+$ PropertyChanged=�6�   �� 5Q   
   $��1��6   $��13��6"   #��[ 6{   ��60   �� *FilmEdytowany.Zrodlo+$ PropertyChanged=�6{   �� 5R   
   $��1��6   $��14��6#   $	��Hit��61     cbStyle#��[ 6�    d� 	IsChecked 6?   �� *FilmEdytowany.Hit+$ PropertyChanged=�6�   �� 5S   
   $��1��6   $��15��6#   $��
Nieaktywny��61   #��[ 6�    6F   �� *FilmEdytowany.Nieaktywny+$ PropertyChanged=�6�   �� 5T   
   $��1��6   $��16��6    $	��100��6e   $	��150��6q   ��6.   �� 	 �� ElementName$	 tbLinkPoster��
 �� Path$

 Text�6q   5V      5W      