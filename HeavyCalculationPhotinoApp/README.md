# HeavyPageReloadsPhotinoApp
It annoys embedded Photino browser on Windows (WebView2) with frequent page reloads so much that it crashes with **0xC0000005** (OMG!):
```
PS ...MyPhotinoApps\HeavyCalculationPhotinoApp\bin\Debug\net10.0> .\HeavyCalculationPhotinoApp.exe
Photino.NET: "Photino".SetTitle(HeavyCalculationPhotinoApp)
Intensive calculations are running in background...
Photino.NET: "HeavyCalculationPhotinoApp".SetUseOsDefaultSize(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetMaximized(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetContextMenuEnabled(False)
Photino.NET: "HeavyCalculationPhotinoApp".SetIgnoreCertificateErrorsEnabled(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetJavascriptClipboardAccessEnabled(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetMediaAutoplayEnabled(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetMediaStreamEnabled(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetWebSecurityEnabled(False)
Photino.NET: "HeavyCalculationPhotinoApp".SetFileSystemAccessEnabled(True)
Photino.NET: "HeavyCalculationPhotinoApp".SetNotificationsEnabled(False)
Photino.NET: "HeavyCalculationPhotinoApp".LoadRawString(started)
Progress: 0 / 100000000
Photino.NET: "HeavyCalculationPhotinoApp".LoadRawString(Working hard - Progress: 0 / 100000000 (0))
Progress: 1000000 / 100000000
Photino.NET: "HeavyCalculationPhotinoApp".LoadRawString(Working hard - Progress: 1000000 / 100000000 (1000...)
Fatal error.
0xC0000005
   at Photino.NET.PhotinoWindow.<Photino_NavigateToString>g____PInvoke|32_0(IntPtr, Byte*)
   at Photino.NET.PhotinoWindow.Photino_NavigateToString(IntPtr, System.String)
   at Photino.NET.PhotinoWindow+<>c__DisplayClass320_0.<LoadRawString>b__0()
   at Photino.NET.PhotinoWindow.<Photino_WaitForExit>g____PInvoke|56_0(IntPtr)
   at Photino.NET.PhotinoWindow.<Photino_WaitForExit>g____PInvoke|56_0(IntPtr)
   at Photino.NET.PhotinoWindow.Photino_WaitForExit(IntPtr)
   at Photino.NET.PhotinoWindow.<WaitForClose>b__369_3()
   at Photino.NET.PhotinoWindow.Invoke(System.Action)
   at Photino.NET.PhotinoWindow.WaitForClose()
   at HeavyCalculationPhotinoApp.Program.Main(System.String[])
```

`Photino.NET` Nuget version is `4.0.16`. (https://www.nuget.org/packages/Photino.NET/4.0.16),
depends on `Photino.Native` version `4.0.22`; latest at the moment.