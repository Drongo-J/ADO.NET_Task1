   M S B A M L   `   `   `  ����H  DADO.NET_Task1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ADO.NET_Task1.ViewsADO.NET_Task1.Views  5      "    ADO.NET_Task1.Views.AuthorUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ADO.NET_Task1.Views     5      $	��800��5
      $��40��5      .��5      � 
�������  � ColumnDefinitions  5   
   �� 5      $
��0.6* �6   6.   �� 5      $��* �6   6+   �� 5      $
��3.5* �6   6.   �� 5      $
��3.5* �6   6.   �� 5      $
��1.5* �6   6.   .+�5   
   � $��0��6   .+�5      �� 
�������$��0,0,2,2q�5      ._�5      ��  � Cursor$
 Hand��6   $
��Left=�6{    J� RenderTransformOrigin$ 	0.835,0.7&�6�   $��8,8,0,8q�6�    d� 	IsChecked 6)   �� *	IsChecked+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� � LayoutTransform 5      �� 5       �� ScaleX$	 1.5Q�6)    �� ScaleY$	 1.5Q�66   5      5      5      � 5    
   $��1��6   .+�5!      �� 
�������$��0,0,2,2q�5"      ._�5#      �� $��20(�5$      $��30��5%      $��Medium"�5&      	 �� TextAlignment$	 Center=�5'      $��0,5,3,5q�5(      ��5#      �� *	Author.Id+$ TwoWay=�$ PropertyChanged=�5)      5*      5+      � 5-   
   $��2��6   .+�5.      �� 
�������$��0,0,2,2q�5/      ._�50      �� $��20(�51      $��30��52      $��Medium"�53      $
	 Left=�54      $��10,5,3,5q�55      ��50      �� *Author.FirstName+$ TwoWay=�$ PropertyChanged=�56      57      58      � 5:   
   $��3��6   .+�5;      �� 
�������$��0,0,2,2q�5<      ._�5=      �� $��20(�5>      $��30��5?      $��Medium"�5@      $
	 Left=�5A      $��10,5,3,5q�5B      ��5=      �� *Author.LastName+$ TwoWay=�$ PropertyChanged=�5C      5D      5E      � 5G   
   $��4��6   .+�5H      �� 
�������$��0,0,2,2q�5I      ._�5J      �� $��10,4,7,4q�6   $
��Edit��5K      $��20(�5L      $
 Hand��5M      $��Medium"�5O      ��5N      �� *EditCommand+5P      5Q      5R      5T      5U      