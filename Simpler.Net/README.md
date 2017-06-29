# Simpler.Net


Miscellaneous, mostly atomic utilities, methods, workarounds and wrappers.

## Extension methods

### Dictionary<>.Get()
A concise and readable way to retrieve a dictionary entry if it exists, or a default value if it doesn't.

```cs
var foo = new Dictionary<String, Int>();
Console.WriteLine(foo.Get("none"));
Console.WriteLine(foo.Get("none", fallback:12));
// Output:
// 		0
// 		12
```