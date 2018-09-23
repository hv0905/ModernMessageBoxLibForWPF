# ModernMessageBoxLib
ModernMessageBoxLib is a WPF library in .Net 4.5
By using ModernMessageBoxLib, you can create a ModernMessageBox with a single code.
## Todo list

 - [x] Basic MessageBox
 - [ ] Input Window
 - [x] Waiting window
 - [ ] Color Picker

## Screenshots
### ModernMessageBox

![sc1](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc1.png)

![sc2](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc2.png)

![sc3](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc3.png)

### IndeterminateProgressWindow

![sc4](https://github.com/hv0905/ModernMessageBoxLibForWPF/raw/master/web/sc4.png)

## Import

We are strongly recommend you to use Nuget to import the package.
Run this command in Package Manage Console:
```
PM> Install-Package ModernMessageBoxLib
```
_(See more in [Nuget](https://www.nuget.org/packages/ModernMessageBoxLib/))_

Or you can download it on Release Page.

## Get Started

### ModernMessageBox

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

> In background setting, you can use a color with not fully solid.
> In this way, the window will have a Gaussian Blur background in Win10 1803+
> In win7/8/8.1 or early version of win10, it will still use the solid color as background.
> If you don't want a gaussian blur, just set the color solid.


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
        CheckboxVisibility = Visibility.Visible,
        TextBoxText = "fsdfdsfsd",
        TextBoxVisibility = Visibility.Visible,
    };
            
    msg.ShowDialog();
```

### IndeterminateProgressWindow
Before start using, you should specify Background and Foreground.
See:

* _IndeterminateProgressWindow.GlobalBackground_

* _IndeterminateProgressWindow.GlobalForeground_

Usage:
```C#
    var win = new IndeterminateProgressWindow("Please wait while we are installing the virus into your computer. . .");
	win.Show();
	//Do Some Staff
	await Task.Delay(5000);
	//Change the message the 2nd time
	win.Message = "Done!!!";
	win.Close();
```


See more in the XML document comment.

# About

Using this library means you agree the MIT Licence.
Build with ❤ By Saber0905 in SakuraTrak Studio
