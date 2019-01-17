# C#, .NET, Visual Studio, VSCore #

The code in this repository is valid for anyone learning C#.  It was developed over time in teaching two courses - the MTA 98-361 Software Development course and the formal 70-483 (20483M) Programming In C# course from Microsoft.

Neither of these courses are particularly fresh or current so I have created a fresh push in my own learning by buying Mark Price's amazing book [C# 7.1 and .NET Core 2.0](https://www.amazon.com/7-1-NET-Core-2-0-Cross-Platform-ebook/dp/B0751HBGHK) and taking notes on it, particuarly the parts on .NET Core which is all new to me.  The result is the notes below which at the moment is nearly completely specific to Mark's book.

[Random Terms](#random-terms)

Gulp - repetitive task manager

Webpack - compiles, transpiles and bundles source code

Tuples are small, lightweight, custom-made objects that make it easier to return one object as the result of an operation.  For example if a method returns one object we can create a tuple to be the return type.

Tuples always existed but now we can also name the items within, and create faster struct ValueTuples which are mutable and all the fields are public, like a struct

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

GC.Collect()

GC.WaitForPendingFinalizers  wait for all garbage collection to complete

GetCurrentProcess().WorkingSet64    RAM in use

GetCurrentProcess().VirtualMemorySize64   

## Introduction

## Resources

Code for the book is found here [https://github.com/markjprice/cs7dotnetcore2](https://github.com/markjprice/cs7dotnetcore2)

[C# for absolute beginners at Microsoft MVA Virtual Academy with Bob Tabor](https://mva.microsoft.com/en-us/training-courses/c-fundamentals-for-absolute-beginners-16169)

[The New Boston has over 200 videos on C# which are excellent and to the point, a little older now but great for getting going](https://www.youtube.com/playlist?list=PL0EE421AE8BCEBA4A)

If you are interested in diving into C# here is an amazing bite-sized set of tutorials and lessons [https://csharp.2000things.com/index](https://csharp.2000things.com/index)

# Chapter 1 : Visual Studio, VSCode, Windows, MAC, Linux, .NET, .NET Framework, .NET Core, .NET Standard, .NET Native

### IDE

[MonoDevelop](http://monodevelop.com)

[Cloud 9](https://aws.amazon.com/cloud9/?origin=c9io)

[REPL.it](https://repl.it/repls)

[.NET Fiddle](https://dotnetfiddle.net)

[https://codeanywhere.com](https://codeanywhere.com)

### Visual Studio

Command + Enter to run (MAC)

Command + H to replace

Shift + Alt + C to add a new class

### VSCode

Install the .NET Core SDK

VSCode Extensions - Command Shift X

Install the C# extension to provide intellisense

### .NET

.NET is open source and can be found here [https://github.com/dotnet](https://github.com/dotnet)

Libraries

	.NET Framework on Windows only

	.NET Standard 2.0 is cross-platform

	.NET Core

	XAMARIN 

	.NET Native compiles AoT Ahead of Time to improve execution time

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

### C# latest version

In order to work with different versions of C# you can enable a given feature when it is flagged in Visual Studio, or alternatively go to the Project, Build, Advanced and set the language level there.

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

### Using a particular version of C# #

We can be sure to use a certain version of C# by modifying the .csproj file to include the following

```xml
<PropertyGroup>
   <LangVersion>latest</LangVersion>
</PropertyGroup>
```

We can replace `latest` with `default` to use C# 7.0 or we could use a specific number eg `7.3` in there also.


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

### String Parsing

```csharp
// exception
int.Parse("abc");
// safer as boolean returned to let you know if it succeeded or not
bool success = int.TryParse("abc", out output);
```

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

### Const and ReadOnly

Use instance attribute `readonly` because it can be used with a constructor and it's fine with the value changing.  `const` changes the values into literal values which become hard coded into the code, so are not so flexible.

```csharp
// don't use this
const x = 500;
```

```csharp
// use this
readonly string y;
```

### default

```csharp
// will be null
string x = default;
// will be 0
int y = default;
```

# Chapter 3 : Conditional Operators, Exceptions

### Test for a type

```csharp
if (o is int i) {  
	// use i
}
```

# Chapter 4 : Functions, DRY, Debugging, Testing

### Debugging in Visual Studio

* Run to cursor

* Set next statement

* Attach first time then reattach to process second time

* Disable breakpoints once one has been hit in order to stay on the same thread

* Command K, C then Command K, U to comment then uncomment lines

### Debug Windows

	Locals - variables

	Immediate Window - interact with your code and variables.  VSCode has Debug Console Window.

### Console output

```csharp
Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "red", true);
Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), "yellow", true);
Console.WindowWidth = 100;
Console.WindowHeight = 30;
Console.WriteLine("hello world");
```

### Trace Output

`Debug.WriteLine` comments are not compiled for `release` code.

`Trace.WriteLine` comments are always present however.

But we can control their visibility by entering an argument when we run a Console app.  We declare and use a TraceSwitch object in our code.

## Testing

TDD means writing tests before our code

`MS Test` is Microsoft's test framework.

`xUnit.net` will work with .NET Core

### Testing with xUnit in Visual Studio

1. Create Library Project with .NET Standard

2. Add .NET Core xUnit Test Project

3. Add Reference of (1) into (2)

4. Run tests!

### Testing with xUnit in Visual Studio

1. dotnet new classlib in CalculatorLib folder

2. dotnet build

3. dotnet new xunit in CalculatorUnitTests folder

4. modify .csproj to add 

```xml
<ItemGroup>
  <ProjectReference Include="..\Calculator\Calculator.csproj" />
</ItemGroup>
```

5. write your tests

```csharp
Assert.Equal(true,false);
```

6. dotnet test from the CalculatorUnitTests folder

## Functions (Methods)

If a method alters an object, good practice is to return the modified object

### Local = nested = inner function/method

### Overloading

Good practice is to use overloading to make your code appear simpler ie with less methods

### Exceptions

When creating your own own Exception objects which inherit from Exception, it is best practice to make your own three standard constructors which go with the object.  Remember constructors are not inherited so must be explicitly declared.

# Chapter 5 : Classes, Aggregation, Encapsulation, Tuples

## Classes

### Properties

Properties are methods which expose fields.

### Properties with lambda

```csharp
class MyClass{
	private string _x;
	private string _y;
	// will return both _x and _y
	public string bothFields => _x + " " + _y;
}
```



### Objects

We can create new objects from custom classes thus :

```csharp
public class CustomObject{
	public string name {get;set;}
	public int age {get;set;}
}
```

and create a new object using

```csharp
var object01 = new CustomObject{
	name = "Bob",
	age = 22
}
```
or we could use a constructor!!!

### Tuples

Tuples are small, lightweight, custom-made objects that make it easier to return one object as the result of an operation.  For example if a method returns one object we can create a tuple to be the return type.

Tuples always existed but now we can also name the items within, and create faster struct ValueTuples which are mutable and all the fields are public, like a struct

To use tuples we can use a .NET Core project or in .NET Standard we must use the Nuget Package `ValueTuple`

```csharp
// construct tuples - old CSharp declaration
Tuple<string, int> GetPerson1()
{
    return Tuple.Create("Bob", 22);
}

// construct tuples - C#7 declaration (must install Nuget ValueTuple)
(string name, int age) GetPerson2()
{
    return ("Jill", 33);
}
WriteLine($"{GetPerson2().name} is {GetPerson2().age}");

// assign tuples to variables
var tuple01 = GetPerson2();
WriteLine($"{tuple01.name} has age {tuple01.age}");

// deconstruct
(string name, int age) = tuple01;
WriteLine($"{name} has age {age}");
```

### array.Aggregate 

array.Aggregate can perform aggregate functions over an array eg sum the values

```csharp
var nums = new[]{1,2,3,4};
var sum = nums.Aggregate( (a,b) => a + b);
Console.WriteLine(sum); // output: 10 (1+2+3+4)
```



# Chapter 6 : Interfaces, Inheritance, Operators, Delegates, Events, Polymorphism, Extension Methods, Casting With Inheritance

## Events

### Predefined events

Microsoft has predefined two event delegates

```csharp
public delegate void handler01 (object sender, EventArgs e);
public delegate void handler02<TEventArgs> (object sender, EventArgs e);
```





# Chapter 7 : .NET Standard, .NET Core, Deployment

APIs in use for .NET 2.0 are here [https://docs.microsoft.com/en-us/dotnet/api/](https://docs.microsoft.com/en-us/dotnet/api)

.NET 2.0 is open source and documented on GitHub here [https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md)

The differences in the versions can be found here [https://github.com/dotnet/standard/blob/master/docs/versions.md](https://github.com/dotnet/standard/blob/master/docs/versions.md)

### .NET project types

```bash
dotnet new console

dotnet new web 

dotnet new mvc 

dotnet new razor 

dotnew new angular 

dotnet new react 

// list temmplates
dotnet new -l 

dotnet restore

dotnet build

dotnet test 

dotnet migrate 

dotnet pack 

dotnet publish

dotnet add package newtonsoft.json 

```

# Chapter 8 : Handling numbers, handling strings, Collections, Internationalization

### String methods

.StartsWith()
.Contains()
.Trim()/TrimStart()/TrimEnd()
.ToUpper/Lower
.Insert/Remove
.Replace
.Concat
.Join
.IsNullOrEmpty
.IsNullOrWhitespace
.Empty
.Format

## Collections

### Arrays

To build a large array and put data in it as well we can code the following

```csharp
// create array 1 to 5000
Enumerable.Range(1,5000).toArray();
```

### Sets

Sets are useful to determine the intersection

### Sorting

Cannot sort Dictionary, Queue, Stack

Can sort SortedDictionary, SortedList, SortedSet

### BitArrray is a collection of 1 and 0

### Immutable collection

## Networking

Dns

Uri

	Scheme

	AbsolutePath

	Port

	Host

	Query

Cookie

WebClient

IPAddress

HttpStatusCode

HttpWebRequest

HttpWebResponse

Attachment

MailAddress

MailMessage

SmtpClient

IPStatus

NetworkChange

Ping

TcpStatistics




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

Let's work through EFCore with SQL using Visual Studio

```bash
# install EFCore SQL binaries
install-package Microsoft.EntityFrameworkCore.SqlServer -ProjectName EFCore_01
```

## EF Core uses

### Conventions

```csharp
class Products{
	DbSet<T>
}
```

###	Annotation Attributes

```csharp
[Required]
[StringLength(40)]
public string ProductName{get;set;}
```

### FluentAPI

```csharp
class Northwind{
	modelBuilder.Entity<product>()
		.Property(product=>product.ProductName)
		.IsRequired()
		.HasMaxLength(40);
}
```

Build 3 classes : Northwind.cs, Category,cs and Product.cs

Here is the working code which queries Northwind database for two classes, Category and Product, using SQL with Visual Studio.  Note that later on is some more well-commented code.

```csharp
using System;
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Entity_10_Core_01
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var categories = db.Categories.Include(category => category.Products);
                foreach(Category c in categories)
                {
                    WriteLine($"{c.CategoryID}{c.CategoryName} has {c.Products.Count} products");
                }

            }
        }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

        }
    }
}
```







# Chapter 12 : LINQ

## SQLite

download graphic utility at [https://sqlitestudio.pl/index.rvt](https://sqlitestudio.pl/index.rvt)

### SQLite with Northwind

Download Northwind.sql from [https://github.com/markjprice/cs7dotnetcore2/edit/master/sql-scripts/Northwind4SQLite.sql](https://github.com/markjprice/cs7dotnetcore2/edit/master/sql-scripts/Northwind4SQLite.sql)

Run

```bash
# Run Northwind.sql script to make Northwind.db database
sqlite Northwind.db < Northwind.sql
```

### EF Core 

EFCore is different to EF6 Entity Framework 6.

EFCore supports Azure Cosmos DB, Mongo DB and Redis

EFCore documentation is here [https://docs.microsoft.com/en-us/ef/core/index](https://docs.microsoft.com/en-us/ef/core/index)

### EF Core Data Providers

EF Core Data Providers are classes which are optimised for talking to a specific database

ASP.NET Core contains all of these packages anyway for SQL and SQLite.

If we create a console app we must manually add them though

Packages to add

	SQL 		Microsoft.EntityFrameworkCore.SqlServer (search EFCore Sql)

	SQLite 		Microsoft.EntityFrameworkCore.SQLite 

	MySQL 		MySQL.EntityFrameworkCore

### Nuget Package Manager Console

To see what packages are already installed we can use the following

```bash
# find existing packages
Get-Package 
```

To install packages using Nuget console we can use the following commands

```bash
# search for a package
Find-Package SQLite
```

Once found we can install it

```bash
# install package
Install-Package Microsoft.EntityFrameworkCore.SQLite -ProjectName name-of-project
```



### SQLite Project with .NET Core Console App in Visual Studio

Create .NET Core Console app

Here is a working app which pulls in both Categories but for each Category, also pulls in the products

```csharp
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;

namespace Entity_08_Northwind_Category_Product_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
        }
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have");
                var categories = db.Categories.Include(c => c.Products);
                foreach (var c in categories)
                {
                    WriteLine($"\n\n{c.CategoryName} has ID {c.CategoryID} and description {c.Description}.  It has {c.Products.Count} products\n");
                    WriteLine($"{"Product",-40}{"ID",-20}{"Cost",-20}{"Stock",-20}");
                    WriteLine($"{"-------",-40}{"--",-20}{"----",-20}{"-----",-20}");
                    foreach (Product p in c.Products)
                    {
                        WriteLine($"{p.ProductName,-40}{p.ProductID,-20}{p.Cost,-20}{p.Stock,-20}");
                    }
                }

                WriteLine("\n\n\nAlso list products\n");
                decimal price = 40.0M;

                var products = db.Products;

                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (Product product in products)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20}");
                }

                var products2 = db.Products
                    .Where(product => product.Cost > price)
                    .OrderByDescending(product => product.Cost);

                WriteLine("\n\n\nProducts in order greater than a set price\n");
                WriteLine($"{"Product",-40}{"Stock",-20}{"Cost",-20}\n");
                foreach (Product product in products2)
                {
                    WriteLine($"{product.ProductName,-40}{product.Stock,-20}{product.Cost,-20}");
                }
            }
        }


    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            this.Products = new List<Product>();
        }
    }
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Column("UnitPrice", TypeName = "money")]
        public decimal? Cost { get; set; }
        [Column("UnitsInStock")]
        public short? Stock { get; set; }
        public bool Discontinued { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
            // use SQLite
            //optionsBuilder.UseSqlite($"Filename={path}");
            // use SQL
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
```

### Loading data from Entity : Lazy, Eager and Explicit Loading

***Lazy loading*** queries are only run when the data is actually needed

The `virtual` keyword is used so that Entity can generate a derived child class which overrides the default implementation with a lazy loading implementation.

Eager loading is used when the `include` keyword is used

Explicit loading is used when the `Load()` method is used

### `virtual` keyword in Entity

When the `virtual` keyword is used then lazy loading is used by default

### EFCore Logging

We can log database interactions so we are sure of what we are doing

### `like` EFCore SQL command

We can use the following to query matches of partial words in our results 

```csharp
WriteLine("\n\nNow using 'like' keyword to search using part of product name");
var likeString = "che";
// find product names containing 'che'
var products3 = db.Products
    .Where(product => EF.Functions.Like(product.ProductName, $"%{likeString}%"));
foreach(Product p in products3)
{
    WriteLine($"{p.ProductName} has {p.Stock} items in stock at price {p.Cost}");
}
```

### EF Global Filters

We can now design global filters to always exclude results regardless, from all results.  So to exclude discontinued products we can add the following code to the Model builder code:

```csharp
modelBuilder.Entity<Product>().hasQueryFilter(p=>!p.Discontinued);
```

### Entity : Inserting new products

We can add a new method to add products

```csharp
static bool AddProduct(int CategoryID, string ProductName, decimal? Price, short? Stock, out int ProductID)
{
    using (var db = new Northwind())
    {

        var product = new Product
        {
            CategoryID = CategoryID,
            ProductName = ProductName,
            Cost = Price,
            Stock = Stock
        };

        db.Products.Add(product);
        int affected = db.SaveChanges();
        ProductID = product.ProductID;
        return (affected == 1);
    }
    
   
}
```

Then just call it with

```csharp
bool addProductSuccess = AddProduct(6, "Curried Beef Pie", 47.00M, 150, out int productID);
WriteLine($"\n\nNew product added - successful? {addProductSuccess} - new ID {productID}\n\n");
```

### Entity : Updating Products

We can update a product with the following code

```csharp
static bool UpdateCost(int productID,decimal newCost)
{
    using (var db = new Northwind())
    {
        Product product = db.Products.First(p => p.ProductID == productID);
        product.Cost = newCost;
        int affected = db.SaveChanges();
        return (affected == 1);
    }
}
```

Then call it with

```csharp
int newCost = 100;
bool updateCostSuccess = UpdateCost(productID, newCost);
WriteLine($"{productID} has been updated with new cost of {newCost}");        
```

### Entity : Deleting Products

We can delete multiple items with the code

```csharp
static int deleteProduct(int productID) {
    using (var db = new Northwind())
    {
        // note that this produces a collection of products for multiple deletion
        var productsToDelete =
            db.Products.Where(p => p.ProductID == productID);
        db.Products.RemoveRange(productsToDelete);
        int affected = db.SaveChanges();
        return affected;
    }
}  
```

Then call it with 

```csharp
int numProductsDeleted = deleteProduct(productID);
WriteLine($"{numProductsDeleted} product has been deleted which had ID {productID}");        
```

### Explicit Transactions

Explicit transactions can lock the database to prevent alterations whilst it is in use.  This helps ensure the ACID syntax

Atomic - all transactions commit, or none

Consistent - database state is consistent before and after

Isolated - changes are hidden from other processes until complete

Durable - if a failure occurs then we can recover and roll back 

Snapshot - copies of records are made whilst being updated, so others can still read the data

## LINQ 

LINQ Components :

* Extension Methods

	such as

		* Where

	These are enabled when we add

```csharp
using System.Linq;
```

### Extension methods using older Func<T1,T2>() delegate

The Func<T1,T2>() delegate accepts a method which accepts one type as an input and one type as an output

We can use

```csharp
Func<string,bool>()
```

which indicates that the method must accept a string and return a boolean true or false.  If it's true, include the string in the query, if not then exclude it.

Here is some code illustrating this Function delegate at work

```csharp
static void Main(string[] args)
{
	// declare array
    string[] myArray = { "George", "Michael", "Rob", "Paul" };
    // using explicit Func<string,bool>()
    WriteLine("\n\nQuery strings greater than length 4\n");
    var query = myArray.Where(new Func<string, bool>(LengthGreaterThan4));
    foreach (string s in query)
    {
        WriteLine(s);
    }
}
static bool LengthGreaterThan4(string s)
{
    return s.Length > 4;
}
```

We can also repeat this using more modern syntax in two other ways.

Firstly using implicit syntax which is the same but just removes the explicit Function delegate syntax

```csharp
// using implicit newer syntax
var query2 = myArray.Where(LengthGreaterThan4);
foreach(string s in query2)
{
    WriteLine(s);
}
```

And finally using the more compact Lambda syntax which removes the need for a separate method altogether

```csharp
// finally repeat using Lambda
var query3 = myArray.Where(s => s.Length > 4);
WriteLine(string.Join(",", query3));
```


### LINQ .orderby extension method

```csharp
// orderby
WriteLine("\n\nNow add .orderby() length");
var query4 = myArray.Where(s => s.Length > 3)
    .OrderBy(s => s.Length);
WriteLine(string.Join(", ", query4));

// order alphabetical descending
WriteLine("\n\nNow sort descending alphabetically");
var query5 = myArray
    .Where(s => s.Length > 3)
    .OrderByDescending(s=>s);
WriteLine(string.Join(", ", query5));
```

### LINQ chaining .orderby() using .thenby() methods

We can chain multiple .orderby() queries using .thenby() afterwards

```csharp
// order by length then alphabetical
WriteLine("\n\nNow sort by length then alphabetical");
var query6 = myArray
    .Where(s => s.Length > 3)
    .OrderBy(s => s.Length)
    .ThenBy(s => s);
WriteLine(string.Join(", ", query6));
```

### Distinct() : Eliminate duplicates

```csharp
string[] array02 = { "three", "three", "four", "five", "six" };
WriteLine("\n\nFirstly extract only distinct values");
// will omit the duplicate value
WriteLine(string.Join(", ", array02.Distinct()));
```	

### Union() : join two sets then eliminate duplicates

```csharp
string[] array01 = { "one", "two", "three", "four" };
string[] array02 = { "three", "three", "four", "five", "six" };
WriteLine("\n\nNow Union() 2 arrays which eliminates duplicates");
WriteLine(string.Join(", ", array01.Union(array02)));
```

### Concat() : Join 2 sets and keep all elements

```csharp
WriteLine("\n\nNow Contat() which joins and keeps all elements");
WriteLine(string.Join(", ", array01.Concat(array02)));
```

### Intersect() : Only common members of 2 sets

```csharp
WriteLine("\n\nIntersect shows items in both sets");
WriteLine(string.Join(", ", array01.Intersect(array02)));
```

### LINQ Except()

### LINQ Zip() : Create pairs from items 1, 2, 3 etc in two sets of data

Zip is an unusual one but can be quite useful in that is matches the first two items, the next two, etc

```csharp
WriteLine("\n\nZip matches the first with the first, and so on");
// Create an enumerable collection of strings
var arrayOfPairs = array01.Zip(array02, (a, b) => $"{a} with {b}");
WriteLine(string.Join(", ", arrayOfPairs));
```

### LINQ IQueryable vs IEnumerable

IQueryable is using lazy loading

IEnumerable is using immediate execution

### LINQ Providers

LINQ to objects

LINQ to entities

LINQ to XML

LINQ to Odata

LINQ to Amazon

### LINQ query comprehension syntax

This is a limited subset of LINQ.

To use all the features of LINQ we must use `extension methods` with `lambda expressions`.

Here is an example of `extension method` syntax with `lambda expressions`

```csharp
var output = myArray
	.Where(s=>s.length>4)
	.OrderBy(s=>s.length)
	.ThenBy(s=>s);
```

Here is the same code using `LINQ query comprehension syntax`.

```csharp
var output = 
	from s in myArray
	where s.length > 4
	orderby s.length, s
	select s;
```

We can combine the two features if we want some methods which are not available, for example 

```csharp
var output = (
	from s in myArray
	where s.length>4
	orderby s.length, s
	select s).Skip(80).Take(10);
```

* from

* in

* where

```csharp
var output = 
	from s in myArray
	where s.length > 4
	orderby s.length, s
	select s;
```

* orderby

```csharp
var output = 
	from s in myArray
	where s.length > 4
	orderby s.length, s
	select s;
```

* descending



* select

select is mandatory here

Any collection which already implements IEnumerable<T> can have the Enumerable static class appended to it and this will enable LINQ Where and Select etc to be used on that collection.  This includes all List<T> etc items and even DBSet<T>

### skip

Skip allows us to do pagination

### take

Take allows us to do pagination by only selecting the next few records

### LINQ to XML

We can generate XML output from a LINQ query

```csharp
WriteLine("\n\nTranslating To XML\n");
var ProductsToXML = db.Products.Take(3);
var xml = new XElement("products",
    from p in ProductsToXML
    select new XElement("product",
    new XAttribute("id",p.ProductID),
    new XAttribute("price",p.Cost),
    new XElement("name",p.ProductName)));
WriteLine(xml.ToString());
```




# Chapter 13 : Multitasking, Async, Diagnostics and Performance

# Chapter 14 : ASP.NET Core Razor

## Chrome Dev Tools

Open Dev Tools with 

	Command - Alt - I
	F12
	Control - Shift - I

Networking Tab

Reload the page

## History of Microsoft Web Pages

* ASP 1996

* ASP.NET Web Forms 2002

	Used in Sharepoint

* WCF 2006

	SOAP (complex, avoid)

	REST

* ASP.NET MVC 2009

* ASP.NET WEB API 2012

	HTTP REST simpler than SOAP

* ASP.NET SignalR 2013

	Websockets

	Long Polling

* ASP.NET Core 2016

	MVC
	Web API
	SignalR

* Kestrel Web Server
	
	Open source

	Cross Platform


### ASP.NET Core Walkthrough 

New Visual Studio 2017, ASP.NET Core Web App, Empty Template

or in VSCode

```bash
dotnet new web
```

Note that in .csproj file we have `.AspNetCore.All` which includes all `EFCore` and `ASP.NET Core` dependencies.

Now add `index.html` file to the `wwwroot` folder

Also in `Startup.cs` configure out the method which returns `Hello World` and instead add

```csharp
app.UseStaticFiles();
```

now if we run the site and manually append `/index.html` to the end of the running URL, the site will be visible.

and if we now add on the line before this code also

```csharp
app.UseDefaultFiles();
```

Razor pages have .cshtml which can combine C# with HTML

To use Razor, create a folder called `Pages` and move the `index.html` file into that folder out of the wwwroot folder

Also add MVC in `Startup.cs`

```csharp
public void ConfigureServices(...){
	services.AddMvc();
}
```

also add 

```csharp
app.UseMvc();
```

Now modify `index.cshtml` to include the following

```csharp
@page
@functions{
	public 
}
```

### Summary So Far

```bash
# create new application
dotnet new web
```

```xml
<!-- add wwwroot folder -->
<Folder Include="wwwroot" />
```

```bash
mkdir wwwroot
touch index.html 
```

Allow using static files

```csharp
app.UseStaticFiles();
```

We can now manually enter /index.html and find our page

```csharp
// now will find index.html by default
app.UseDefaultFiles();
app.UseStaticFiles();
```

Add MVC Razor

```csharp
// in ConfigureServices()
services.AddMvc();
// in Configure()
app.UseMvc();
```

Now create Razor page

```csharp
@page
@functions{
  public string DayName{get;set;}
  public void OnGet(){
  	Model.DayName=DateTime.Now.ToString("dddd");
  }
}
```

```xml
<!-- will display Model field -->
<p>@Model.DayName</p>
```


### MVC Layouts

Layouts have a default layout for all pages called `_ViewStart.cshtml`

Create a new `MVC View Start Page` in Pages folder called `_Layout.cshtml`


### ViewData

ViewData is a dictionary whose key is a string.  We can use this dictionary to store values for our application

In the Suppliers.cshtml.cs page we can add in the OnGet() method

```csharp
ViewData["Title"]="Some title";
```

### Summary so far - re-building an ASP.NET Core web app with SQL and Visual Studio

```csharp
using System;
using static System.Console;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCore_01_VS_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryingCategories();
        }

        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                var categories = db.Categories.Include(category => category.Products);
                foreach(Category c in categories)
                {
                    WriteLine($"{c.CategoryID}{c.CategoryName} has {c.Products.Count} products");
                }

            }
        }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);
                
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }
}
```

### Summary So Far : ASP.NET Core Empty Website with local array using Visual Studio - ASP.NET Core Entity Razor 02

This project attemts to use the built-in Razor Visual Studio scaffolding to build a set of pages - a pre-built website built by Visual Studio.

Within this I have added just one page `Phil.cstml` and its code-behind page `Phil.cshtml.cs` and they both use Northwind to put Products on the screen.

It's the most basic example that I can think of!!!

Things to be aware of and learning points

* use DbContext not DBContext

* use non-static methods as we are instantiating the class in order to produce the results


### Further Summary Of Work So Far : Clarification Of Libraries Etc

```csharp
using Microsoft.EntityFrameworkCore;
// notice that it's DbContext with a little 'b'
public class Northwind : DbContext{}
```

```csharp
public class Customer 
{
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
}
```

These are for working with SQL server

```bash
# first one is a critical one
install-package Microsoft.EntityFrameworkCore.SqlServer -ProjectName xxx
# not sure how critical these two are
install-package Microsoft.EntityFrameworkCore.SqlServer.Design -ProjectName xxx
install-package Microsoft.EntityFrameworkCore.SqlServer.Tools -ProjectName xxx
```

Futher develop Northwind class now

```csharp
public class Northwind : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string path = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Northwind.db");
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security=true;" + "MultipleActiveResultSets=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .Property(customer => customer.ContactName)
            .IsRequired()
            .HasMaxLength(40);
        modelBuilder.Entity<Customer>()
            .Property(customer => customer.CustomerID)
            .IsRequired()
            .HasMaxLength(40);

    }
}
```

Add Pages folder

Add _ViewStart.cshtml 

```bash
@{
    Layout = "_Layout";
}
```


Add _Layout.cshtml 

```bash
<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>@ViewBag.Title</title>
</head>
<body>
    <div>
        @RenderBody()
    </div>
</body>
</html>
```





### ViewData

Exposes a Dictionary whose index is the string to be displayed

```csharp
public void OnGet(){
	ViewData["Title"]="Some Title";
}
```

```html
<h1>@ViewData["Title"]</h1>
```




### Viewbag - don't use this!

Viewbag exposes dynamic fields ie object type

Is an array of strings







### Using LINQ Lambda to get data

Instead of a traditional LINQ query we can use the following syntax

```csharp
// all customers
Customers = db.Customers;
// selection of customers
Customers = db.Customers.Where(c => c.City == CustomerCity).ToList<Customer>();
```

### GroupBy

To produce a list of customers grouped by City let's do the following

```csharp

```




### Inserting A New Record Using ASP Entity Core

Let's see if we can now insert a new record into our database from our web page

Let's add a form at the bottom of the page

Before we can do this though we need to go back and rebuild everything from scratch so here goes

Working from Chapter 14 onwards

Create a new .cshtml with accompanying .cs page - let's call this one Entity03.cshtml


Entity03.cshtml.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPEntityCore_04_VS_SQL.Pages
{
    public class Entity03Model : PageModel
    {
        public IEnumerable<string> Customers { get; set; }

        public void OnGet()
        {
            ViewData["Title"] = "Customers Page";
            Customers = new[] { "first", "second", "third" };
        }
    }
}
```

Entity03.cshtml

```html
@page
@model Entity03Model
@{
}
<h1>@ViewData["Title"]</h1>
<ol>
    @foreach (string customer in Model.Customers)
    {
        <li>@customer</li>
    }
</ol>
```

This produces a local list of customers 

Let's now connect to Northwind.

In Entity03Model.cshtml.cs add the following

```csharp
using ASPCoreEntity_03_Data;
```

and in the class `public class Entity03Model : PageModel` add

```csharp
private Northwind db;
```

and add a constructor

```csharp
public Entity03Model(Northwind injectedContext){
	db = injectedContext;
}
```

We can now in the OnGet() method invoke the Northwind database and get out data

```csharp
public void OnGet()
{
    ViewData["Title"] = "Customers Page";
    //    Customers = new[] { "first", "second", "third" };
    // Now we are outputting a very simple array of strings here
    Customers = db.Customers.Select(c => c.ContactName).ToArray();
}
 ```


Next in the Northwind class add this constructor which reads from the base class

```csharp
public class Northwind : DbContext{
	// existing code 
	// default constructor added in 
	public Northwind(){}
	// new constructor added int
	public Northwind(DbContextOptions options) : base(options) { }	
}
```

also 

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder) {
   base.OnModelCreating(modelBuilder);
}
```

Also to get Northwind to work correctly we have to inject the service.

```csharp
public class Startup
{
	...
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddDbContext<Northwind>(options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true"));
    }	
```

The code should now display names correctly from the database

### Adding a Customer

We can now try and add a customer to our page.

In our .cshtml.cs page let's add a customer element

```csharp
public class Entity04_Add_CustomerModel : PageModel
{
    public IEnumerable<Customer> Customers { get; set; }
    public Northwind db;

    [BindProperty]
    public Customer customer { get; set; }
```
And some code to deal with an HTML POST request

```csharp
public IActionResult OnPost()
{
    if (ModelState.IsValid)
    {
        db.Customers.Add(customer);
        db.SaveChanges();
        return RedirectToPage("/Entity04_Add_Customer");
    }
    return Page();
}
```


This brings us to a great point where we can now use Northwind to read records and insert new ones.

I want to develop this to bring relationships between different products etc 

I also want to develop this to be able to update records as well.

The book moves on to MVC at this point but I am keen to follow this through to get the full CRUD working for the RAZOR pages before we do the MVC, so we have a tutorial below to accomplish this using a different database.

## Tutorial : Building An App using ASP.NET Core Razor

[https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start](https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start)

Let's see if we can follow this tutorial but use the Northwind Customers database instead???

### Create Movie Project

Create a new `ASP.NET Core Web Application` and choose `Web Application` from the second page

### Create Movies class

create this class

```csharp
public class Movie
{
    public int ID { get; set; }
    public string Title { get; set; }
    // note : setting this to date means the user is not required to enter time information
    // also when displaying this field, only date information is supplied
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
}
```

### Update Northwind

We must now update Northwind class to include a DbSet<Movie> 

```csharp

```

Create a `Pages\Movies` folder

`Add` a new `Scaffolded Item` and choose `Razor Page with Entity CRUD`.

Choose the `Movies` database with the `Northwind` database context

This will update appsettings.json with the Northwind database connection string






## Tutorial : Contoso University App using ASP.NET Entity Core with Razor 

[https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro](https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro)


building in the /database folder


### Contoso University 01

This adds basic functionality for creating a Student model, reading students, adding, editing and deleting individual students.

### Contoso University 02

Adding in pagination

Adding in search box

Adding in sort the index by columns by clicking on that column


### Contoso University 03

This adds into the About page the ability to show enrolments grouped by date

### Contoso Universiy 04

This goes back to scratch and starts building again from scratch, now that I have proven I can build multiple copies of the app

New Project, ASP.NET Core Web, Web Application

Set up the menu items in Pages, Shared, _Layout 

```html
<li><a asp-page="/Students/Index">Students</a></li>
<li><a asp-page="/Courses/Index">Courses</a></li>
<li><a asp-page="/Enrollments/Index">Enrollments</a></li>
<li><a asp-page="/Rooms/Index">Rooms</a></li>
```

Add `Models` folder and add these classes

```csharp
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        // shared : for every course it will have a number 
        // of enrollments
        public ICollection<Enrollment> Enrollments { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }



    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        // unique
        public int EnrollmentID { get; set; }
        public Grade? Grade { get; set; }

        // from others
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }



    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Room{
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
```

### Scaffold the Students Database

Right click on Pages/Students and choose Add, New Scaffolded Item.

Choose `Student` Model

Add a new context and amend it to read `ContosoUniversity.Models.SchoolContext`

Repeat if necessary for `Courses` and `Enrollments`

Now update `Program.cs`

```csharp
using ContosoUniversity.Models;
using Microsoft.Extensions.DependencyInjection;

// replace Main()

public static void Main(string[] args)
{
    var host = CreateWebHostBuilder(args).Build();

    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<SchoolContext>();
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }

    host.Run();
}

```






## Tutorial : Razor from scratch


Introduction to Razor

[https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio)


Razor is part of ASP.NET Core MVC

perhaps look at the MVC another time

Let's create ASPRazor_01

Startup.cs

	Razor is enabled by adding it as a service

```csharp
services.AddMvc()
```

also

```
app.UseMvc()
```

.cshtml

@page makes this into an MVC action which handles requests without going through a controller

@page must be the first thing on a page

We can use fields like @DateTime.Now

We can expose Model fields in the .cs below

```csharp
public class Page : PageModel{
	public string myProperty{get;set;}= "default value";
	public void OnGet(){
	  myProperty+=" on DateTime.Now";
	}
}
```

/ reaches Index.cshtml

/Page reaches Page.cshtml

/Folder/ reaches /Folder/Index.cshtml


Razor is designed to make Model binding and Tag helpers all work 

Startup.cs is used to initialize DbContext

```csharp
public void ConfigureServices...
	services.addDbContext<AppDbContext>(options=>options.UseInMemoryDatabase("name"))
```


add data model in Data folder

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASPRazor_01.Data
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}
```

then add

```csharp
using Microsoft.EntityFrameworkCore;

namespace ASPRazor_01.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
```

and

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASPRazor_01.Data;
using System.ComponentModel.DataAnnotations;

namespace ASPRazor_01.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        public CreateModel(AppDbContext db) {
            _db = db;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}
```

# Chapter 15 : ASP.NET Core MVC, Testing, Config, Authentication, Routes, Models, Views, Controllers, 


## MVC

### New MVC App

Visual Studio, New Web Core App with MVC, individual user authentication stored in app

	wwwroot 	Static Content

	Data 		ASP Identity : Authentication + Authorisation

	Dependencies

	Nuget 		Check out .csproj file

	Models 		Database tables

					Actions will fetch model and pass to view

	View  		.cshtml files

	Services 	

	Extensions

	appsettings.json 	load settings

	bower.json 			client-side packages

	Program.cs 			

	Startup.cs



# Chapter 16 : Web Services, Web Applications, Angular, React, REST API

# Chapter 17 : XAML, Fluent, UWP for Win10/XBOX/Halo

# Chapter 18 : XAMARIN, Mobile Apps, Mobile Forms

# Glossary

[Prime Numbers](#prime-numbers)

### Func<T1,T2>() delegate

The Func<T1,T2>() delegate accepts a method which accepts one type as an input and one type as an output

See LINQ for a worked example

### Lambda

Lambdas are a brief way of writing a method.

One advantage of Lambdas is that particularly when we are executing a loop they can perform quick one-line method calcuations to obtain results very quickly and easily.

For example if we have an array with some elements null

```csharp
string[] myArray = { "a", "b", "c", null, "e"};
```

we can clone this array and remove null items very easily with Lambda

```csharp
var clone01 = myArray.Where(item => item != null);
```

or removing items which are null or "" (empty strings)

```csharp
var clone02 = myArray.Where(item => !string.IsNullOrEmpty(item));
```



### XNA
