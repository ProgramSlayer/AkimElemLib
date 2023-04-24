namespace AkimElemLib.Wpf.Models.Common;

public readonly record struct Probability(double Value)
{
    public static implicit operator Probability(double Value) => new(Value);
    public static implicit operator double(Probability probability) => probability.Value;
}