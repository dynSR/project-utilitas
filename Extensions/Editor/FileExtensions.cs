using System.IO;

namespace Utilitas {
    public static class FileExtensions {
        /// <summary>
        /// Determines whether the specified file path refers to a supported font file type.
        /// </summary>
        /// <param name="path">
        /// File path whose extension will be evaluated.
        /// </param>
        /// <returns>
        /// <c>true</c> if the file extension represents a font file type; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown if <paramref name="path"/> is null, empty, or contains only whitespace.
        /// </exception>
        public static bool IsFileTypeOfFont(this string path) {
            if (path.IsNullOrWhiteSpace()) {
                throw new System.ArgumentException(nameof(path));
            }

            string extension = Path.GetExtension(path).ToLowerInvariant();
            return extension == ".ttf" || extension == ".otf";
        }
    }
}