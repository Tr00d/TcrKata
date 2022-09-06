namespace TcrKata.Domain;

public interface ISubmarineCommand
{
    SubmarineState TransformState(SubmarineState state);
    
    int Value { get; }
}