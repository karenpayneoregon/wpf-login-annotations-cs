
This project is a port from ValidationLibrary created using .NET Framework 4.7.2. 

Created a new class project setup for .NET Core, C#9.

Double click the project file in Solution Exporer and add `LangVersion`, `TargetFramework`.
```xml
<PropertyGroup>
  <LangVersion>9.0</LangVersion>
  <TargetFramework>net5.0-windows</TargetFramework>
</PropertyGroup>
```

Build project, receive a compile error

> CS7069: Reference to type 'DependencyObject' claims it is defined in 'WindowsBase', but it could not be found Module 'WindowsBase.. Version =4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35' should be referenced

Add the following which adds the package `Microsoft.WindowsDesktop.App.WPF` to project dependencies.

```xml
<UseWPF>true</UseWPF>
```

</br>

```xml
<PropertyGroup>
  <LangVersion>9.0</LangVersion>
  <TargetFramework>net5.0-windows</TargetFramework>
  <UseWPF>true</UseWPF>
</PropertyGroup>
```

Rebuild, success.