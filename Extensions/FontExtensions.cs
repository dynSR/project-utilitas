using System;
using System.IO;
using UnityEngine;

namespace Utilitas {
    public static class FontExtensions {
        /// <summary>
        /// Extracts the font family name from a <see cref="Font"/> asset
        /// based on its name using the dash ('-') naming convention.
        /// </summary>
        /// <param name="font">
        /// The <see cref="Font"/> asset whose name is expected to follow the
        /// <c>FamilyName-StyleName</c> convention (e.g. <c>"Roboto-Bold"</c>).
        /// </param>
        /// <returns>
        /// The font family name portion of the font asset name.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown if <paramref name="font"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown if the font asset name does not contain a dash character.
        /// </exception>
        public static string GetFontFamilyName(this Font font) {
            return font.name.GetFontFamilyName();
        }
    }
}