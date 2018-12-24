# C#, .NET, Visual Studio, VSCore #

[Random Terms](#random-terms)

[ToDo](#to-do)

[Chapter 1 : Visual Studio, VSCode, Windows, MAC, Linux, .NET, .NET Framework, .NET Core, .NET Standard, .NET Native](#chapter-1-visual-studio-vscode-windows-mac-linux-net-net-framework-net-core-net-standard-net-native)

[Chapter 2 : Variables](#chapter-2-variables)

[Chapter 3 : Conditional Operators, Exceptions](#chapter-3-conditional-operators-exceptions)

[Chapter 4 : Functions, DRY, Debugging, Testing](#chapter-4-functions-dry-debugging-testing)

[Chapter 5 : Classes, Aggregation, Encapsulation, Tuples](#chapter-5-classes-aggregation-encapsulation-tuples)

[Chapter 6 : Interfaces, Inheritance, Operators, Delegates, Events, Polymorphism, Extension Methods, Casting With Inheritance](#chapter-6-interfaces-inheritance-operators-delegates-events-polymorphism-extension-methods-casting-with-inheritance)

[Chapter 7 : .NET Standard, .NET Core, Deployment](#chapter-7-net-standard-net-core-deployment)

[Chapter 8 : Handling numbers, handling strings, Collections, Internationalization](#chapter-8-handling-numbers-handling-strings-collections-internationalization)

[Chapter 9 : Files, Streams, Serialization, Encoding](#chapter-9-files-streams-serialization-encoding)

[Chapter 10 : Encryption, Hashing, Signing, Authentication, Authorization](#chapter-10-encryption-hashing-signing-authentication-authorization)

[Chapter 11 : Entity Core, SQLite](#chapter-11-entity-core-sql-sqlite)

[Chapter 12 : LINQ](#chapter-12-linq)

[Chapter 13 : Multitasking, Async, Diagnostics and Performance](#)

[Chapter 14 : ASP.NET Core Razor](#)

[Chapter 15 : ASP.NET Core MVC, Testing, Config, Authentication, Routes, Models, Views, Controllers](#)

[Chapter 16 : Web Services, Web Applications, Angular, React, REST API](#)

[Chapter 17 : XAML, Fluent, UWP for Win10/XBOX/Halo](#)

[Chapter 18 : XAMARIN, Mobile Apps, Mobile Forms](#)

[Glossary](#)

## To Do

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

# Chapter 1 : Visual Studio, VSCode, Windows, MAC, Linux, .NET, .NET Framework, .NET Core, .NET Standard, .NET Native

### IDE

[MonoDevelop](http://monodevelop.com)

[Amazon Cloud 9](https://aws.amazon.com/cloud9/?origin=c9io)

[REPL.it](https://repl.it/repls)

[.NET Fiddle](https://dotnetfiddle.net)

### Visual Studio

Command + Enter to run (MAC)

Command + H to replace

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

### Hello World .NET

New Project, Choose Other, Blank Solution then add projects from there

Once built we can toggle all files to view built files

### Hello World .NET Core

```bash
dotnet new console
```

will generate a new Console app project

```bash
dotnet new console -o MyApp
```

will generate a new Console app in a folder MyApp

```bash
dotnet run 
```

will run the app!!!

We can also build a `dll` library file using the following

```bash
dotnet new classlib
// compile
dotnet build
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

### Adding references

Try this using statement to save yourself a lot of typing!

```csharp
using static System.Console;
```

### Adding references in .NET Core

```csharp
#r "System.Net.Http"
using System.Net.Http;
var client = new HttpClient();
client.BaseAddress = new Uri("http://www.bbc.co.uk");
var response = await client.GetAsync("about");
Console.WriteLine(response.Content.Headers.GetValues("Content-Type"));
await response.Content.ReadAsStringAsync();
```

### Autoformatting

Code can be autoformatted with Edit, Advanced, Format Document.

### AutoSave in VSCode 

File, AutoSave - turn on 

### Debugging in Visual Studio

* Run to cursor

* Set next statement

* Attach first time then reattach to process second time

* Disable breakpoints once one has been hit in order to stay on the same thread

* Command K, C then Command K, U to comment then uncomment lines

### Console output

```csharp
Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "red", true);
Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "yellow", true);
Console.WindowWidth = 100;
Console.WindowHeight = 30;
Console.WriteLine("hello world");
```

### Git and Github and VSTS



# Chapter 2 : Variables

### Methods And Types

```csharp
foreach(var assembly in GetEntryAssembly().GetReferencedAssemblies()){
	// load then count all assemblies
}
```

### Computers Store Numbers Only Approximately

```csharp
double d1 = 0.1;
double d2 = 0.2;
if(d1+d1==0.3) Console.WriteLine("they are the same");
```

You will find they are not the same!!!

### null check operator ?.

Rather than explicitly check for `null` we can do the following

```csharp
// this string may or may not be null
string authorName = null;
// want to get the length of this string but if it's null it will throw an exception
int nameLength = authorName.length;
// so use null check operator instead which returns null rather than exception if target is null
int? nameLength = authorName?.length;
```

### null coalesce operator ??

If we want to do the same thing but return a result rather than null if the target is null we can use the `null coalesce operator ??`

```csharp
// in this case we want to return -1 if the name is null
string authorName = null;
int? nameLength = authorName.length ?? -1;
```

## Strings

### String Format

	:N0 display as a number with removing any numbers after the decimal point
	:N1 keep one decimal place
	:N2 keep two decimal places

	:C currency

	:X hexadecimal

	:E exponential number format 10E12

### String Interpolation

This is an upgrade to the String.Format command.

```csharp
Console.WriteLine($"{variable-goes-here} and some text as well");
```

### Composite Formatting

This can display strings with a given width to form a table in console output

```csharp
string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
            "Ebenezer", "Francine", "George" };
decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80,
                    16.75m };
Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");
for (int i = 0; i < names.Length; i++)
    Console.WriteLine("{0,-20} {1,5:N1}", names[i], hours[i]);
```

See String.Format_01 for worked example of this code.



# Chapter 3 : Conditional Operators, Exceptions

### Test for a type

```csharp
if (o is int i) {  
	// use i
}
```

# Chapter 4 : Functions, DRY, Debugging, Testing

# Chapter 5 : Classes, Aggregation, Encapsulation, Tuples, 

# Chapter 6 : Interfaces, Inheritance, Operators, Delegates, Events, Polymorphism, Extension Methods, Casting With Inheritance

# Chapter 7 : .NET Standard, .NET Core, Deployment

# Chapter 8 : Handling numbers, handling strings, Collections, Internationalization

# Chapter 9 : Files, Streams, Serialization, Encoding

### Path

```csharp
// combine a foder path with a text file
Path.Combine(path,"file.txt");
```


# Chapter 10 : Encryption, Hashing, Signing, Authentication, Authorization

### Secure String

Strings are best avoided altogether when it comes to passwords etc.  It is much preferred to use certifiates or Windows authentication.  Strings are stored in plain text.   Even SecureString does not stop this; it just prevents the string hanging around in memory for longer than would otherwise be the case.

```csharp
// code from 
// https://docs.microsoft.com/en-us/dotnet/api/system.security.securestring?redirectedfrom=MSDN&view=netframework-4.7.2
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;

public class Example
{
    public static void Main()
    {
        // Instantiate the secure string.
        SecureString securePwd = new SecureString();
        ConsoleKeyInfo key;

        Console.Write("Enter password: ");
        do {
           key = Console.ReadKey(true);
           
           // Ignore any key out of range.
           if (((int) key.Key) >= 65 && ((int) key.Key <= 90)) {
              // Append the character to the password.
              securePwd.AppendChar(key.KeyChar);
              Console.Write("*");
           }   
        // Exit if Enter key is pressed.
        } while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        
        try {
            Process.Start("Notepad.exe", "MyUser", securePwd, "MYDOMAIN");
        }
        catch (Win32Exception e) {
            Console.WriteLine(e.Message);
        }
        finally {
           securePwd.Dispose();
        }
    }
}
```

### Base64 Encoding

```csharp
byte[] byteArray = new byte[128];
// populate
(new Random()).NextBytes(byteArray);
// as bytes in Hex
for (int i=0;i<byteArray.Length;i++){
	Write($"{byteArray[i]:X}");
}
// as Base64
WriteLine(${Convert.ToBase64String(byteArray)});
```

# Chapter 11 : Entity Core, SQL, SQLite, 

Try this code to connect to a database, after Entity has been added to the project

```csharp
using (var db = new Northwind()) {
	var categories = db.Categories.Include(c=>c.Products);
	foreach (Category c in categories){
		WriteLine("{c.CategoryName} has {c.Products.Count} products");
	}
	// products more than a price
	decimal price = 10.0M;
	var products = db.Products.Where(product=>product.Cost>price).OrderByDescending(product=>product.Cost);
	foreach(Product p in products){
		WriteLine($"{p.ProductID} : {p.ProductName} has price {p.Cost:$#,##0.00} and stock {p.Stock}");
	}
}


```




# Chapter 12 : LINQ

# Chapter 13 : Multitasking, Async, Diagnostics and Performance

# Chapter 14 : ASP.NET Core Razor

# Chapter 15 : ASP.NET Core MVC, Testing, Config, Authentication, Routes, Models, Views, Controllers, 

# Chapter 16 : Web Services, Web Applications, Angular, React, REST API

# Chapter 17 : XAML, Fluent, UWP for Win10/XBOX/Halo

# Chapter 18 : XAMARIN, Mobile Apps, Mobile Forms

# Glossary

XNA

## DeleteMeRandomRevision



