   M S B A M L   `   `   `  ����H  DPractical2WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Practical2WPFPractical2WPF  5   	       Practical2WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Practical2WPF     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $��50 �6   .+�5   
   (  "System.Windows.Controls.DatePicker  -   5          Name$ datePicK��5      $��20(�6'   $��3��65   6I   �� 5   
   -   5         ��Name$ 	notesList��5      $��1��6%   $��2��62   ��5      �� 5      .R�5      �� ��6    �� *Title+5      5      �� 5   
    �� Orientation$ Vertical=�6   $��1��6,   $��2��69   $	��Top=�6I   $��10q�6a   .+�5       �� -   5         ��Name$ title��5       $��20(�6%   �� 5!      -   5        $ description��5!       �� AcceptsReturn$
 True��6+   $��20(�6@   5"      �� 5$   
   -   5        $	��Add��5$      $��20(�6   $��3��6F   $��0��6S   $��10q�6c   �� 5%   
   -   5        $��Update��5%      $��20(�6"   $��3��6L   $��1��6Y   $��10q�6i   �� 5&   
   -   5        $��Delete��5&      $��20(�6"   $��3��6L   $��2��6Y   $��10q�6i   5(      5)      