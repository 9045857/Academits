using System;

namespace Swing2.TemperatureTypes
{
    class Celsius : ITemperatureType
    {
        public string Name => "Цельсий";

        public string Symbol => "°C";

        public double FromCelsius(double celsiusTemperature)
        {
            return celsiusTemperature;
        }

        public double ToCelsius(double temperature)
        {
            return temperature;
        }
    }
}
