using System;

namespace Swing2.TemperatureTypes
{
    class Kelvin : ITemperatureType
    {
        public string Name => "Кельвин";

        public string Symbol => "К";

        public double FromCelsius(double celsiusTemperature)
        {
            return celsiusTemperature + 273.15;
        }

        public double ToCelsius(double temperature)
        {
            return temperature - 273.15;
        }
    }
}
