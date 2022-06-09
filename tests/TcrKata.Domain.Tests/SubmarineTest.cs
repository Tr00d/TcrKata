
using System.Threading;
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
    public void ExecuteCommand_ShouldAimTo1_GIvenCommandIsUp()
    {
        this.submarine.ExecuteCommand("up");
        this.submarine.Aim.Should().Be(1);
    }
}