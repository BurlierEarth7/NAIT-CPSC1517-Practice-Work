using FluentAssertions;
using Properties;

namespace TestsForProperties;

public class PropertiesReview_Should
{
    /// <summary>
    /// Checks if the FirstName property can be written to
    /// </summary>
    [Fact]
    public void FirstName_Should_Be_Writable() => typeof(PropertiesReview).GetProperty(nameof(PropertiesReview.FirstName)).Should().BeWritable();

    /// <summary>
    /// Checks if the FirstName property has a default value of "Rebecca"
    /// </summary>
    [Fact]
    public void FirstName_Should_Default_Rebecca()
    {
        // Given
        //Target-typed new (Just using new() instead of new class() is only available in .net 9 and we're still technically in 8 for this course)
        PropertiesReview sut = new PropertiesReview();
        // When
        string expectedDefault = "Rebecca";
        // Then
        sut.FirstName.Should().Be(expectedDefault);
    }

    /// <summary>
    /// Checks if the LastName property can be written to
    /// </summary>
    [Fact]
    public void LastName_Should_Be_Writable() => typeof(PropertiesReview).GetProperty(nameof(PropertiesReview.LastName)).Should().BeWritable();

    /// <summary>
    /// Checks that values of the LastName property can never be null or whitespace
    /// </summary>
    /// <param name="value">Provided test values as a string</param>
    [Theory]
    [InlineData("")]
    [InlineData("                      ")]
    [InlineData(null)]
    public void LastName_Should_Not_Be_NullOrWhitespace(string? value)
    {
        // Given
        PropertiesReview sut = new PropertiesReview();
        // When
        Action action = () => sut.LastName = value;
        // Then
        action.Should().Throw<ArgumentNullException>();

    }
}
