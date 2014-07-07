# Welcome to PortableExtensions

### What is this?

PortableExtensions is a set of .Net extension methods build as portable class library. 
PortableExtensions enhance the .Net framework by adding a bunch of methods to increase developer’s productivity.
Currently it contains 309 unique extension methods (490 overloads included).

### Where can I use it?
You can use it in every .Net Application or Library targeting one of the following profiles:
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
To guarantee its stability PortableExtensions contains nearly 1000 unit tests.
Each method has test with different input parameters, including invalid values to test the exception handling.

### Example

Array to list using a selector:
```csharp
var myArray = new[] {"1", "2", "3"};
var intValues = myArray.ToList(x => x.ToInt32());
```

### License
Licensed under the [MIT License](https://raw.githubusercontent.com/DaveSenn/PortableExtensions/master/License.txt).
