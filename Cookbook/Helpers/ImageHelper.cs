using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Cookbook.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        ///     Переводит строковое представление расширения изображения в ImageFormat
        /// </summary>
        /// <param name="str">
        ///     Строка для парсинга
        /// </param>
        /// <returns>
        ///     Расширение изображения в виде ImageFormat
        /// </returns>
        public static ImageFormat ParseImageFormat(string str)
        {
            return (ImageFormat)typeof(ImageFormat)
                    .GetProperty(str, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase)
                    .GetValue(str, null);
        }

        /// <summary>
        ///     Декодирует изображение из base64 строки и сохраняет его по указанному пути в указанном формате 
        ///     и случайно сгенерированным именем
        /// </summary>
        /// <param name="str">
        ///     Строка с закодированным изображением в base64
        /// </param>
        /// <param name="path">
        ///     Путь, по которому будет сохранено изображение
        /// </param>
        /// <param name="format">
        ///     Формат, в котором будет сохранено изображение
        /// </param>
        /// <returns>Имя сохраненного изображения</returns>
        /// <exception cref="ArgumentNullException">str, path или format равны null</exception>
        /// <exception cref="ArgumentException">path содержит запрещенные символы</exception>
        /// <exception cref="FormatException">str является неверным base64 форматом</exception>
        /// <exception cref="ExternalException">Изображение сохраняется в неверном формате</exception>
        [SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
        public static string SaveImageFromBase64(string str, string path, string format)
        {
            string imageName = Path.ChangeExtension(Path.GetRandomFileName(), format);
            string imagePath = Path.Combine(path, imageName);

            byte[] bytes = Convert.FromBase64String(str);
            using var ms = new MemoryStream(bytes);
            Image image = Image.FromStream(ms);
            image.Save(imagePath, ParseImageFormat(format));

            return imageName;
        }
    }
}
