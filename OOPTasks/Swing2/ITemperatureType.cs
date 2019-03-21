using System;

namespace Swing2
{
    interface ITemperatureType
    {
        string Name { get; }
        string Symbol { get; }
        Func<double, double> ToCelsius { get; }
        Func<double, double> FromCelsius { get; }
    }
}
