using FigureSquareLibrary.Constants;
using FigureSquareLibrary.Dto;
using FigureSquareLibrary.Interfaces;
using FigureSquareLibrary.Models;

namespace FigureSquareLibrary.Strategies
{
    /// <summary>
    /// Стратегия для определения типа вычисляемой фигуры.
    /// </summary>
    internal static class FigureStrategy
    {
        /// <summary>
        /// Словарь, хранящий стратегии вычисляемых фигур.
        /// </summary>
        private static IDictionary<int, Func<IFigureStrategy>> _strategies =
            new Dictionary<int, Func<IFigureStrategy>>()
          {
              { SideCountConstants.Cirlce, () => new CircleStrategy() },
              { SideCountConstants.Triangle, () => new TriangleStrategy() }
          };

        /// <summary>
        /// Формирует сообщение об ошибке в случае, когда стратегия не найдена.
        /// </summary>
        /// <param name="sideCount"> Количество сторон.</param>
        /// <returns> Сообщение об ошибке. </returns>
        private static string GetErrorMessage(int sideCount) =>
            $"Не удалось найти фигуру с количеством сторон {sideCount}";

        /// <summary>
        /// Определить стратегию для вычиления площади.
        /// </summary>
        /// <param name="figureDto"> Dto </param>
        /// <returns> Стратегия вычисления фигуры. </returns>
        internal static IFigureStrategy GetFigureStrategy(FigureDto figureDto)
        {
            var sideCount = figureDto.FigureSides.Count;

            if (_strategies.ContainsKey(sideCount))
                return _strategies[sideCount]();
            throw new InvalidOperationException(GetErrorMessage(sideCount));
        }
    }
}
