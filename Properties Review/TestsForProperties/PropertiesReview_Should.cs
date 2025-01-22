using FluentAssertions;
using Properties;

namespace TestsForProperties;

public class PropertiesReview_Should
{
    [Fact]
    public void FirstName_Should_Be_ReadWrite_Default_Rebecca()
    {
        // Given
        PropertiesReview sut = new();
        // When
        string expectedDefault = "Rebecca";
        // Then
        sut.FirstName.Should().Be(expectedDefault);
        sut.FirstName = "";
        sut.FirstName.Should().Be("");
    }

    [Theory]
    [InlineData("   27424    ")]
    [InlineData("dsfhsdkj")]
    public void LastName_Should_Be_ReadWrite(string value)
    {
        // Given
        PropertiesReview sut = new();
        // When
        // Then
        sut.LastName = value;
        sut.LastName.Should().Be(value.Trim());
    }


    [Theory]
    [InlineData("")]
    [InlineData("                      ")]
    [InlineData(null)]
    public void LastName_Should_Not_Be_NullOrWhitespace(string? value)
    {
        // Given
        PropertiesReview sut = new();
        // When
        Action action = () => sut.LastName = value;
        // Then
        action.Should().Throw<ArgumentNullException>();

    }
}
