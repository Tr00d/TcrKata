namespace TcrKata.Domain;

public class UpCommand : ISubmarineCommand
{
    public UpCommand(int commandValue)
    {
        this.Value = commandValue;
    }

    public SubmarineState TransformState(SubmarineState state) => state with { Aim = state.Aim - this.Value };

    public int Value { get; }
}