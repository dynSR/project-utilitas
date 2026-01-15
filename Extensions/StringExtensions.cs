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