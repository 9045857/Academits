using System;

namespace Swing
{
    class Degrees
    {
        private double celsiusValue;

        public string celsiusType = "°C";
        public string fahrenheitType = "°F";
        public string kelvinType = "K";

        public double Celsius
        {
            get
            {
                return celsiusValue;
            }
            set
            {
                celsiusValue = value;
            }
        }

        public double Fahrenheit
        {
            get
            {
                return ConvertCelsiusToFahrenheit(celsiusValue);
            }
            set
            {
                celsiusValue = ConvertFahrenheitToCelsius(value);
            }
        }

        public double Kelvin
        {
            get
            {
                return ConvertCelsiusToKelvin(celsiusValue);
            }
            set
            {
                celsiusValue = ConvertKelvinToCelsius(value);
            }
        }

        public string CelsiusValue
        {
            get
            {
                return string.Format("{0} {1}", Math.Round(Celsius, 2), celsiusType);
            }
        }

        public string FahrenheitValue
        {
            get
            {
                return string.Format("{0} {1}", Math.Round(Fahrenheit, 2), fahrenheitType);
            }
        }

        public string KelvinValue
        {
            get
            {
                return string.Format("{0} {1}", Math.Round(Kelvin, 2), kelvinType);
            }
        }

        private double ConvertCelsiusToFahrenheit(double number)
        {
            //(x °C × 9/5) + 32 =  °F
            return number * 9 / 5 + 32;
        }

        private double ConvertFahrenheitToCelsius(double number)
        {
            //(x °F − 32) × 5/9 =  °C
            return (number - 32) * 5 / 9;
        }

        private double ConvertKelvinToCelsius(double number)
        {
            //x K − 273,15 =  °C
            return number - 273.15;
        }

        private double ConvertCelsiusToKelvin(double number)
        {
            //x °C + 273,15 =  K
            return number + 273.15;
        }
    }
}
