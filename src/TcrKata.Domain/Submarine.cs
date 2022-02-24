namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        string[] parameters = command.Split(' ');
        string commandName = parameters[0];
        int value = int.Parse(parameters[1]);
        if (commandName == "up" && value == 1)
        {
            this.Aim -= 1;
            return;
        }
        
        if (commandName == "up" && value == 2)
        {
            this.Aim -= 2;
            return;
        }
        
        if (command.Equals("down 1"))
        {
            this.Aim += 1;
            return;
        }
        
        if (command.Equals("down 2"))
        {
            this.Aim += 2;
            return;
        }
        
        throw new NotImplementedException();
    }

    public int Aim { get; private set; } = 0;

    public int Position { get; } = 0;
    public int Depth { get; } = 0;
}