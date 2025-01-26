using FluentAssertions;
using Enumerables;
using System.Reflection;
namespace Tests;

public class FlagEnums_Should
{
    [Fact]
    public void FileOperations_Is_FlagAttribute()
    {
        // Given

        // When

        // Then
        // Checks if the [Flags] attribute is set on the enum
        typeof(FileOperations).GetCustomAttributes<FlagsAttribute>().Any().Should().BeTrue();
    }
}
