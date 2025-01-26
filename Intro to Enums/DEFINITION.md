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
