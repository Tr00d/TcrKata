namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        var commandParts = command.Split(' ');
        Aim += int.Parse(commandParts[1]);
    }

    public int Aim { get; set; }
    public int Position => throw new NotImplementedException();
    public int Depth => throw new NotImplementedException();
}