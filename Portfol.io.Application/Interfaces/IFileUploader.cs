using Microsoft.AspNetCore.Http;

namespace Portfol.io.Application.Interfaces
{
    /// <summary>
    /// Интерфейс загрузчика файлов
    /// </summary>
    public interface IFileUploader
    {
        /// <summary>
        /// Получить/установить файл
        /// </summary>
        IFormFile File { get; set; }
        /// <summary>
        /// Получить/установить абсолютный путь к файлу
        /// </summary>
        string AbsolutePath { get; set; }
        /// <summary>
        /// Получить/установить корневой путь проекта
        /// </summary>
        string WebRootPath { get; set; }

        /// <summary>
        /// Загрузить файл в хранилище
        /// </summary>
        /// <returns>Путь к файлу</returns>
        Task<string> Upload();
    }
}
