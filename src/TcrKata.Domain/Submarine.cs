namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        throw new NotImplementedException();
    }

    public int Aim { get; } = 0;

    public int Position => 0;
    public int Depth => 0;
}