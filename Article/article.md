# Working with data annotations

## Overview

Present bare bones code samples for validating data using data annotations.

The .NET Framework uses many different approaches for validation. In this repository, there is a simple example for WPF using a local class project for validating properties in a class, which test for string length and rules for setting a password. It is intentional to keep MVVM out of the code samples so that new developers can have an easy working solution.

## Projects
The project [ValidateLogin](https://github.com/karenpayneoregon/wpf-login-annotations-cs/tree/master/ValidateLogin) is a WPF C# (not MVVM) project using data annotations on properties in a class representing a login. Beings this is a simply example there is no reading or updating tables in a database or a validation for if a current password is valid. Each property has rules ranging from string length to rules, which make up a decent password along with validating when the user types in the password they need to also confirm the new password done using a data annotation.

The project [ValidateLogin1](https://github.com/karenpayneoregon/wpf-login-annotations-cs/tree/master/ValidateLogin1) is a Windows form project which uses the exact same validation done in ValidateLogin which differs from the WPF only by using form logic verses how things are done in WPF.

The project [WindowsFormApp1](https://github.com/karenpayneoregon/wpf-login-annotations-cs/tree/master/WindowsFormsApp1) is how a developer might perform validation not using data annotations.

The project [ValidationLibrary](https://github.com/karenpayneoregon/wpf-login-annotations-cs/tree/master/ValidationLibrary) contains base code logic for performing valiation on properties of a class.

