# Simpler.Net.Main

General-purpose extensions and utilities.

## Scope functions

### `*.Also`
Perform an action on the context object, and return the object.
```csharp
return "Original".Also(it => {
  Console.WriteLine($"Returning {it}...");
}); // "Original"
```

### `*.Let`
Invoke a function with the context object as the argument, and return the result.
```csharp
return "Original".Let(it => {
  it.Replace("Original", "Replaced")
); // "Replaced"
```

## Nullable extensions

### `*.ToStringOr`
Return a value's String representation, or a fallback if the value is `null`.
A fluent alternative to `value?.ToString() ?? fallback;`
```csharp
null.ToStringOr("Nothing");   // "Nothing"
123.ToStringOr("Nothing");    // "123"
```

### `*.ToStringOrEmpty`
Return a value's String representation, or an empty string if the value is `null`.
A fluent alternative to `value?.ToString() ?? String.Empty;`.
```csharp
null.ToStringOrEmpty();   // ""
321.ToStringOrEmpty();    // "321"
```
