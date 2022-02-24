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
    [InlineData(1)]
    public void ExecuteCommand_ShouldIncreaseAimByOne_GivenCommandIsDownOne(int aim)
    {
        int initialValue = this.submarine.Aim;
        this.submarine.ExecuteCommand($"down {aim}");
        this.submarine.Aim.Should().Be(initialValue + aim);
    }
}