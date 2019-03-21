using System;

namespace Swing2.TemperatureTypes
{
    class Fahrenheit : ITemperatureType
    {
        public string Name => "Фаренгейт";

        public string Symbol => "°F";

        public Func<double, double> ToCelsius => (k) => (k - 32) / 1.8;

        public Func<double, double> FromCelsius => (c) => c * 1.8 + 32;
    }
}
