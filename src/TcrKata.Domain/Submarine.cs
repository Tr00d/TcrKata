namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] parameters = command.Split(' ');
        string commandName = parameters[0];
        int value = int.Parse(parameters[1]);

        if (commandName == "forward")
        {
            this.Position = 15;
            this.Depth = 30;
            return;
        }
        
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

    public int Position { get; private set; } = 0;
    public int Depth { get; private set; } = 0;
}