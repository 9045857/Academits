using System;

namespace Swing2.TemperatureTypes
{
    class Celsius : ITemperatureType
    {
        public string Name => "Цельсий";

        public string Symbol => "°C";

        public Func<double, double> ToCelsius => (k) => k;

        public Func<double, double> FromCelsius => (c) => c;
    }
}
