namespace Portfol.io.Application.Interfaces
{
    /// <summary>
    /// Интерфейс для текстового сообщения
    /// </summary>
    public interface ITextMessage : IMessage
    {
        /// <summary>
        /// Получить/установить текст сообщения
        /// </summary>
        string Text { get; set; }
    }
}
