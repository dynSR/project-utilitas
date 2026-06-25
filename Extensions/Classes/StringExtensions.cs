using System;

namespace Utilitas {
    public static class StringExtensions {
        /// <summary>Checks if a string contains null, empty or white space.</summary>
        public static bool IsBlank(this string value) => value.IsNullOrWhiteSpace() || value.IsNullOrEmpty();

        /// <summary>Checks if a string is Null or white space</summary>
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        /// <summary>Checks if a string is Null or empty</summary>
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

        /// <summary>Checks if a string is null and returns an empty string if it is.</summary>
        public static string OrEmpty(this string value) => value ?? string.Empty;

        /// <summary>
        /// Shortens a string to the specified maximum length. If the string's length
        /// is less than the maxLength, the original string is returned.
        /// </summary>
        public static string Shorten(this string value, int maxLength) {
            if (value.IsBlank()) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        /// <summary>
        /// Returns a new string containing only the first occurrence of each character
        /// from the source string, preserving the original character order.
        /// </summary>
        /// <param name="value">
        /// Source string from which duplicate characters will be removed.
        /// </param>
        /// <returns>
        /// A new string with duplicate characters removed.
        /// The relative order of the remaining characters is preserved.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="value"/> is <c>null</c>.
        /// </exception>
        public static string WithNoDuplicate(this string value) {
            var seen = new System.Collections.Generic.HashSet<char>();
            var result = new System.Text.StringBuilder(value.Length);

            foreach (char c in value) {
                if (seen.Add(c)) {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Appends a platform-specific newline sequence to the end of the string.
        /// </summary>
        /// <param name="value">
        /// Source string to which the newline will be appended.
        /// </param>
        /// <returns>
        /// A new string ending with <see cref="Environment.NewLine"/>.
        /// </returns>
        public static string WithNewLine(this string value) {
            return value + Environment.NewLine;
        }

        /// <summary>
        /// Extracts the font family name from a font identifier string using a dash ('-') separator.
        /// </summary>
        /// <param name="value">
        /// Font name string expected to contain a dash separating the family name
        /// from the style or variant (e.g. <c>"Roboto-Bold"</c>).
        /// </param>
        /// <returns>
        /// The font family name portion of the string (substring before the last dash).
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="value"/> does not contain a dash character.
        /// </exception>
        public static string GetFontFamilyName(this string value) {
            return value.Contains('-')
                ? value.Substring(0, value.LastIndexOf('-'))
                : throw new ArgumentException("", nameof(value));
        }

        // Rich text formatting, for Unity UI elements that support rich text.
        public static string RichColor(this string value, string color) => $"<color={color}>{value}</color>";
        public static string RichSize(this string value, int size) => $"<size={size}>{value}</size>";
        public static string RichBold(this string value) => $"<b>{value}</b>";
        public static string RichItalic(this string value) => $"<i>{value}</i>";
        public static string RichUnderline(this string value) => $"<u>{value}</u>";
        public static string RichStrikethrough(this string value) => $"<s>{value}</s>";
        public static string RichFont(this string value, string font) => $"<font={font}>{value}</font>";
        public static string RichAlign(this string value, string align) => $"<align={align}>{value}</align>";

        public static string RichGradient(this string value, string color1, string color2) =>
            $"<gradient={color1},{color2}>{value}</gradient>";

        public static string RichRotation(this string value, float angle) => $"<rotate={angle}>{value}</rotate>";
        public static string RichSpace(this string value, float space) => $"<space={space}>{value}</space>";
    }
}