using System.Runtime.CompilerServices;

namespace TcrKata.Domain;

public class Submarine : ISubmarine
{
    private SubmarineState state;
    private readonly CommandFactory factory;

    public Submarine()
    {
        this.state = new SubmarineState(default, default, default);
        this.factory = new CommandFactory();
    }
    
    public void ExecuteCommand(string command) => this.state = this.factory
        .Parse(command)
        .TransformState(this.state);

    public int Aim => this.state.Aim;
    public int Position => this.state.Position;
    public int Depth => this.state.Depth;
}