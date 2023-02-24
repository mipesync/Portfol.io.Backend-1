namespace Portfol.io.Application.Interfaces
{
    /// <summary>
    /// Интерфейс отправки сообщения
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Отправить сообщение
        /// </summary>
        void Send();
        /// <summary>
        /// Получить/установить получателя
        /// </summary>
        string ToAddress { get; set; }
        /// <summary>
        /// Получить/установить отправителя
        /// </summary>
        string FromAddress { get; }
    }
}
