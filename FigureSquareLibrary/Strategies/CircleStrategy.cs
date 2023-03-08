using FigureSquareLibrary.Dto;
using FigureSquareLibrary.Interfaces;

namespace FigureSquareLibrary.Models
{
    /// <summary>
    /// Круга.
    /// </summary>
    internal class CircleStrategy : IFigureStrategy
    {
        /// <summary>
        /// Радиус круга.
        /// </summary>
        internal double Radius { get; set; }

        /// <inheritdoc />
        public  double CalculateSquare(FigureDto figureDto)
        {
            Radius = figureDto.FigureSides.First();

            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
