# C#, .NET, Visual Studio, VSCore #

[Random Terms](#random-terms)

[ToDo](#to-do)

## To Do

Check out the cloud IDE which can do multiple languages

## Random Terms

dotnet new classlib  make new DLL

dotnet new console make new console app

dotnet build

Enumerable.Range(1,5000).toArray();  // create array 1 to 5000

GC.Collect()

GC.WaitForPendingFinalizers  wait for all garbage collection to complete

GetCurrentProcess().WorkingSet64    RAM in use

GetCurrentProcess().VirtualMemorySize64   

## Introduction

## Resources

Code for the book is found here [https://github.com/markjprice/cs7dotnetcore2](https://github.com/markjprice/cs7dotnetcore2)

## Topics Covered

.NET Standard

.NET Native

.NET Core

.NET CLI

.NET Standard 2.0

ASP.NET Core 2.0

Entity Core 2.0

C# 7.1

XAMARIN

Autoformat code

EF Core Fluent API

ASP.NET Core Razor

XNA 

## Chapter 1 : Visual Studio, VSCode, Windows, MAC, Linux, .NET, .NET Framework, .NET Core, .NET Standard, .NET Native

### IDE

[MonoDevelop](http://monodevelop.com)

[Amazon Cloud 9](https://aws.amazon.com/cloud9/?origin=c9io)

[REPL.it](https://repl.it/repls)

### VSCode

Install the .NET Core SDK

VSCode Extensions - Command Shift X

Install the C# extension to provide intellisense

### .NET

Three libraries

	.NET Framework

	.NET Core

	XAMARIN 

.NET Standard 2.0 operates across all three platforms to provide uniformity

.NET Framework is Windows only

[Mono Project](https://www.mono-project.com)

.NET Core

	CoreCLR

	CoreFX libraries

	.NET Core 1 2016
	.NET Core 2 2017
	.NET Core 2.1 2018


.NET Native 

	Compiles AoT Ahead Of Time which improves execution speed and reduces memory footprint

.NET 

	Compiles to CIL then JIT Just In Time at Runtime

### Hello World .NET Core

```bash
dotnet new console
```

will generate a new Console app project

```bash
dotnet run 
```

will run the app!!!

We can also build a `dll` library file using the following

```bash
dotnet new classlib
```

and we can use and reference this library with direct code, for example

```csharp
 using System;
using deletemecs02;

namespace deletemecs01
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance02 = new Phil();
            instance02.someNumber = 22;
            Console.WriteLine("Hello World! " + instance02.someNumber);
        }
    }
}
```

where we can see we have referenced the `dll` in our `using` statement.  In order to reference this `dll` correctly we have added the literal path to our csproj file

```xml
<ItemGroup>
  <Reference Include="deletemecs02">
    <HintPath>..\deletemecs02\bin\Debug\netstandard2.0\deletemecs02.dll</HintPath>
  </Reference>
</ItemGroup>
```

### Autoformatting

Code can be autoformatted with Edit, Advanced, Format Document.


## Chapter 2 : Variables

## Chapter 3 : Conditional Operators, Exceptions

## Chapter 4 : Functions, DRY, Debugging, Testing

## Chapter 5 : Classes, Aggregation, Encapsulation, Tuples, 

## Chapter 6 : Interfaces, Inheritance, Operators, Delegates, Events, Polymorphism, Extension Methods, Casting With Inheritance

## Chapter 7 : .NET Standard, .NET Core, Deployment

## Chapter 8 : Handling numbers, handling strings, Collections, Internationalization

## Chapter 9 : Files, Streams, Serialization, Encoding

## Chapter 10 : Encryption, Hashing, Signing, Authentication, Authorization

## Chapter 11 : Entity Core, SQL, SQLite, 

## Chapter 12 : LINQ

## Chapter 13 : Multitasking, Async, Diagnostics and Performance

## Chapter 14 : ASP.NET Core Razor

## Chapter 15 : ASP.NET Core MVC, Testing, Config, Authentication, Routes, Models, Views, Controllers, 

## Chapter 16 : Web Services, Web Applications, Angular, React, REST API

## Chapter 17 : XAML, Fluent, UWP for Win10/XBOX/Halo

## Chapter 18 : XAMARIN, Mobile Apps, Mobile Forms

## Glossary

XNA

## DeleteMeRandomRevision


