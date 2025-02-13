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

    [Fact]
    public void FileOperations_Has_Correct_Values()
    {
        // Given
    
        // When
    
        // Then
        FileOperations.None.Should().HaveValue(0);
        FileOperations.ReadOnly.Should().HaveValue(1);
        FileOperations.Hidden.Should().HaveValue(2);
        FileOperations.Compressed.Should().HaveValue(4);
        FileOperations.Encrypted.Should().HaveValue(8);
    }
}
