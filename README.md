# C#, .NET, Visual Studio, VSCore #

The code in this repository is valid for anyone learning C#.  It was developed over time in teaching two courses - the MTA 98-361 Software Development course and the formal 70-483 (20483M) Programming In C# course from Microsoft.

Neither of these courses are particularly fresh or current so I have created a fresh push in my own learning by buying Mark Price's amazing book [C# 7.1 and .NET Core 2.0](https://www.amazon.com/7-1-NET-Core-2-0-Cross-Platform-ebook/dp/B0751HBGHK) and taking notes on it, particuarly the parts on .NET Core which is all new to me.  The result is the notes below which at the moment is nearly completely specific to Mark's book.

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

Tuple is a custom object which can hold regular data types.  There are two ways to write and create tuples.

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

String methods

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

### LINQ distinct	

* LINQ Providers

	LINQ to objects

	LINQ to entities

	LINQ to XML

	LINQ to Odata

	LINQ to Amazon

* Lambda expressions

* LINQ query comprehension syntax

	* from

	* in

	* where

	* orderby

	* descending

	* select

Any collection which already implements IEnumerable<T> can have the Enumerable static class appended to it and this will enable LINQ Where and Select etc to be used on that collection.  This includes all List<T> etc items and even DBSet<T>



# Chapter 13 : Multitasking, Async, Diagnostics and Performance

# Chapter 14 : ASP.NET Core Razor

## Tutorial : Building An App using ASP.NET Core Razor

https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start

# Chapter 15 : ASP.NET Core MVC, Testing, Config, Authentication, Routes, Models, Views, Controllers, 

# Chapter 16 : Web Services, Web Applications, Angular, React, REST API

# Chapter 17 : XAML, Fluent, UWP for Win10/XBOX/Halo

# Chapter 18 : XAMARIN, Mobile Apps, Mobile Forms

# Glossary

[Prime Numbers](#prime-numbers)

### Func<T1,T2>() delegate

The Func<T1,T2>() delegate accepts a method which accepts one type as an input and one type as an output

See LINQ for a worked example


XNA

## DeleteMeRandomRevision



