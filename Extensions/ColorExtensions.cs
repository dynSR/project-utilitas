using System;
using UnityEngine;

namespace Utilitas {
    public static class ColorExtensions {
        /// <summary>
        /// Sets the alpha component of the color.
        /// </summary>
        /// <param name="color">The original color.</param>
        /// <param name="alpha">The new alpha value.</param>
        /// <returns>A new color with the specified alpha value.</returns>
        public static Color SetAlpha(this Color color, float alpha)
            => new(color.r, color.g, color.b, alpha);

        /// <summary>
        /// Converts a Color to a hexadecimal string.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <returns>A hexadecimal string representation of the color.</returns>
        public static string ToHex(this Color color) => $"#{ColorUtility.ToHtmlStringRGBA(color)}";

        /// <summary>
        /// Converts a hexadecimal string to a Color.
        /// </summary>
        /// <param name="hex">The hexadecimal string to convert.</param>
        /// <returns>The Color represented by the hexadecimal string.</returns>
        public static Color HexToColor(this string hex) {
            if (ColorUtility.TryParseHtmlString(hex, out Color color)) {
                return color;
            }

            throw new ArgumentException("Invalid hex string", nameof(hex));
        }

        /// <summary>
        /// Inverts the color.
        /// </summary>
        /// <param name="color">The color to invert.</param>
        /// <returns>The inverted color.</returns>
        public static Color Invert(this Color color)
            => new(1 - color.r, 1 - color.g, 1 - color.b, color.a);
    }
}