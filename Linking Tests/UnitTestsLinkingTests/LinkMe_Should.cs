using FluentAssertions;

namespace UnitTestsLinkingTests;

public class LinkMe_Should
{
    /// <summary>
    /// Checks if LinkingTests has been linked properly.
    /// </summary>
    [Fact]
    public void Test_IsLinked()
    {
        // Given
        //* Credits to moribvndvs on https://stackoverflow.com/a/8499606 for this solution!
        string asmName = @"LinkingTests.LinkMe, LinkingTests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

        // When
        //? Reflects the type. (Reflection describes Types that can describe assemblies)
        //? Will only return the Type if the current assembly has a reference to the LinkingTests project
        Type? classType = Type.GetType(asmName);


        // Then
        //? Checks if the Type is not null (i.e. cannot be created, due to the lack of Project Reference)
        classType.Should().NotBeNull("a project reference to LinkingTests is expected");
    }
}