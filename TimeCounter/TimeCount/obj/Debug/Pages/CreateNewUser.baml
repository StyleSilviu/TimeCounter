   M S B A M L   `   `   `  ����D  @TimeCount, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:TimeCount.ViewModelsTimeCount.ViewModels  5      #    TimeCount.Pages.CreateNewUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8	ViewModel"clr-namespace:TimeCount.ViewModels     5      $	��300��5      $	��378��6   .��5      � .+�5	   
   �� $��SIGN UP��6   $
��Bold"�6"   $��0,0,0,8q�64   $��2��6E   �� 5
   
   -   5          ��Name$
  Form��5
      $��0,30,0,0q�6#    �� Orientation$ Vertical=�65   $��2��6L    � DataContext 5      3  -TimeCount.ViewModels.AccountCreationViewModel  5       � 	Resources 5       �� 
TargetType �� Property �� Value �� BasedOn��%a  '��       '�� �     7��'�� n    7��'�� �    7��'	� �    7	��� 5      " ��6   .�5      ��  �@��Orientation$ 
Horizontal=�64   �� 5       � ��$ 0,0,0,4q�6/   5      �� 5      " ��6   8   .�5      ��  � ��$	 100��6.   �� 5       � ��$ Center=�6:   �� 5       � ��$ Segoe UI)�63   �� 5       � ��$ 12(�61   �� 5       � ��$	 150��6.   5      �� 5      " ��6   8   .�5      ��  � ��$	 100��6.   �� 5        � ��$ Center=�6:   �� 5!       � ��$ Segoe UI)�63   �� 5"       � ��$ 12(�61   �� 5$       � ��$ Stretch=�6<   �� 5%       � ��$ Center=�6:   5&      �� 5'      " ��6   8   .�5(      ��  � ��$	 0,3q�60   5)      �� 5*      " 	�6   8   .�5+      ��  � ��$	 0,3q�60   5,      5-      .+�5/      �� .+�50      �� $��
First name��6   �� 51      -   5         ��Name$ TextFirstName��51      ��61   �� *	FirstName+	 �� Mode$	 TwoWay=�
 �� ValidatesOnDataErrors
 . 52      �� 53      .+�54      �� $��	Last name��6   �� 55      -   5        $ TextLastName��55      ��60   �� *
LastName+$	 TwoWay=�
 . 56      �� 57      .+�58      �� $��	User Name��6   �� 59      -   5        $ TextUserName��59      ��60   �� *
UserName+$	 TwoWay=�
 . 5:      �� 5;      .+�5<      �� $��Password��6   �� 5=      -   5        $ TextPassword��5=      ��60   �� *
Password+$	 TwoWay=�
 . 5>      �� 5C      .+�5D      �� $��Gender��6   	� 5E      -   5         	�Name$ RadioGendeMale��5E      $
��Male��66    d� 	IsChecked$
 TrueY�6E   	� 5F      $��Female��6   $��8,0,0,0q�6/   5G      �� 5H      .+�5I      �� $��
Birth date��6   (  "System.Windows.Controls.DatePicker  5J      -   5          Name$ 	DateBirth��5J   ?      SelectedDate 6   �� *
BirthDay+6?   5K      �� 5L      .+�5M      �� -   5         ��Name$ AgreeCB��5M      $��	100,0,0,0q�6,   $!��I agree to the terms of use��6?   5N      �� 5O      -	   5         ��Name$ 	SubmitBtn��5O      $��Submit��6(   $��
100,16,0,0q�69   $
��Left=�6M   5P      5Q      5R      