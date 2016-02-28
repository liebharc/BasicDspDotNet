// ReSharper disable UnusedMember.Global
namespace BasicDsp
{
    public enum PaddingOption
    {
        End,
        Surround,
        Center
    }

    public enum StandardWindowFunction
    {
        HammingWindow,
        TriangularWindow
    }

    public enum StandardImpulseResponse
    { 
        SincFunction,
        RaisedCosineFunction
    }

    public enum StandardFrequencyResponse
    {
        SincFunction,
        RaisedCosineFunction
    }

    public enum VectorDomain
    {
        Time,
        Frequency
    }
}