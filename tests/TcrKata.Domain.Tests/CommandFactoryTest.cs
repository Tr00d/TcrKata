using System;
using FluentAssertions;
using FluentAssertions.LanguageExt;
using LanguageExt;
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
    public void Parse_ShouldThrowException_GivenInputContainsNoValue() => this.factory.Parse("forward")
        .Should()
        .BeRight("Input contains no value.");

    [Fact]
    public void Parse_ShouldThrowException_GivenMethodNameIsNotRecognized() => this.factory.Parse("lolilol 4")
        .Should()
        .BeRight("Method name is not recognized.");
}