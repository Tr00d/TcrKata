namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        throw new NotImplementedException();
    }

    public int Aim { get; } = 0;

    public int Position { get; } = 0;
    public int Depth { get; } = 0;
}