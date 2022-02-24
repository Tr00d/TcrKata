using System;
using System.Runtime.InteropServices;
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

    [Fact]
    public void SomeFakeTest()
    {
        this.submarine.Should().NotBeNull();
    }

    [Fact]
    public void Aim_ShouldReturnZero_GivenSubmarineIsInitialPosition()
    {
        this.submarine.Aim.Should().Be(0);
    }
    
    
    [Fact]
    public void Position_ShouldReturnZero_GivenSubmarineIsInitialPosition()
    {
        this.submarine.Position.Should().Be(0);
    }
    
    [Fact]
    public void Depth_ShouldReturnZero_GivenSubmarineIsInitialPosition()
    {
        this.submarine.Depth.Should().Be(0);
    }

    [Theory]
    [InlineData("down", 1)]
    [InlineData("down", 2)]
    public void ExecuteCommand_ShouldIncreaseAim_GivenCommandIsDown(string command, int aim)
    {
        int initialValue = this.submarine.Aim;
        this.submarine.ExecuteCommand($"{command} {aim}");
        this.submarine.Aim.Should().Be(initialValue + aim);
    }
    
    [Theory]
    [InlineData("up", 1)]
    [InlineData("up", 2)]
    public void ExecuteCommand_ShouldDecreaseAim_GivenCommandIsUp(string command, int aim)
    {
        int initialValue = this.submarine.Aim;
        this.submarine.ExecuteCommand($"{command} {aim}");
        this.submarine.Aim.Should().Be(initialValue - aim);
    }

    [Fact]
    public void ExecuteCommand_ShouldIncreasePositionAndDepth_GivenCommandIsForward()
    {
        // Arrange
        this.submarine.ExecuteCommand($"down 2");

        // Act
        this.submarine.ExecuteCommand($"forward 15");
        
        // Assert
        this.submarine.Position.Should().Be(15);
        this.submarine.Depth.Should().Be(30);
    }
}