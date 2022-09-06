namespace TcrKata.Domain;

public class CommandFactory
{
    public ISubmarineCommand Parse(string input)
    {
        var commandParts = input.Split(' ');
        if (commandParts.Length < 2)
        {
            throw new Exception();
        }
        
        var commandType = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        return commandType switch
        {
            "down" => new DownCommand(commandValue),
            "up" => new UpCommand(commandValue),
            "forward" => new ForwardCommand(commandValue),
            _ => throw new Exception()
        };
    }
}