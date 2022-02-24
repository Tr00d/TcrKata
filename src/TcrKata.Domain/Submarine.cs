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
            case "forward":
                this.Position += value;
                this.Depth = 30;
                break;
        }
    }

    public int Aim { get; private set; } = 0;

    public int Position { get; private set; } = 0;
    public int Depth { get; private set; } = 0;
}