# Welcome to Extend

[![Build Status](https://ci.appveyor.com/api/projects/status/github/DaveSenn/Extend?svg=true)](https://ci.appveyor.com/project/DaveSenn/Extend/branch/dev)
[![Coverity Scan Build Status](https://scan.coverity.com/projects/5272/badge.svg)](https://scan.coverity.com/projects/5272)

[![NuGet](https://img.shields.io/nuget/v/Extend.svg)](https://www.nuget.org/packages/Extend)
[![NuGet](https://img.shields.io/nuget/dt/Extend.svg)](https://www.nuget.org/packages/Extend)
[![GitHub issues](https://img.shields.io/github/issues/DaveSenn/Extend.svg)](https://github.com/DaveSenn/Extend/issues)

[![License](http://img.shields.io/:license-mit-blue.svg)](https://raw.githubusercontent.com/DaveSenn/Extend/dev/License.txt)

### What is this?

Extend is a set of .Net extension methods build as portable class library. 
Extend enhance the .Net framework by adding a bunch of methods to increase developer’s productivity.
Currently it contains 377 unique extension methods (623 overloads included).
### Where can I use it?
You can use it in every .Net application or library targeting one of the following profiles:
* .Net 4.5
* Windows 8
* Windows Phone 8
* Windows Phone 8.1

### How do I use it?
1. Install ["Extend"](http://www.nuget.org/packages/Extend/) via [NuGet](http://nuget.org)
__Install-Package PortableExtensions__
2. Add using for Extend ```using Extend; ```
3. Done!

### Testing
To guarantee its stability Extend contains over 1900 unit tests.
Each method has test with different input parameters, including invalid values to test the exception handling.

### Example

Array to list using a selector:
```csharp
var myArray = new[] {"1", "2", "3"};
var intValues = myArray.ToList(x => x.ToInt32());
```

Action executing based on boolean values:
```csharp
var successful = SaveData();
successful.IfTrue(() => DisplaySuccess(), () => DisplayFailure());
successful.IfFalse(() => DisplayFailure(), () => DisplaySuccess());
```

Add to collection:
```csharp
var list = new List<String>();
list.AddIf(x => new Random().Next(0, 10) % 2 == 0, "Value");
list.AddIfNotContains( "Value #1");
list.AddRange("Value #1", "Value #2", "Value #3");
list.AddRangeIfNotContains("Value #1", "Value #2", "Value #3");
list.AddRangeIf(x => new Random().Next(0, 10) % 2 == 0, "Value", "Value #2", "Value #3");
```

Working with dictionaries
```csharp
var dictionary = new Dictionary<String, String>();
dictionary.AddOrUpdate("Key", "Value");
dictionary.AddRange(new Dictionary<String, String>
{
	{ "Key1", "Value1" },
	{ "Key2", "Value2" }
});
dictionary.GetOrAdd("Key", () => "Value");
var keyValueCsv = dictionary.StringJoin("=", ", ");
```
Working with IEnumerable<T>:
```csharp
var list = new List<String>();
var containsNotNullValues = list.AnyAndNotNull();
var distinctValues = list.Distinct(x => x.Substring(0, 2));
list.ForEach(x => { });
list.ForEachReverse(x => list.Remove(x));
```
Working with DateTime:
```csharp
var dateTime = DateTime.Now;
var stringValue = dateTime.ToLongDateShortTimeString();
var elapsed = dateTime.Elapsed();
var isFuture = dateTime.IsFuture();
var weekend = dateTime.IsWeekendDay();
```

### License
Licensed under the [MIT License](https://raw.githubusercontent.com/DaveSenn/Extend/dev/License.txt).
