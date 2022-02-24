namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    private int aim = 0;
    public void ExecuteCommand(string command)
    {
        throw new NotImplementedException();
    }

    public int Aim => this.aim;
    public int Position => 0;
    public int Depth => 0;
}