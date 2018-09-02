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

## Get Started

Before start using, you should specify Language and Background and Foreground.
See
_QModernMessageBox.MainLang_
_QModernMessageBox.GlobalBackground_
_QModernMessageBox.GlobalForeground_

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
