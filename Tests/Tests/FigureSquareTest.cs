using FigureSquareLibrary.Dto;
using FigureSquareLibrary.Interfaces;
using FigureSquareLibrary.Strategies;
using FluentAssertions;
using Tests.Datas;

namespace Tests.Tests
{
    /// <summary>
    /// Unit-тесты вычисления площади фигуры.
    /// </summary>
    [TestFixture]
    public class FigureSquareTest
    {
        /// <inheritdoc/>
        private IFigureStrategy? _figureStrategy;

        /// <summary>
        /// Тест на подсчёт площади круга при наличие корректных значений.
        /// </summary>
        /// <param name="figureDto"> Dto со сторонами.</param>
        /// <param name="expectedValue"> Ожидемое значение площади. </param>
        [TestCaseSource(typeof(FigureTestData), nameof(FigureTestData.CalculateCircleSquare))]
        public void Should_CalculateCircleSquare_When_RadiusIsExist(FigureDto figureDto, double expectedValue)
        {
            //Arrange
            _figureStrategy = FigureStrategy.GetFigureStrategy(figureDto);

            //Act
            var circleSquare = Math.Round(_figureStrategy.CalculateSquare(figureDto), 1);

            //Assert
            circleSquare.Should().Be(expectedValue);
        }

        /// <summary>
        /// Тест с некорректными значениями радиуса, который ожидаемо выкидывает исключение.
        /// </summary>
        /// <param name="figureDto"> Dto с некорректными значениями. </param>
        [TestCaseSource(typeof(FigureTestData), nameof(FigureTestData.IncorrectFigureSideValue))]
        public void Should_ThrowInvalidOperationException_When_ValueIsNotCorrect(FigureDto figureDto)
        {
            //Arrange
            _figureStrategy = FigureStrategy.GetFigureStrategy(figureDto);

            //Act
            var circleSquareAction = () => Math.Round(_figureStrategy.CalculateSquare(figureDto), 1);

            //Assert
            circleSquareAction.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Тест с некорректными значенеями, который ожидаемо выкидывает исключение.
        /// </summary>
        /// <param name="figureDto"> Dto с некорректными значениями. </param>
        /// <param name="expectedValue"> Ожидемое значение площади. </param>
        [TestCaseSource(typeof(FigureTestData), nameof(FigureTestData.CalculateTriangleSquare))]
        public void Should_CalculateTriangleSquare_When_TriangleSidesIsCorrect(FigureDto figureDto, double expectedValue)
        {
            //Arrange
            _figureStrategy = FigureStrategy.GetFigureStrategy(figureDto);

            //Act
            var circleSquare = Math.Round(_figureStrategy.CalculateSquare(figureDto), 1);

            //Assert
            circleSquare.Should().Be(expectedValue);
        }

        /// <summary>
        /// Тест с некорректными значениями радиуса, который ожидаемо выкидывает исключение.
        /// </summary>
        /// <param name="figureDto"> Dto с некорректными значениями. </param>
        [TestCaseSource(typeof(FigureTestData), nameof(FigureTestData.IncorrectTriangleSidesValue))]
        public void Should_ThrowInvalidOperationException_When_TriangleIsNotExist(FigureDto figureDto)
        {
            //Arrange
            _figureStrategy = FigureStrategy.GetFigureStrategy(figureDto);

            //Act
            var circleSquareAction = () => Math.Round(_figureStrategy.CalculateSquare(figureDto), 1);

            //Assert
            circleSquareAction.Should().Throw<InvalidOperationException>();
        }

    }
}