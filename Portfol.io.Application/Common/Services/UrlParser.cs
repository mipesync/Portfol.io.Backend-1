namespace Portfol.io.Application.Common.Services
{
    /// <summary>
    /// Парсер стандартного пути до файла к пути, пригодного для статического отображения
    /// </summary>
    public static class UrlParser
    {
        /// <summary>
        /// Преобразует путь до файла в ссылку для статического отображения
        /// </summary>
        /// <param name="path">Путь, который надо преобразовать в ссылку</param>
        /// <param name="url">Адрес текущего хоста</param>
        /// <returns>Преобразованная ссылка</returns>
        public static string Parse(string path, string url)
        {
            var result = string.Concat(url, path);
            return result;
        }
    }
}
