   M S B A M L   `   `   `  ���� G  CPark-O-Meter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Park_O_MeterPark_O_Meter      Park_O_Meter.CurrentState   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:Park_O_Meter       � Title$  CurrentState��$	��450��$	��800�� � 
ResizeMode$ NoResize=�
������  � WindowStyle$
 None=� � AllowsTransparency . .���� -    �� CornerRadius$ 25�����#1165a9._��  � RowDefinitions �� $��50 ��� .+��� $��Current state��
�������$
��Left=�$��Center=�$��20 0 0 0q�$��25(��� -   
��� E��$��Refresh��$	��100��$��35��
�������$��5,5,5,0q��� -   $��35��$��33��$��	 0 0 25 0q�$��Right=�
������ $��X��
�������$��20(�$��0q��� -    ��Name$ ListView��$��1��$��Center=�$��Center=�$	��375��$	��750�� �� View �� .P��� $��Registration Plate�� �� DisplayMemberBinding �� *RegistrationPlate+�� $��
Entry time�� �� *	EntryTime+�� $
��Type�� �� *Type+