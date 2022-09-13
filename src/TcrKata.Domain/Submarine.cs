using System.Runtime.CompilerServices;

namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    private readonly SubmarineState state;
    private readonly CommandFactory factory;

    public Submarine()
    {
        this.state = new SubmarineState(default, default, default);
        this.factory = new CommandFactory();
    }

    private Submarine(SubmarineState submarineState)
    :this()
    {
        this.state = submarineState;
    }

    public ISubmarine ExecuteCommand(string command) =>
        this.factory
            .Parse(command)
            .Match(_ => this, this.MoveSubmarine);

    private Submarine MoveSubmarine(ISubmarineCommand success) => new(success.TransformState(this.state));

    public int Aim => this.state.Aim;
    public int Position => this.state.Position;
    public int Depth => this.state.Depth;
}