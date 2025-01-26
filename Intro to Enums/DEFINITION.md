# Enumerables

## What are enumerables?

An enumerable (also known as an enum) is a specific type of class that is a collection of strings that represent an integer value.

Enums make it easier to understand what specific values mean, as they can be used in place of constants or magic numbers.

## How do Enums work

1. Values will always start at 0, like an array.
2. Values will increment by 1 by default
3. Each value in the enum is separated by a comma
4. Integer values can be overridden with your own values
5. You can check if an enum exists with the `Enum.IsDefined(typeof(<Type>), <value>)` method

## Creating an enum

Enums can be created with the `enum` keyword, in place of the `class` keyword

```cs
private enum MyEnum {
    value, // Auto assigns a value of 0, because the previous value = -1
    value2 = 23, // Force assigns a value of 23
    value3, // Auto assigns a value of 24, because the previous value = 23
    ...
    valueN // Auto assigns a value of N, because the previous value = (N - 1)
}
```

While you *can* define enums in any order, it is best practice to organize them based on value

```cs
// This works, but is bad practice
private enum UnorganizedEnum {
    magicalNumber = 23,
    age = 72,
    divisibleBy = 12
}

// This is easier to keep track of, and is better practice
private enum OrganizedEnum {
    divisibleBy = 12,
    magicalNumber = 23,
    age = 72
}
```

Enums can also have multiple values of the same amount

```cs
// This is VERY bad practice, and is why you should keep your values in order
private enum DoubleValues {
    a = 5,
    b, // b is auto-assigned the value of 6
    c = 6 // c is forcibly assigned the value of 6
}
```

## Flag Enums

Adding the `[Flags]` Attribute makes the enum act as a bit field. This is useful to allow multiple values to be set in between two values.

```cs
[Flags]
public enum FlagEnum {
    None = 0,   // 0b_0000
    Red = 1,    // 0b_0001
    Orange = 2, // 0b_0010
    Yellow = 4, // 0b_0100
    Green = 8   // 0b_1000
}
```

The values are in multiples of 2<sup>n</sup> because the values are now in base 2

Values in between the defined flags will enumerate to multiple flags. If a value of `5` was set, it would set `Yellow` (4), then `Red` (1). because 5 = `0b_0101`, and includes both 4 `0b_0100` and 1 `0b_0001`.

This can be expressed as `0100 | 0001` which evaluates to `0101`. This is the [bitwise OR operation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-or-operator-)

>The Bitwise OR operator looks at each pair of corresponding bits (on/off) from two values. If any of them is on, it sets that position to on in the result. This is useful when you want to combine multiple flags or conditions, where each flag corresponds to a specific "bit" or switch.

Flags allow us to use more complex logic in our Enums, such as having a Read, Write, and Read and Write value, while only having to define one value:

```cs
public enum Permissions {
    None = 0,
    Read = 1,
    Write = 2
}

Permissions readAndWrite = Permissions.Read | Permissions.Write;

Console.WriteLine(readAndWrite.ToString());
// Expected outcome: Read, Write
```

These in-betweens can also be explicitly defined in our enums

```cs
public enum Permissions {
    None = 0,
    Read = 1,
    Write = 2,
    ReadWrite = Read | Write
}

Console.WriteLine(Permissions.ReadWrite.ToString());
// Expected outcome: Read, Write
```

We can use the [Bitwise AND operation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#logical-and-operator) to test for flags in our values.

```cs
Permissions p = Permissions.Read | Permissions.Write;

bool canWrite = (p & Permissions.Write) == Permissions.Write;
Console.WriteLine(canWrite); // Output: True
```

In `.NET 4` or higher, you can also use the `Enum.HasFlag()` method:

```cs
Permissions p = Permissions.Read | Permissions.Write;
bool canRead = p.HasFlag(Permissions.Read);
Console.WriteLine(canRead); // Output: True
```

Flags can be toggled with the [Bitwise NOT operation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/bitwise-and-shift-operators#bitwise-complement-operator)

```cs
Permissions p = Permissions.Read | Permissions.Write;
Console.WriteLine(p.HasFlag(Permissions.Read)); // Output : True

p = p & ~Permissions.Read; // Permissions equal Permissions AND NOT Read
Console.WriteLine(p.HasFlag(Permissions.Read)); // Output: False
