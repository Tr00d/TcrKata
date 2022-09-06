using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Submarine _submarine;
    private readonly Fixture _fixture;
    
    public SubmarineTest()
    {
        this._submarine = new Submarine();
        this._fixture = new Fixture();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExecuteCommand_ShouldIncreaseAimByValue_GivenCommandIsDownWithAValue(int value)
    {
        // Act
        this._submarine.ExecuteCommand($"down {value}");
        
        // Assert
        this._submarine.Aim.Should().Be(value);
    }

    [Fact]
    public void ExecuteCommand_ShouldIncreaseAimByValue_GivenNotZeroDefaultAim()
    {
        // Arrange
        var commandValues = this._fixture.CreateMany<int>().ToList();
        commandValues.ForEach(value => this._submarine.ExecuteCommand($"down {value}"));

        // Act
        this._submarine.ExecuteCommand($"down 1");

        // Assert
        this._submarine.Aim.Should().Be(commandValues.Sum() + 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExecuteCommand_ShouldDecreaseAimByValue_GivenCommandIsUpWithAValue(int value)
    {
        // Act
        this._submarine.ExecuteCommand($"up {value}");
        
        // Assert
        this._submarine.Aim.Should().Be(-value);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void ExecuteCommand_ShouldIncreasePosition_GivenForwardCommand(int value)
    {
        this._submarine.ExecuteCommand($"forward {value}");

        this._submarine.Position.Should().Be(value);
    }

    [Fact]
    public void ExecuteCommand_ShouldIncreasePositionByValue_GivenNotZeroDefaultPosition()
    {
        // Arrange
        var commandValues = this._fixture.CreateMany<int>().ToList();
        commandValues.ForEach(value => this._submarine.ExecuteCommand($"forward {value}"));

        // Act
        this._submarine.ExecuteCommand($"forward 1");

        // Assert
        this._submarine.Position.Should().Be(commandValues.Sum() + 1);
    }

    //[Fact]
    //public void ExecuteCommand_ShouldIncreasePositionAndDepth_GivenForwardCommand()
    //{

    //}
}