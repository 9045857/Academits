namespace L2Vector
{
    internal class WarningStrings
    {
        internal const string VectorWithCoordinatesCountErrorMessage = "Ошибка в конструкторе Vector({0}):  заданное количество координат <= 0 ";
        internal const string VectorWithCoordinatesCountAndArrayErrorMessage = "Ошибка в конструкторе Vector({0}, array):  заданное количество координат <= 0 ";
        internal const string GetCoordinateRangeErrorMessage = "Ошибка в GetCoordinate({0}): индекс вне диапазона [0, {1}]";
        internal const string SetCoordinateRangeErrorMessage = "Ошибка в SetCoordinate({0}, value): индекс вне диапазона [0, {1}]";
    }
}
