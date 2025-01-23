using FluentAssertions;
using Properties;

namespace TestsForProperties;

public class PropertiesReview_Should
{
    [Fact]
    public void FirstName_Should_Be_ReadWrite_Default_Rebecca()
    {
        // Given
        //Target-typed new (Just using new() instead of new class() is only available in .net 9 and we're still technically in 8 for this course)
        PropertiesReview sut = new PropertiesReview();
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
        PropertiesReview sut = new PropertiesReview();
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
        PropertiesReview sut = new PropertiesReview();
        // When
        Action action = () => sut.LastName = value;
        // Then
        action.Should().Throw<ArgumentNullException>();

    }
}
