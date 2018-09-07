# ModernMessageBoxLib
ModernMessageBoxLib is a WPF library in .Net 4.5
By using ModernMessageBoxLib, you can create a ModernMessageBox with a single code.
## Screenshots
Common usage

![sc1](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc1.png)

Customize

![sc2](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc2.png)

With a different color

![sc3](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc3.png)

## Import

We are Strongly recommand you to use Nuget to import the package.
Start this command in Package Manage Console:
```
PM> Install-Package ModernMessageBoxLib
```
_(See more in [Nuget](https://www.nuget.org/packages/ModernMessageBoxLib/))_

Or you can download it on Release Page.

## Get Started

Before start using, you should specify Language and Background and Foreground.
See
* _QModernMessageBox.MainLang_

* _QModernMessageBox.GlobalBackground_

* _QModernMessageBox.GlobalForeground_

Example:
```C#
            QModernMessageBox.MainLang = new QMetroMessageLang() {
                Ok = "确定",
                Cancel = "取消",
                Abort = "中止(A)",
                Ignore = "忽略(I)",
                No = "否(N)",
                Yes = "是(Y)",
                Retry = "重试(R)"
            };
            QModernMessageBox.GlobalBackground = new SolidColorBrush(Colors.White){Opacity = 0.6};
            QModernMessageBox.GlobalForeground = Brushes.Black;
```
In this example, The button text of the ModernMessageBox set to Chinese and Background set to white with 60% opacity and Foreground set to Black.

Those setting will use as default in ModernMessageBox.

> The default Background in MessageBox is Black, 60% Opacity and the Foreground is White
> 
> The default lang is in English

In common cases, you can create a MetroMessageBox with the following code
```C#
    QModernMessageBox.Show("The quick brown fox jumps over the lazy dog.", "hello world",QModernMessageBox.QModernMessageBoxButtons.YesNoCancel,ModernMessageboxIcons.Warning);
```

Or using the QT way:
```C#
QModernMessageBox.Warning("The quick brown fox jumps over the lazy dog.", "hello world");
```

Customize:
```C#
                var msg = new ModernMessageBox("The quick brown fox jumps over the lazy dog.\n", "hello world", ModernMessageboxIcons.Info, "CSharp", "Java",
                "Python") {
                Button1Key = Key.D1,
                Button2Key = Key.D2,
                Button3Key = Key.D3,
                CheckboxText = "Don't show this again",
                CheckboxVisibility = Visibility.Visible
            };
            
            msg.ShowDialog();
```

See more in the XML document comment.


Build with ❤ By Saber0905 in SakuraTrak Studio
