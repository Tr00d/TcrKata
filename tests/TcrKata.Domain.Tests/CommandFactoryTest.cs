using System;
using FluentAssertions;
using Xunit;

namespace TcrKata.Domain.Tests;

public class CommandFactoryTest
{
    private readonly CommandFactory factory;

    public CommandFactoryTest()
    {
        factory = new CommandFactory();
    }
    
    [Fact]
    public void Parse_ShouldThrowException_GivenInputContainsNoValue() 
        => Assert.Throws<Exception>(() => factory.Parse("forward"));
    
    [Fact]
    public void Parse_ShouldThrowException_GivenMethodNameIsNotRecognized() 
        => Assert.Throws<Exception>(() => factory.Parse("lolilol"));
}