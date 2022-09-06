using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Submarine submarine;
    private readonly Fixture fixture;
    
    public SubmarineTest()
    {
        this.submarine = new Submarine();
        this.fixture = new Fixture();
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

    [Fact]
    public void ExecuteCommand_ShouldIncreaseAimByValues_GivenMultipleDownCommands()
    {
        var commandValues = this.fixture.CreateMany<int>();
        foreach (int value in commandValues)
        {
            this.submarine.ExecuteCommand($"down {value}");
        }

        this.submarine.Aim.Should().Be(commandValues.Sum());
    }
}