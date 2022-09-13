using LanguageExt;
using LanguageExt.Common;
using static LanguageExt.Prelude;
namespace TcrKata.Domain;

public class CommandFactory
{
    public Either<ISubmarineCommand, string> Parse(string input)
    {
        var commandParts = input.Split(' ');
        if (commandParts.Length < 2)
        {
            return Either<ISubmarineCommand, string>.Right("Input contains no value.");
        }

        var commandType = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        return commandType switch
        {
            "down" => Either<ISubmarineCommand, string>.Left(new DownCommand(commandValue)),
            "up" => Either<ISubmarineCommand, string>.Left(new UpCommand(commandValue)),
            "forward" => Either<ISubmarineCommand, string>.Left(new ForwardCommand(commandValue)),
            _ => Either<ISubmarineCommand, string>.Right("Method name is not recognized."),
        };
    }
}