   M S B A M L   `   `   `  ����I  EMovieSelector2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MovieSelector2MovieSelector2  5      ]3clr-namespace:MovieSelector2.View.ControlProperties%MovieSelector2.View.ControlProperties  5      C&clr-namespace:MovieSelector2.ViewModelMovieSelector2.ViewModel  5	          MovieSelector2.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:MovieSelector2     5      Dctrl3clr-namespace:MovieSelector2.View.ControlProperties     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5vm&clr-namespace:MovieSelector2.ViewModel     5	      Ld1p1;http://schemas.openxmlformats.org/markup-compatibility/2006     5        �� 	Resources  5      /   )MovieSelector2.ViewModel.ViewModelLocator   Locator 
 imgAdd �� 	UriSource  imgEdit  imgDisk  imgDatabaseAdd  
imgDoorOut  imgArrowLeft  imgArrowRight  	imgCancel 	 	imgAccept 
 imgBomb  ImageButton �� 
TargetType �� Property �� Value �� Orientation �� Path �� RelativeSource �� AncestorType  dataGridStyle&   System.Windows.Controls.DataGrid  txtStyle  tbStyle  cbStyle��%'  &	        &	      &	 @     &	 z     &	 �     &	 �     &	     &	 D    &	 y    &		 �    &	
 �    &	     &	 �    &	 :    &	 �    &	       5   
   6   �� 5   
   $ View\Ikonki\add.png?�6%   �� 5   
   $&  View\Ikonki\application_edit.png?�6&   �� 5   
   $ View\Ikonki\disk.png?�6&   �� 5   
   $" View\Ikonki\database_add.png?�6-   �� 5   
   $ View\Ikonki\door_out.png?�6)   �� 5   
   $  View\Ikonki\arrow_left.png?�6+   �� 5   
   $! View\Ikonki\arrow_right.png?�6,   �� 5   
   $ View\Ikonki\cancel.png?�6(   �� 5   
   $ View\Ikonki\accept.png?�6(   �� 5   
   $ View\Ikonki\bomb.png?�6&   �� 5   
   " ��6$   .�5      ��  � �� 5      �� 5      .R�5      �� $ 
Horizontal=�6%   .+�5      �� ��6$   �� $# (ctrl:ButtonProperties.Image)� �� *FindAncestor+" ��6�   �� 5      $��Center=�5   /   $��3q�6L   ��5   /   �� $ Content� �� *FindAncestor+" ��5   Y   5       5!      5#      �� 5$       � ��$ 32��6'   �� 5%       � ��$ Center=�64   �� 5&       � ��$ 3q�6'   5'      �� 5(   
   "  6&   .�5)      ��  �@ 
IsReadOnly . 6+   �� 5*       �@ AutoGenerateColumns .  64   �� 5+       � ��$ 5q�6'   �� 5,       �@ SelectionUnit$ FullRow=�6.   �� 5-       �@ GridLinesVisibility$
 None=�64   �� 5.       �@ RowHeaderWidth$ 0Q�6/   5/      �� 50   
   " ��6!   .�51      ��  � ��$ 3q�6'   �� 52       � ��$ Center=�62   53      �� 54   
   " ��6    .�55      ��  � ��$ 3q�6'   �� 56       � ��$ Center=�62   57      �� 58   
   " ��6    .�59      ��  � ��$ Center=�62   �� 5:       � ��$ 3q�6'   5;      5<      5=      