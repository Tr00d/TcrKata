namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        if (command.Equals("down 1"))
        {
            this.Aim += 1;
            return;
        }
        
        throw new NotImplementedException();
    }

    public int Aim { get; private set; } = 0;

    public int Position { get; } = 0;
    public int Depth { get; } = 0;
}