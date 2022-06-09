namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        if (command == "up")
        {
            this.Aim = 1;
            return;
        }
        
        throw new NotImplementedException();
    }

    public int Aim { get; private set; }
    public int Position => throw new NotImplementedException();
    public int Depth => throw new NotImplementedException();
}