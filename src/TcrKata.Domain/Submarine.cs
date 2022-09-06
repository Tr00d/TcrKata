namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        var commandParts = command.Split(' ');
        if (commandParts[0].Equals("down"))
        {
            Aim += int.Parse(commandParts[1]);
        }
        else
        {
            Aim -= int.Parse(commandParts[1]);    
        }
    }

    public int Aim { get; private set; }
    public int Position => throw new NotImplementedException();
    public int Depth => throw new NotImplementedException();
}