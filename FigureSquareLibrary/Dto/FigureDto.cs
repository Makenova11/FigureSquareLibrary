using System.ComponentModel.DataAnnotations;

namespace FigureSquareLibrary.Dto
{
    /// <summary>
    /// Dto фигуры для вычиления площади.
    /// </summary>
    public record FigureDto
    {
        /// <summary>
        /// Лист значений сторон фигуры.
        /// </summary>
        public List<double> FigureSides { get; set; }
    }
}
