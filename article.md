# Porting .NET Frameworks tips

Common practice for coders when upgrading from an older .NET Framework to a newer .NET Framework is to take a working project and load into Visual Studio, make changes and run into issues with no recourse to revert changes.

When asking them to revert to a working copy of the project using source control nine times out of ten they have no clue what source control is or it’s too much trouble to learn. 

### Recommendation 1 classic .NET Framework to newer version class Framework

Learn for instance to work with GitHub repositories as Visual Studio works well with [using Git experience](https://docs.microsoft.com/en-us/visualstudio/version-control/git-with-visual-studio?view=vs-2019) in Visual Studio. Follow instructions on [this page](https://karenpayneoregon.github.io/visual-studio/gitIntro.html) to join GitHub.

Create a GitHub repository for your project, commit and push as per [this page](https://karenpayneoregon.github.io/visual-studio/gitIntro.html).

Change .NET Framework to a newer version, build. If successful commit and write a good comment. If failure do not commit, instead work through the issues until the code builds and runs successfully. On a successful build commit with a good comment. If there seems to be no resolution asked in Microsoft Q&A forums and Stackoverflow for assistance. Continue until satisfied or revert changes if the problem cannot be resolved.

### Recommendation 2 classic .NET Framework to .NET Core

:heavy_check_mark:  This repository code is a great example.

There are tools and porting tools found here. Before starting read the documentation then;

Learn for instance to work with GitHub repositories as Visual Studio works well with [using Git experience](https://docs.microsoft.com/en-us/visualstudio/version-control/git-with-visual-studio?view=vs-2019) in Visual Studio. Follow instructions on [this page](https://karenpayneoregon.github.io/visual-studio/gitIntro.html) to join GitHub.

Create a GitHub repository for your project, commit and push as per [this page](https://karenpayneoregon.github.io/visual-studio/gitIntro.html).

Next, create a .NET Core project e.g. if porting class projects and frontend projects. 

Create the class supporting projects first. For example, the .NET classic project is named DataLibrary, name the new project DataLibraryCore.

Copy classes from the .NET classic Framework project to the new .NET Core project.

Open each class and change the namespace to match the new project namespace.

Build the new project, go through each error and resolve one at a time. In some cases a NuGet package may be needed while in other cases a updated version of a reference. 

Newer references for .NET 5 are located under `C:\Program Files\dotnet\packs\Microsoft.WindowsDesktop.App.Ref\5.0.0\ref\net5.0` for windows applications.

For WPF, in a class project, make sure to double click on the project in Solution Explorer and add **&lt;UseWPF&gt;true&lt;/UseWPF&gt;**

```xml
<PropertyGroup>
  <LangVersion>9.0</LangVersion>
  <TargetFramework>net5.0-windows</TargetFramework>
  <UseWPF>true</UseWPF>
</PropertyGroup>
```

Doing so will ensure the proper references are added by Visual Studio.

Next repeat for any remaining class projects.


Now the next step is optional yet recommended. Create a unit test project for the new .NET Core projects and test each method to ensure everything works. Not only does this confirm code works properly or not this also assist when porting frontend projects. Unit test methods on class projects that work and fail in frontend project will allow a developer to concentrate on frontend code rather than backend code.

### Summary

The information presented here along with code in this repository lay the ground work for upgrading .NET solutions from classic Framework version to a newer classic Framework version and classic Framework to .NET Core. Although C# is the selected language the same applies to VB.NET.


