   M S B A M L   `   `   `  ����G  CPark-O-Meter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Park_O_MeterPark_O_Meter  5   	       Park_O_Meter.CurrentState   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Park_O_Meter     5   	     � Title$  CurrentState��5   	   $	��450��6   $	��800��6+    � 
ResizeMode$ NoResize=�5	   	   
������  � WindowStyle$
 None=�5   	    � AllowsTransparency . .��5      �� -   5         �� CornerRadius$ 25��5      ���#1165a9._�5   
   �  � RowDefinitions 5      �� 5      $��50 �6    �� 5      .+�5      �� $��Current state��6   
�������$
��Left=�5      $��Center=�5      $��20 0 0 0q�5      $��25(�5      �� 5      -   5        
��� E��$��Refresh��5   	   $	��100��5   	   $��35��5    	   
�������$��5,5,5,0q�5"   	   5$      �� 5%      -   5        $��35��5%      $��33��5&      $��	 0 0 25 0q�5'      $��Right=�5(      
������ $��X��5*      
�������$��20(�5,      $��0q�5-      6-   �� 5.      -   5         ��Name$ ListView��53      $��1��5.      $��Center=�5/      $��Center=�50      $	��375��51      $	��750��52       �� View 54      �� 55      .P�56      �� $��Registration Plate��6)    �� DisplayMemberBinding 6E   �� *RegistrationPlate+�� 57      $��
Entry time��6)    6=   �� *	EntryTime+�� 58      $
��Type��6)    67   �� *Type+59      5;      5=      5>      5@      