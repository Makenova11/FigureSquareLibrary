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

            if (Radius <= 0)
                throw new InvalidOperationException("Значение должно быть больше 0.");

            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}
