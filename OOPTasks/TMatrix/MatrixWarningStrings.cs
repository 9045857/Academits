namespace TMatrix
{
    class MatrixWarningStrings
    {
        internal const string MatrixRowsCountAndColumnsCountСonstructorErrorMessage = "Ошибка в конструкторе Matrix({0}, {1}):  количество срок или стобцов <= 0.";

        internal const string MatrixMatrixNullСonstructorErrorMessage = "Ошибка в конструкторе Matrix(matrix): matrix = null.";
        internal const string MatrixMatrixColunmsCount0СonstructorErrorMessage = "Ошибка в конструкторе Matrix(matrix): количество стобцов = 0.";
        internal const string MatrixMatrixRowsCount0СonstructorErrorMessage = "Ошибка в конструкторе Matrix(matrix): количество срок = 0.";

        internal const string MatrixVectorsArrayNullСonstructorErrorMessage = "Ошибка в конструкторе Matrix(vectorsArray): vectorsArray = null.";
        internal const string MatrixVectorsArray0ConstructorErrorMessage = "Ошибка в конструкторе Matrix(vectorsArray): длина массива = 0.";

        internal const string IndexNegativeErrorsMessage = "Ошибка Index = {0}: индекс < 0.";
        internal const string IndexInRangeErrorsMessage = "Ошибка Index = {0}: индекс < 0 или >= {1}.";

        internal const string VectorNullErrorMessage = "Ошибка: vector = null.";
        internal const string VectorCoordanates0ErrorMessage = "Ошибка: длина массива координат = 0.";

        internal const string IndexMoreMaxRowsCountErrorsMessage = "Ошибка index = {0}: количество строк = {}.";
        internal const string IndexMoreMaxColumnsCountErrorsMessage = "Ошибка index = {0}: количество столбцов = {}.";

        internal const string Array2DimentionNullErrorMessage = "Ошибка: array = null.";
        internal const string Array2DimentionRowsCount0ErrorMessage = "Ошибка: количество строк = 0.";
        internal const string Array2DimentionColumnsCount0ErrorMessage = "Ошибка: количество столбцов = 0.";

        internal const string ArraysArrayNullErrorMessage = "Ошибка: массив = null.";
        internal const string ArraysArrayCount0ErrorMessage = "Ошибка: количество массивов в массиве = 0.";
        internal const string ArraysNullErrorMessage = "Ошибка: массив {0} измерения = null.";
        internal const string ArraysCount0ErrorMessage = "Ошибка: длина массива {0} измерения = 0.";

        internal const string VectorAndMatrixDifferentSizesWhenMultiplyErrorMessage = "Ошибка: при умножении матрица и вектор имеют соответствующие разные размеры.";

        internal const string VectorLengthMoreMatrixErrorsMessage = "Ошибка: размер вектора ({0}) отличается от количества стобцов матрицы ({1}).";

        internal const string MatricesDifferentSizesErrorMessage = "Ошибка: матрицы имеют разные размеры.";

        internal const string MatricesSizesForMultiplyErrorMessage = "Ошибка: {0} столбцов в матрице1, {1} строк в матрице2 - несогласованный размер.";

        internal const string MatrixNotSquareErrorMessage = "Ошибка: у матрицы {0}x{1} разные количества строк и столбцов.";
    }
}
