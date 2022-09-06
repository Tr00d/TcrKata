namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    public void ExecuteCommand(string command)
    {
        if (command.Equals("down 1"))
        {
            Aim = 1;
        }
        else if (command.Equals("down 2"))
        {
            Aim = 2;
        }
    }

    public int Aim { get; set; }
    public int Position => throw new NotImplementedException();
    public int Depth => throw new NotImplementedException();
}