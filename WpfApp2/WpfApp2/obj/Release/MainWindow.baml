   M S B A M L   `   `   `  ���� B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes     WpfApp2.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp2     ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2       � Title$  
MainWindow��$	��533��$	��948�����	#FF1E1F26 � 	Resources    FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color	 � Offset  ComboBox.Static.Border
 �� Color ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background 	 ComboBox.MouseOver.Border *
 &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� 
TargetType ��Name F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight  �� ElementName! ��Name" �� ClearTypeHint# ��Name$ ��Name% ��Name-  'System.Windows.Input.KeyboardNavigation&   DirectionalNavigation' d�Name( d� 	IsChecked) ��Name* �� SelectionBoxItemTemplate+ �� SelectionBoxItem#, �� SelectionBoxItemStringFormat- �� ContentStringFormat. J� IsHitTestVisible/ P� 
SourceName0 ]� 
Conditions1 �� Property  TextBox.Static.Background   ComboBoxEditableTextBox ! ComboBoxEditableTemplate2 ��Name3 �� 
IsReadOnly " ComboBoxStyle14 �� Triggers # ComboBoxToggleButton2 $ ComboBoxStyle2��%�)  &	        &	 N     &	 �     &	 �     &	 �     &	 �     &	 �     &	     &	 *    &		 �    &	
 �    &	 �    &	 �    &	     &	 2    &	 G    &	 �    &	 �    &	 �    &	 �    &	 :    &	 O    &	 d    &	 y    &	 �    &	 �    &	 �    &	 �    &	 �    &	 �    7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 E    7  &	     &	  !    &	! ~    7  7  7   &	" �    7   7  7  7  7 ! &	# �    7  7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	$ �%    7   7  7  7  7 ! �� .���  � �� �� .R��� $��2q� . #��� ��$��1��$	 1 2R��� $	 0,1&�$	 0,0&�.��� $ 	#FFF0F0F0��$		 0.0Q�� $ 	#FFE5E5E5��$		 1.0Q��� $
 	#FFACACAC���� $
 	#FFFFFFFF���� $
 	#FFABADB3���� $
 Transparent���� $
 Transparent���� $
 	#FF000000���� $	 0,1&�$	 0,0&�.��� $ 	#FFECF4FC��$		 0.0Q�� $ 	#FFDCECFC��$		 1.0Q��� $
 	#FF7EB4EA���� $
 	#FFFFFFFF���� $
 	#FF7EB4EA���� $	 0,1&�$	 0,0&�.��� $ 	#FFEBF4FC��$		 0.0Q�� $ 	#FFDCECFC��$		 1.0Q��� $
 	#FF7EB4EA���� $
 	#FF000000���� $	 0,1&�$	 0,0&�.��� $ 	#FFDAECFC��$		 0.0Q�� $ 	#FFC4E0FC��$		 1.0Q��� $
 	#FF569DE5���� $
 	#FFFFFFFF���� $
 	#FF569DE5���� $	 0,1&�$	 0,0&�.��� $ 	#FFDAEBFC��$		 0.0Q�� $ 	#FFC4E0FC��$		 1.0Q��� $
 	#FF569DE5���� $
 	#FFBFBFBF���� $
 	#FFF0F0F0���� $
 	#FFD9D9D9���� $
 	#FFFFFFFF���� $
 	#FFBFBFBF���� $
 Transparent���� $
 Transparent���� $
 	#FF606060���� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ templateRoot�����	#FF4D648D#��z�����	#FF343946 . ._��� $ splitBorder��
������ $��1q�$��Right=�$��0q� . #��� r�._�F� $ arrow��F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8��  $��Center=�$��0q�$��Center=� ^�  ��  �� *
IsEditable+ �� " �� true��  �� *IsMouseOver+ �� *Self+	 false��  �� *	IsPressed+ �� *Self+	 false��  �� *	IsEnabled+ �� *Self+ true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  �@J�IsMouseOver . . ��� $ arrow��8   � ��^�  ��  �� *IsMouseOver+ �� *Self+ true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *IsMouseOver+ �� *Self+ true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8 	  � ���� $ splitBorder��8 
  � ���� $ splitBorder��8   � ��P�  � �� . . ��� $ arrow��8   � ��^�  ��  �� *	IsPressed+ �� *Self+ true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsPressed+ �� *Self+ true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {� .  . ��� $ arrow��8   � ��^�  ��  �� *	IsEnabled+ �� *Self+	 false��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsEnabled+ �� *Self+	 false��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ���� " ��.R�� $ templateRoot�� .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��$��1q�#��� .�$��Bottom=����� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��  $ shadow��$ Transparent��#��z ���� *ActualWidth+$  templateRoot��._��� $ dropDownBorder��#��� ��$��1q�#��� ��._��� $! DropDownScrollViewer��.��� $
 grid��$" Enabled=�.+��� $# canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $$ 
opaqueRect������ *
Background+$  dropDownBorder������ *ActualHeight+$  dropDownBorder������ *ActualWidth+$  dropDownBorder���� $% ItemsPresenter��$& 	Contained=�# z d� $' toggleButton��#��z��#��z��#��z��$��2��8��  ( �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $) contentPresenter��#��z* #��z��#��z+ #- z, #��z��. .  #��z��# z #��z�� P� $/ 
PART_Popup�� �@�HasDropShadow . . ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]� 0 �� 1 �@��
IsGrouping . �� "1 �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  P� $/ DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left�� $
 	#FFFFFFFF���� " ��.���  �@�OverridesDefaultStyle . ��  �@J�	AllowDrop . ��  � ��$ 0����  � ��$ 0����  �@�FocusVisualStyle Z� ��  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled .  ��  � �� �� " ��.R��� $! PART_ContentHost��
������ |�.  $��Hidden=�$��Hidden=��� " ��.R�� $ templateRoot�� .  �� $��* ��� #��� r�$��0 �.+�� $ 
PART_Popup�� . $��2��#��� .�$��Bottom=����� *IsDropDownOpen+ �� *TemplatedParent+.��  $ shadow��$ Transparent��#��z ���� *ActualWidth+$  templateRoot��._��� $ dropDownBorder��#��� ��$��1q�#��� ��._��� $! DropDownScrollViewer��.��� $
 grid��$" Enabled=�.+��� $# canvas��$
��Left=�$��0��$	��Top=�$��0��.+��� $$ 
opaqueRect������ *
Background+$  dropDownBorder������ *ActualHeight+$  dropDownBorder������ *ActualWidth+$  dropDownBorder���� $% ItemsPresenter��$& 	Contained=�# z d� $' toggleButton��#��z��#��z��#��z��$��2��8��  ( �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+�� $ border��8�� #��z��._��� $2 PART_EditableTextBox��#��z��#��z��8�� #��z��3 �� *
IsReadOnly+ �� *TemplatedParent+ P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsKeyboardFocusWithin . . ���  � ��
 �   �P� $/ 
PART_Popup�� �@�HasDropShadow . . ��� $ shadow�� � ��$ 0,0,5,5q��� $ shadow�� �@ Color$ 	#71000000��P�  �@��HasItems .  . ��� $ dropDownBorder�� � ��$ 95��]� 0 �� 1 �@��
IsGrouping . �� "1 �@%�IsVirtualizingWhenGrouping .  ./���  � �� .  P� $/ DropDownScrollViewer�� � �� .  . ��� $ 
opaqueRect�� �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� $ 
opaqueRect�� �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left�� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 6,3,5,3q���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��8  4 P�  �@��
IsEditable . . ���  � �� .  ��  � ��$ 2q���  � ��8  �� " d�.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  �@��	ClickMode$ Press=���  � �� �� " d�.R��� $ templateRoot��8��  #��z��8��  . ._��� $ splitBorder��
������ $��1q�$��Right=�$��0q� . #��� r�._�F� $ arrow��F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�$��0q�$��Center=� ^�  ��  �� *
IsEditable+ �� " �� true��  �� *IsMouseOver+ �� *Self+	 false��  �� *	IsPressed+ �� *Self+	 false��  �� *	IsEnabled+ �� *Self+ true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  �@J�IsMouseOver . . ��� $ arrow��8   � ��^�  ��  �� *IsMouseOver+ �� *Self+ true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8 	  � ��^�  ��  �� *IsMouseOver+ �� *Self+ true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8 
  � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � �� . . ��� $ arrow��8   � ��^�  ��  �� *	IsPressed+ �� *Self+ true��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsPressed+ �� *Self+ true��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ��P�  � {� .  . ��� $ arrow��8   � ��^�  ��  �� *	IsEnabled+ �� *Self+	 false��  �� *
IsEditable+ �� " ��	 false.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ��^�  ��  �� *	IsEnabled+ �� *Self+	 false��  �� *
IsEditable+ �� " �� true.0��� $ templateRoot��8   � ���� $ templateRoot��8   � ���� $ splitBorder��8   � ���� $ splitBorder��8   � ���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$
 Auto=���  � ��$
 Auto=���  � ��$ 6,3,5,3q���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � ��8  4 P�  �@��
IsEditable . . ���  � �� .  ��  � ��$ 2q���  � ��8  .��(� $	��503��$	��948��5 (� Stretch$
5 Fill=�.��� $	��533��$	��948��  % RefreshButtonImageBrush6 �� ImageSource7 j� Stretch��%5   &	%       �� $6 refresh.png��$7 UniformToFill=� �� $
��474* ��� $	��22* ��� $
��215* ��� $
��238* �8 � RowDefinitions8 �� $	��62* ��� $	��62* ��� $	��32* ��� $	��31* ��� $
��Auto ��� $	��31* ��� $	��34* ��� $	��59* ��� $	��32* ��� $	��31* ��� $	��32* ��� $	��31* ��� $	��63* �.+��� $��4��$��13��$��
0,0,0,-0.8q����� $	 0,0&�$	 1,1&�.��� $ 	#FF08080E��$		 0.2Q�� $ 	#FF2C2F3C��$		 0.5Q�� $ 	#FF08080F��$		 0.8Q��� -   9 ��Name$9 jtttTxt��$��0��$��Center=�$��Center=�$
��JTTT��$	��173��$��48(�$
��Bold"����	#FF8DAFEB$��Sitka Banner)�$��150,0,150.6,66q�$��2���� -   $2 urlBox��$��4��$��Center=�$��Center=�$��25��: �� TextWrapping$
: Wrap=�$��Wprowadź URL strony��$	��254�����	#FF343946���	#FF8DAFEB���	#FF4D648D$��16(�$��110,4.4,109.6,4.2q��� -   $2 textBox��$��6��$��Center=�$��Center=�$��25��$
: Wrap=�$��Podaj tekst do wyszukania��$	��254�����	#FF343946���	#FF8DAFEB���	#FF4D648D$��16(�$��110,4.2,109.6,4.4q��� -   $2 mailBox��$��9��$��Center=�$��Center=�$��25��$
: Wrap=�$%��Podaj mail do wysłania obrazka��$	��254�����	#FF343946���	#FF8DAFEB���	#FF4D648D$��16(�$��110,3.8,109.6,2.4q��� -   $9 urlLabel��$��3��$��Center=�$��Center=�$	��URL�����	#FF8DAFEB$��Sitka Banner)�$��70��$��16(�$��202,2,201.6,0.2q��� -   $9 	textLabel��$��5��$��Center=�$��Center=�$�� TEKST�����	#FF8DAFEB$��Sitka Banner)�$��16(�$��192,1.6,190.6,1.6q��� -   ; ��Name$; addBtn��$��12��$
��Left=�$��Center=�$��Center=�$��DODAJ�����	#FF4D648D���	#FF343946���	#FF8DAFEB$��Sitka Heading)�$��20(�$��30��$	��150��$��66,18.4,0,14.8q��� -   $9 jesliTxt��$��1��$��Center=�$��Center=�$��	JEŚLI TO��$��Center=�$��66��$	��173��$��36(����	#FF8DAFEB$��Sitka Banner)�$��150,0.4,150.6,0q��� -	   $9 	jesli2Txt��$��6��$��Center=�$��Center=�$��
WYKONAJ TO��$	��248��$��36(����	#FF8DAFEB$��Sitka Banner)�$��113,33.2,112.6,34.2q�$��3���� -
   $9 
komunikaty��$��10��$��Center=�$��Center=�$��Status��$	��114�����	#FF8DAFEB$��Sitka Banner)�$��16(�$��180,3.6,179.6,30.6q�$��2���� -   $2 	outputBox��$��11��$��Center=�$��Center=�$��25��$
: Wrap=�$��Oczekuje na użytkownika��$	��254�����	#FF343946���	#FF8DAFEB���	#FF4D648D3 . $��16(�$��110,4.6,109.6,1.6q��� -   < ��Name$< tasksListBox��$��1��$��7��$��2��$��2��$��Center=�$	��262��$��Center=�$	��430�����	#FF343946$��0.6,0.4,22,4.8q��� -   $; workBtn��$��12��$��Center=�$��Center=�$��WSZYSTKO�����	#FF4D648D���	#FF343946���	#FF8DAFEB$��Sitka Heading)�$��20(�$��30��$	��150��$��2��$��21.8,2.4,43.4,30.8q��� -   $; clearBtn��$��12��$��3��$��Center=�$��Center=�$��WSZYSTKO�����	#FF4D648D
���   ����	#FF8DAFEB$��Sitka Heading)�$	��150��$��20(�$��30��$��43.6,2.4,44,30.8q��� -   $9 listaTxt��$��0��$��2��$��2��$��Center=�$��Center=�$��LISTA ZADAŃ��$	��248��$��36(����	#FF8DAFEB$��Sitka Banner)�$��91.6,0,113,66q�$��2���� -   $; templateBtn��$��12��$��Right=�$��Center=�$��Center=�$��	WYPEŁNIJ�����	#FF4D648D���	#FF343946���	#FF8DAFEB$��Sitka Heading)�$��20(�$��30��$	��150��$��0��$��0,18.4,65.6,14.8q��� -   $; 	removeBtn��$��10��$��2��$��3��$��Center=�$��Center=�$��WYBRANE�����	#FF4D648D���	#FF343946���	#FF8DAFEB$��Sitka Heading)�$	��150��$��20(�$��30��$��43.6,10.6,44,22.6q��� -   $; sWorkBtn��$��10��$��2��$��Center=�$��Center=�$��WYBRANE�����	#FF4D648D���	#FF343946���	#FF8DAFEB$��Sitka Heading)�$��20(�$��30��$	��150��$��2��$��21.8,10.6,43.4,22.6q��� -   $9 dodajTxt��$��8��$��2��$��2��$��1��$��Center=�$��Center=�$��WYKONAJ��$��Center=�$��66��$	��172��$��36(����	#FF8DAFEB$��Sitka Banner)�$��10.6,0.2,32.4,1.4q��� -   $9 usunTxt��$��8��$��3��$��2��$��1��$��Center=�$��Center=�$��USUŃ��$��Center=�$��66��$	��173��$��36(����	#FF8DAFEB$��Sitka Banner)�$��32.6,0.2,32,1.4q��� -   $; 
refreshBtn��#��[% $��Center=�$	��Top=�$��2��$
��Left=�$��50��$��435,6.6,0,0q�$	��Top=�$��50��$��30(�$��1���� -   $2 numberTextBox��$��6��$��Center=�$��Center=�$��25��$
: Wrap=�$!��Podaj warunek temperaturowy��$	��254�����	#FF343946���	#FF8DAFEB���	#FF4D648D$��16(�$��110,4.4,109.6,1.8q��� -   = ��Name$= responseComboBox��$
��Left=�> �� SelectedIndex$> 0��$��180,0,0,9.2q�$��7��$��Bottom=�$	��120��$��2�����	#FF343946���	#FF8DAFEB#��� " .@��� -   $��item1��.��Wyślij maila�� -   $��item2��.��Zapisz jako�� -   $��item3��.��	Wyświetl ��%�   (��       *SystemColors.WindowBrushKey+)(��      * SystemColors.HighlightBrushKey+)�� $
 	#FF343946���� $
 	#FF8DAFEB���� -   $= taskComboBox��$��180,4.2,173.6,0q�$��2��$	��Top=�$> 0�����	#FF343946���	#FF8DAFEB#��� $ .@��� -   $��item4��.��Znajdź na stronie�� -   $��item5��.��Podaj pogodę ��%�   (��       *SystemColors.WindowBrushKey+)(��      * SystemColors.HighlightBrushKey+)�� $
 	#FF343946���� $
 	#FF8DAFEB��