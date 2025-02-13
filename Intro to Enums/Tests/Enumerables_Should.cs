using Enumerables;
using FluentAssertions;

namespace Tests;

public class Enumerables_Should
{
    [Fact]
    public void Seasons_Exists()
    {
        // Given
        // When
        // Then
        Enum.GetValues(typeof(Seasons)).Length.Should().Be(4);
        Seasons.Spring.Should().BeDefined();
        Seasons.Summer.Should().BeDefined();
        Seasons.Autumn.Should().BeDefined();
        Seasons.Winter.Should().BeDefined();
    }

    [Fact]
    public void Spring_Equals_0() => Seasons.Spring.Should().HaveValue(0);

    [Fact]
    public void Summer_Equals_1() => Seasons.Summer.Should().HaveValue(1);

    [Fact]
    public void Autumn_Equals_2() => Seasons.Autumn.Should().HaveValue(2);

    [Fact]
    public void Winter_Equals_55() => Seasons.Winter.Should().HaveValue(55);
}