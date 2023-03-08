using FigureSquareLibrary.Dto;

namespace FigureSquareLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий общие .
    /// </summary>
    internal interface IFigureStrategy
    {
        /// <summary>
        /// Посчитать площадь фигуры.
        /// </summary>
        /// <param name="figureDto"> Одна или несколько сторон фигуры.. </param>
        /// <returns> Площадь фигуры. </returns>
        internal double CalculateSquare(FigureDto figureDto);
    }
}
