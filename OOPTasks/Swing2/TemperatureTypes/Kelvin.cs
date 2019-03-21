using System;

namespace Swing2.TemperatureTypes
{
    class Kelvin : ITemperatureType
    {
        public string Name => "Кельвин";

        public string Symbol => "К";

        public Func<double, double> ToCelsius => (k) => k + 273.15;

        public Func<double, double> FromCelsius => (c) => c - 273.15;
    }
}
