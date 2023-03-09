using FigureSquareLibrary.Dto;
using FigureSquareLibrary.Interfaces;
using FigureSquareLibrary.Strategies;
using FluentAssertions;
using Tests.Datas;

namespace Tests.Tests
{
    /// <summary>
    /// Unit-����� ���������� ������� ������.
    /// </summary>
    [TestFixture]
    public class FigureSquareTest
    {
        /// <inheritdoc/>
        private IFigureStrategy? _figureStrategy;

        /// <summary>
        /// ���� �� ������� ������� ����� ��� ������� ���������� ��������.
        /// </summary>
        /// <param name="figureDto"> Dto �� ���������.</param>
        /// <param name="expectedValue"> �������� �������� �������. </param>
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
        /// ���� � ������������� ���������� �������, ������� �������� ���������� ����������.
        /// </summary>
        /// <param name="figureDto"> Dto � ������������� ����������. </param>
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
        /// ���� � ������������� ����������, ������� �������� ���������� ����������.
        /// </summary>
        /// <param name="figureDto"> Dto � ������������� ����������. </param>
        /// <param name="expectedValue"> �������� �������� �������. </param>
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
        /// ���� � ������������� ���������� �������, ������� �������� ���������� ����������.
        /// </summary>
        /// <param name="figureDto"> Dto � ������������� ����������. </param>
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