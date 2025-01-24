using FluentAssertions;

namespace UnitTestsLinkingTests;

public class LinkMe_Should
{
    /// <summary>
    /// Checks if an Assembly Reference to LinkingTests has been created.
    /// </summary>
    [Fact]
    public void Assembly_Reference_Exists()
    {
        // Given
        string @asmName = @"LinkingTests.LinkMe, LinkingTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        // When
        Type? classType = Type.GetType(@asmName);
        // Then
        classType.Should().NotBeNull();
    }
}