   M S B A M L   `   `   `  ����I  EMovieSelector2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:MovieSelector2.ViewMovieSelector2.View  5      )    #MovieSelector2.View.ListaFilmowPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:MovieSelector2.View     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        N� Title$  ListaFilmowPage��5
      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Loaded��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *LoadedCommand+5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     dataGridStyle#��[  6;   ��6   �� *ListaFilmowView+ �� SelectedItem 6c   �� *FilmZaznaczony+   	Behaviors 5      <   6MovieSelector2.View.DataGridSelectedItemsBlendBehavior  5         SelectedItems 6;   �� *FilmyZaznaczone+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� Mode$	 TwoWay=�
   	CellStyle
 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5      �� 5       �� Binding 6&   �� *
Nieaktywny+ �� Value True6E   .a�5      ��  �� Property � �� �� Value$ Italic$�6:   5      5         RowStyle 5      �� 5      )  #System.Windows.Controls.DataGridRow"  6   .�5       ��  �@�ToolTip 5!      '	   !MovieSelector2.View.FilmToolTipUC	  5"      5$      5%         Columns 5'      0
  *System.Windows.Controls.DataGridTextColumn
  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ Lokata��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Lokata+
  5)      $ Tytuł��6%    64   �� *Tytul+
  5*      $ Mecze��6%    64   �� *Udzial+
  5+      $ Średnia��6%    66   �� *	Srednia+
  5,      $	 Max��6%    62   �� *Max+
  5-      $ 
Reżyseria��6%    68   �� *	Rezyseria+
  5.      $ 
Długość��6%    66   �� *	Dlugosc+50      51      52      