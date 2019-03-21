namespace Swing2
{
    class TemperatureConverter
    {
        public static double Convert(double inputData, ITemperatureType inputType, ITemperatureType outputType)
        {
            double celsius = inputType.ToCelsius(inputData);
            
            return outputType.FromCelsius(celsius);
        }
    }
}
