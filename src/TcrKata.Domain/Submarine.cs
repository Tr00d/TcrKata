namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        var commandParts = command.Split(' ');
        var commandType = commandParts[0];
        var commandValue = int.Parse(commandParts[1]);
        if (IsDownCommand(commandType))
        {
            Aim += commandValue;
        }
        else if (IsForwardCommand(commandType))
        {
            Position += commandValue;
        }
        else
        {
            Aim -= commandValue;    
        }
    }

    private static bool IsForwardCommand(string commandType)
    {
        return commandType.Equals("forward");
    }

    private static bool IsDownCommand(string commandType)
    {
        return commandType.Equals("down");
    }

    public int Aim { get; private set; }
    public int Position { get; private set; }
    public int Depth => throw new NotImplementedException();
}