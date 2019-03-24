using System;

namespace Swing2.TemperatureTypes
{
    class Fahrenheit : ITemperatureType
    {
        public string Name => "Фаренгейт";

        public string Symbol => "°F";

        public double FromCelsius(double celsiusTemperature)
        {
            return celsiusTemperature * 1.8 + 32;
        }

        public double ToCelsius(double temperature)
        {
            return (temperature - 32) / 1.8;
        }
    }
}
