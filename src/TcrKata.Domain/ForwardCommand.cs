namespace TcrKata.Domain;

public class ForwardCommand : ISubmarineCommand
{
    public ForwardCommand(int commandValue)
    {
        this.Value = commandValue;
    }

    public SubmarineState TransformState(SubmarineState state) =>
        state with
        {
            Position = state.Position + this.Value,
            Depth = state.Depth + (state.Aim * this.Value)
        };

    public int Value { get; }
}