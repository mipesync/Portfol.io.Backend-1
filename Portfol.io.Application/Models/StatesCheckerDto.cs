namespace Portfol.io.Application.Models
{
    /// <summary>
    /// DTO, возвращаемое из проверки состояний товара
    /// </summary>
    public class StatesCheckerDto
    {
        /// <summary>
        /// Добавлен ли в избранные
        /// </summary>
        public bool IsFavourite { get; set; } = false;
        /// <summary>
        /// Оценён ли альбом
        /// </summary>
        public bool IsLiked { get; set; } = false;
    }
}
