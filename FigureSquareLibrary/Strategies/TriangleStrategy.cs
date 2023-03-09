using FigureSquareLibrary.Dto;
using FigureSquareLibrary.Interfaces;

namespace FigureSquareLibrary.Models
{
    /// <summary>
    /// Треугольник.
    /// </summary>
    internal class TriangleStrategy : IFigureStrategy
    {
        /// <inheritdoc/>
        public double CalculateSquare(FigureDto figureDto)
        {
            double firstSide = figureDto.FigureSides.First(),
                   secondSide = figureDto.FigureSides[1],
                   thirdSide = figureDto.FigureSides[2],
                   firstCathetus, secondCathetus;

            if (IsExist(firstSide, secondSide, thirdSide))
            {
                if (IsStraightTriangle(firstSide, secondSide, thirdSide, out firstCathetus, out secondCathetus))
                    return CalculateSquareStraightTriangle(firstCathetus, secondCathetus);
                return CalculateSquareTriangle(firstSide, secondSide, thirdSide);
            }

            throw new InvalidOperationException("Треугольник с заданными сторонами не существует.");
        }

        /// <summary>
        /// Проверка на существование треугольника.
        /// </summary>
        /// <param name="firstSide"> Первая сторона. </param>
        /// <param name="secondSide"> Вторая сторона. </param>
        /// <param name="thirdSide"> Третья сторона. </param>
        /// <returns> Возвращает true, если такой треугольник существует. </returns>
        private bool IsExist(double firstSide, double secondSide, double thirdSide)
        {
            return firstSide < secondSide + thirdSide &&
                secondSide < firstSide + thirdSide &&
                thirdSide < firstSide + secondSide;
        }

        /// <summary>
        /// Проверка на прямоугольность треугольника с нахождением катетов.
        /// </summary>
        /// <param name="firstSide"> Первая сторона. </param>
        /// <param name="secondSide"> Вторая сторона. </param>
        /// <param name="three"> Третья сторона. </param>
        /// <param name="cathetus1"> Первый возможный катет. </param>
        /// <param name="cathetus2"> Второй возможный катет. </param>
        /// <returns> Возвращает true, если треугольник прямой.  </returns>
        private bool IsStraightTriangle(
            double firstSide, double secondSide, double thirdSide, out double cathetus1, out double cathetus2)
        {
            var firstSidePow = Math.Pow(firstSide, 2);
            var secondSidepow = Math.Pow(secondSide, 2);
            var thirdSidePow = Math.Pow(thirdSide, 2);
            cathetus1 = 0;
            cathetus2 = 0;

            if ((firstSidePow + secondSidepow) == thirdSidePow) { cathetus1 = firstSide; cathetus2 = secondSide; return true; }
            else if ((firstSidePow + thirdSidePow) == secondSidepow) { cathetus1 = firstSide; cathetus2 = thirdSide; return true; }
            else if ((secondSidepow + thirdSidePow) == firstSidePow) { cathetus1 = secondSide; cathetus2 = thirdSide; return true; }
            else return false;
        }

        /// <summary>
        /// Находит площадь прямого треугольника через полупроизведение катетов.
        /// </summary>
        /// <param name="firstCathetus"> Первый катет. </param>
        /// <param name="secondCathetus"> Второй катет. </param>
        /// <returns> Площадь прямого треугольника. </returns>
        private double CalculateSquareStraightTriangle(double firstCathetus, double secondCathetus) 
            =>  firstCathetus * secondCathetus / 2;

        /// <summary>
        /// Находит площадь треугольника по трём сторонам (формула Герона).
        /// </summary>
        /// <param name="firstSide"> Первая сторона. </param>
        /// <param name="secondSide"> Вторая сторона. </param>
        /// <param name="thirdSide"> Третья сторона. </param>
        /// <returns> Площадь треугольника. </returns>
        private double CalculateSquareTriangle(double firstSide, double secondSide, double thirdSide)
        {
            //Находим периметр треугольника.
            double p = (firstSide + secondSide + thirdSide) / 2;

            return Math.Sqrt(p * (p - firstSide) * (p - secondSide) * (p - thirdSide));
        }
       
    }
}
