using System.Linq;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class SubmarineTest
{
    private readonly Fixture _fixture;
    private readonly Submarine _submarine;

    public SubmarineTest()
    {
        this._submarine = new Submarine();
        this._fixture = new Fixture();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExecuteCommand_ShouldIncreaseAimByValue_GivenCommandIsDownWithAValue(int value) =>
        this._submarine
            .ExecuteCommand($"down {value}")
            .Aim
            .Should()
            .Be(value);

    [Fact]
    public void ExecuteCommand_ShouldIncreaseAimByValue_GivenNotZeroDefaultAim()
    {
        var commandValues = this._fixture.CreateMany<int>().ToList();
        commandValues.Aggregate((ISubmarine)new Submarine(),
            (runningValue, value) => runningValue = runningValue.ExecuteCommand($"down {value}"))
            .ExecuteCommand("down 1")
            .Aim
            .Should()
            .Be(commandValues.Sum() + 1);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void ExecuteCommand_ShouldDecreaseAimByValue_GivenCommandIsUpWithAValue(int value) =>
        this._submarine.ExecuteCommand($"up {value}").Aim.Should().Be(-value);

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void ExecuteCommand_ShouldIncreasePosition_GivenForwardCommand(int value)
    {
        this._submarine.ExecuteCommand($"forward {value}").Position.Should().Be(value);
    }

    [Fact]
    public void ExecuteCommand_ShouldIncreasePositionByValue_GivenNotZeroDefaultPosition()
    {
        var commandValues = this._fixture.CreateMany<int>().ToList();
        commandValues.Aggregate((ISubmarine)new Submarine(),
            (runningValue, value) => runningValue = runningValue.ExecuteCommand($"forward {value}"))
            .ExecuteCommand("forward 1")
            .Position
            .Should()
            .Be(commandValues.Sum() + 1);
    }

    [Fact]
    public void ExecuteCommand_ShouldChangeDepth_GivenForwardCommand() => this._submarine.ExecuteCommand("forward 1").Depth.Should().Be(0);

    [Fact]
    public void ExecuteCommand_ShouldChangeDepth_GivenForwardCommandAndNotZeroAim()
    {
        var downValue = _fixture.Create<int>();
        var forwardValue = _fixture.Create<int>();
        this._submarine.ExecuteCommand($"down {downValue}")
            .ExecuteCommand($"forward {forwardValue}").Depth.Should().Be(forwardValue * downValue);
    }

    [Fact]
    public void ExecuteCommand_ShouldIncreaseDepth_GivenDepthHasValue() =>
        this._submarine
            .ExecuteCommand("down 1")
            .ExecuteCommand("forward 1")
            .ExecuteCommand("forward 1")
            .Depth
            .Should()
            .Be(2);
    
    [Fact]
    public void ExecuteCommand_ShouldNotChangeState_GivenCommandIsBullshit() =>
        this._submarine
            .ExecuteCommand("down 1")
            .ExecuteCommand("forward 1")
            .ExecuteCommand("bullshit 1")
            .Depth
            .Should()
            .Be(1);
}