using System;

namespace Swing2
{
    interface ITemperatureType
    {
        string Name { get; }
        string Symbol { get; }
        double ToCelsius(double temperature);
        double FromCelsius(double celsiusTemperature);
    }
}
