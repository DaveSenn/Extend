# Welcome to PortableExtensions

### What is this?

PortableExtensions is a set of .Net extension methods build as portable class library. 
PortableExtensions enhance the .Net framework by adding a bunch of methods to increase developer’s productivity.
Currently it contains 335 unique extension methods (577 overloads included).
### Where can I use it?
You can use it in every .Net application or library targeting one of the following profiles:
* .Net 4.5
* Windows 8
* Windows Phone 8
* Windows Phone 8.1

### How do I use it?
1. Install ["PortableExtensions"](http://www.nuget.org/packages/PortableExtensions/) via [NuGet](http://nuget.org)
__Install-Package PortableExtensions__
2. Add using for PortableExtensions ```using PortableExtensions; ```
3. Done!

### Testing
To guarantee its stability PortableExtensions contains over 1500 unit tests.
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
Licensed under the [MIT License](https://raw.githubusercontent.com/DaveSenn/PortableExtensions/master/License.txt).

### Codebetter CI
<a href="http://www.jetbrains.com/teamcity">
    <img src="http://www.jetbrains.com/img/banners/Codebetter.png">
</a>
