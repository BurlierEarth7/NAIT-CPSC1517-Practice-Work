# Properties

## About

See [Microsoft's documentation on properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties) for more in depth explanations.

### Definitions

> [Property](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)
: a member that provides a flexible mechanism to read, write, or compute the value of a data field. Properties appear as public data members, but they're implemented as special methods called accessors. This feature allows us to access data easily while still keeping data safety and flexibility.

---

[get](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties#the-get-accessor)
: returns the specified value. This is called whenever `Object.Property` is read (e.g. `Console.WriteLine(MyObject.Property);`). Removing `get` from your property will make it **write only**

```cs
public Type PropertyName
{
    get
    {
        return _MyAttribute;
    }
}
```

---

[set](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties#the-set-accessor)
: modifies the specified attribute with a given value. This is called whenever `Object.Property` is set (e.g. `MyObject.Property = 15;`). Removing `set` from your property will make it **read only**

```cs
public Type PropertyName
{
    set
    {
        _MyAttribute = value;
    }
}
```

---

[private](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers) set
: acts like set, except it can only be used within the internal code of your class. This effectively makes your property **read only** while still giving you **auto implementation** functionality. ***All properties can have accessor modifiers on them***

```cs
public Type PropertyName
{
    private set
    {
        _MyAttribute = value;
    }
}
```

---

[init](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties#the-init-accessor)
: acts the same as `set`, except it can only be used from within a constructor. This means your value **cannot change past construction**. This is ideal for **read only** properties that need a value at creation

```cs
public Type PropertyName
{
    init
    {
        _MyAttribute = value;
    }
}
```

---

[auto-implementation](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties)
: Auto implemented properties have the compiler create the private attribute automatically. However, with this approach, **you cannot have data verification on the value**.

```cs
public Type PropertyName { get; set; }
```

---

manual-implementation
: Manually implemented properties take more time to write, but **allow for data verification on the value**
```cs
public Type PropertyName
{
    get
    {
        return _MyAttribute;
    }
    set
    {
        _MyAttribute = value;
    }
}
```

---

[expression-bodies](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#properties)
: expression bodies allow you to simplify your `get` and `set` (or `init`) if they are a single line. By using `=>` instead of braces `{}`, the compiler will automatically interpret the `return` on a `get`, and will assign the `value` to your attribute.

```cs
    get => _MyAttribute;
```
Instead of:
```cs
    get 
    {
        return _MyAttribute;
    }
```

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

        // An expression bodied member returning a value
        // Equivalent to { return _IsValid; }
        get => _IsValid;
        // An expression bodied member assigning a value
        set => _IsValid = value;
    }
```
