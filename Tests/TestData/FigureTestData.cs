using FigureSquareLibrary.Dto;

namespace Tests.Datas
{
    /// <summary>
    /// Тестовые данные.
    /// </summary>
    internal static class FigureTestData
    {
        /// <summary>
        /// Корректные данные для вычисления площади круга.
        /// Первое значение - стороны фигуры, второе - ожидаемое значение.
        /// </summary>
        public static object[] CalculateCircleSquare => new object[]
        {
            new object[] { new FigureDto { FigureSides = new List<double> { 20 } }, 1256.6},
            new object[] { new FigureDto { FigureSides = new List<double> { 12 } }, 452.4},
            new object[] { new FigureDto { FigureSides = new List<double> { 2 } }, 12.6}
        };

        /// <summary>
        /// Некорректное значение для стороны фигуры.
        /// </summary>
        public static object[] IncorrectFigureSideValue => new object[]
        {
            new object[] { new FigureDto { FigureSides = new List<double> { -1 } }},
        };

        /// <summary>
        /// Корректные данные для вычисления площади треугольника.
        /// Первое значение - стороны фигуры, второе - ожидаемое значение.
        /// </summary>
        public static object[] CalculateTriangleSquare => new object[]
        {
            new object[] { new FigureDto { FigureSides = new List<double> { 5, 6, 7 } }, 14.7},
            new object[] { new FigureDto { FigureSides = new List<double> { 6, 8, 10 } }, 24},
            new object[] { new FigureDto { FigureSides = new List<double> { 100, 200, 150 } }, 7261.8 }
        };

        /// <summary>
        /// Некорректное значение для стороны фигуры.
        /// </summary>
        public static object[] IncorrectTriangleSidesValue => new object[]
        {
            new object[] { new FigureDto { FigureSides = new List<double> { 6, 6, 100 }}},
            new object[] { new FigureDto { FigureSides = new List<double> { 100, 200, 300 }}},
            new object[] { new FigureDto { FigureSides = new List<double> { -8, 6, 10 }}}
        };
    }
}
