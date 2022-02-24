namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] parameters = command.Split(' ');
        string commandName = parameters[0];
        int value = int.Parse(parameters[1]);
        switch (commandName)
        {
            case "up":
                this.Aim -= value;
                break;
            case "down":
                this.Aim += value;
                break;
        }
    }

    public int Aim { get; private set; } = 0;

    public int Position { get; } = 0;
    public int Depth { get; } = 0;
}