using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Submarine submarine;
    
    public SubmarineTest()
    {
        this.submarine = new Submarine();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExecuteCommand_ShouldIncreaseAimByValue_GivenCommandIsDownWithAValue(int value)
    {
        // Act
        this.submarine.ExecuteCommand($"down {value}");

        // Assert
        this.submarine.Aim.Should().Be(value);
    }
}