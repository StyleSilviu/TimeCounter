   M S B A M L   `   `   `  ����D  @TimeCount, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TimeCount.ConvertersTimeCount.Converters  5          TimeCount.PageTransition   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9
Converters"clr-namespace:TimeCount.Converters     5        � 	Resources  5	      /   )TimeCount.Converters.CenterAlignConverter   centerConverter �� 
TargetType �� Property �� Value  SlideAndFadeIn g� Duration �� TargetProperty t� From	 t� To g� DecelerationRatio	 W� From	
 W� To  SlideAndFadeOut g� AccelerationRatio 
 FadeIn  FadeOut 
 GrowIn  GrowOut  GrowAndFadeIn  GrowAndFadeOut 
	 FlipIn 
 FlipOut  FlipAndFadeIn  FlipAndFadeOut 
 SpinIn  SpinOut  SpinAndFadeIn  SpinAndFadeOut��%�  &	        '��      &	 �     &	 O    &	     &	 i    &	 �    &	     &	 I    &	 �    &		 ^    &	
 �	    &	 �
    &	 �    &	     &	 �    &	 �    &	 �      5   
   6*   �� 5   
   " ��6   .�5      ��  �@�LayoutTransform 5      �� 5      5      5      �� 5   
   .��5      t� $ 0:0:.75D�6!   $ Margin�64   $ 500,0,-500,0X�6W   $ 0X�6k   $ .9Q�6r   W� 5      $ 0:0:.25D�6   $ Opacity�61   $	 0X�6U   $
 1X�6^   5      �� 5   
   .��5      t� $ 0:0:.5D�6!   $ Margin�63   $ -500,0,500,0X�6V   $ .9Q�6h   W� 5      $ 0:0:.5D�6   $ Opacity�60   $
 0X�6T   5      �� 5   
   .��5       W� $ 0:0:.25D�6   $ Opacity�61   $	 0X�6U   $
 1X�6^   5!      �� 5#   
   .��5$      W� $ 0:0:.5D�6   $ Opacity�60   $
 0X�6T   5%      �� 52   
   .��53      W� $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 54      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   55      �� 57   
   .��58      W� $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 59      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   5:      �� 5=   
   .��5>      W� $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5?      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5@      $ 0:0:.25D�6   $ Opacity�61   $	 0X�6U   $
 1X�6^   5A      �� 5C   
   .��5D      W� $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5E      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5F      $ 0:0:.75D�6   $ Opacity�61   $
 0X�6U   5G      �� 5J   
   .��5K      W� $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleX)�6   $
	 -100X�6�   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5L      $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleY)�6   $
	 -100X�6�   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   5M      �� 5O   
   .��5P      W� $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleX)�6   $	
 100X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5Q      $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleY)�6   $	
 100X�6�   $ 0:0:.75D�6�   $ .9Q�6�   5R      �� 5U   
   .��5V      W� $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleX)�6   $
	 -100X�6�   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5W      $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleY)�6   $
	 -100X�6�   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5X      $ 0:0:.25D�6   $ Opacity�61   $	 0X�6U   $
 1X�6^   5Y      �� 5[   
   .��5\      W� $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleX)�6   $	
 100X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5]      $K E(RenderTransform).(TransformGroup.Children)[1].(SkewTransform.AngleY)�6   $	
 100X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5^      $ 0:0:.75D�6   $ Opacity�61   $
 0X�6U   5_      �� 5b   
   .��5c      W� $L F(RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6   $
	 -360X�6�   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5d      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5e      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   5f      �� 5h   
   .��5i      W� $L F(RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6   $	
 360X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5j      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5k      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   5l      �� 5o   
   .��5p      W� $L F(RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6   $
	 -360X�6�   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5q      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5r      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $	 0X�6�   $
 1X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5s      $ 0:0:.25D�6   $ Opacity�61   $	 0X�6U   $
 1X�6^   5t      �� 5v   
   .��5w      W� $L F(RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6   $	
 360X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5x      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5y      $L F(RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)�6   $
 0X�6�   $ 0:0:.75D�6�   $ .9Q�6�   W� 5z      $ 0:0:.75D�6   $ Opacity�61   $
 0X�6U   5{      5|      .��5}      � -   5        $
��page��5}      .+�5~   
   �� -   5        $��contentPresenter��5~      z�5      V� 5�      .~�5�      ��  �� ScaleX$ 1Q�6%    �� ScaleY$ 1Q�60    �� CenterX 5�   
   ��  �� RelativeSource ��  �� AncestorType$
 GridL� �� Mode$ FindAncestor=� �� Path$ ActualWidth� �� 	Converter# [   �� CenterY 5�   
   ��  �� $
 GridL�$ FindAncestor=�$ ActualHeight�# [  �� 5�       �� AngleX$ 0Q�6$    �� AngleY$ 0Q�6/    �� CenterX 5�      ��  �� $
 GridL�$ FindAncestor=�$ ActualWidth�# [   �� CenterY 5�      ��  �� $
 GridL�$ FindAncestor=�$ ActualHeight�# [  �� 5�       �� Angle$ 0Q�6&    �� CenterX 5�      ��  �� $
 GridL�$ FindAncestor=�$ ActualWidth�# [   �� CenterY 5�      ��  �� $
 GridL�$ FindAncestor=�$ ActualHeight�# [  T� 5�       T� X$ 0Q�6)    T� Y$ 0Q�6/   5�      5�      5�      5�      