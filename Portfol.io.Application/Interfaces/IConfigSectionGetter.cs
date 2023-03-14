namespace Portfol.io.Application.Interfaces
{
    /// <summary>
    /// Интерфейс получателя секции конфигурации
    /// </summary>
    public interface IConfigSectionGetter
    {
        /// <summary>
        /// Получить значение секции конфигурации
        /// </summary>
        /// <param name="key">Название секции</param>
        /// <returns></returns>
        public string GetSection(string key);
    }
}
