namespace TcrKata.Domain;

public interface ISubmarine
{
    int Aim { get; }

    int Position { get; }

    int Depth { get; }
    ISubmarine ExecuteCommand(string command);
}