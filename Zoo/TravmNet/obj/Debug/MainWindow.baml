   M S B A M L   `   `   `  ����>  :Zoo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ZooZoo  5   	       Zoo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:Zoo     5   	     � Title$  Авторизация��5   	   $	��347��6   $	��279��6*    �� 
Attributes$ Center��5	   	    � 
ResizeMode$ NoResize=�6*    � WindowStartupLocation$ CenterScreen=�6@   .��5
      � .+�5   
   �� -   5         ��Name$ TBLogin��5      $
��Left=�6#   $��33��6>   $��	20,31,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��220��6�   $��16(�6�   .��6�   ��5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   -   �� 6   6sys&clr-namespace:System;assembly=mscorlib     6-    �� 
TargetType" ��6    �� 	Resources 5         CueBannerBrush j� 
AlignmentX	 j� 
AlignmentY
 j� Stretch !� Visual��%�   &	        !� 5      $
 Left=�6=   $	 Center=�6O   $

 None=�6c    5      �� 5   "   $��
Логин��6(   
�������68   5      5       �� Triggers 5      P� 5       P� Property � �� �� Empty P� Value# Z 62   . �5      ��  �� Property � �� �� Value# [  6;   5      P� 5       � �� 62   Z� . �5      ��  � ��# [  6;   5      P� 5       �@J�IsKeyboardFocused . . �5      ��  � ��
 �����6;   5      5       .��5!      5"      �� 5#   
   $��Пароль:��6   $
��Left=�6"   $��	20,94,0,0q�6=   $	��Top=�6P   $	��220��6h   $��38��6t   $��16(�6�   G� 5$   
   -   5         G�Name$ PasswordBox��5$      $
��Left=�6+   $��
20,141,0,0q�6F   $	��Top=�6Z   $	��220��6r   $��26��6~   $��16(�6�   �� 5%   
   -   5        $��Регистрация��5%      $
��Left=�6'   $��
20,258,0,0q�6B   $	��Top=�6V   $	��220��6n   $��37��6z   6�   �� 5&   
   -   5        $��Авторизация��5&      $
��Left=�6'   $��
20,207,0,0q�6B   $	��Top=�6V   $	��220��6n   $��29��6�   5(      5)      