# Properties

## About

See [Microsoft's documentation on properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties) for more in depth explanations.

### Definition

Property
: a member that provides a flexible mechanism to read, write, or compute the value of a data field.

Properties appear as public data members, but they're implemented as special methods called accessors. This feature allows us to access data easily while still keeping data safety and flexibility.

### Properties


## Examples

### Auto Implementation

```cs
    /// <summary>
    /// An example of an auto-implemented property
    /// </summary>
    /// <value>Any integer value.</value>
    public int Id { get; set; }
    // No Attribute is linked with this property
    // our compiler will automatically create a private, anonymous field for us
    // This is because our property is auto-implemented
```

### Manual Implementation

```cs
    private string _Name = "No Name";
    /// <summary>
    /// An example of manually implemented property with data verification
    /// </summary>
    /// <value>A non-null and non-whitespace string</value>
    public string Name
    {
        get
        {
            return _Name;
        }
        set
        {
            // Only allows valid names
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name can not be null or whitespace.");
            _Name = value.Trim();
        }
    }
```

### Expression-bodied accessors
```cs
    private bool _IsValid;
    /// <summary>
    /// A manually implemented property with expression-bodied accessors
    /// </summary>
    /// <value>True or False</value>
    public bool IsValid
    {
        // Expression bodied members use => to assign or return the result of an expression

        // An experssion bodied member returning a value
        // Equivalent to { return _IsValid; }
        get => _IsValid;
        // An expression bodied member assigning a value
        set => _IsValid = value;
    }
```
