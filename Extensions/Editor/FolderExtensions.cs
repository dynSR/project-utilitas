using System;
using System.IO;
using UnityEditor;

namespace Utilitas {
    public static class FolderExtensions {
        /// <summary>
        /// Ensures that a Unity asset folder exists at the specified path.
        /// If the folder does not exist, it is created using <see cref="AssetDatabase.CreateFolder"/>.
        /// </summary>
        /// <param name="folderName">
        /// Unity-relative folder path (must start with <c>"Assets/"</c>).
        /// Example: <c>"Assets/Fontos/GeneratedFonts"</c>.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// Thrown if <paramref name="folderName"/> is null, empty, or contains only whitespace.
        /// </exception>
        public static void EnsureFolderExists(this string folderName) {
            if (FolderExists(folderName)) {
                return;
            }

            string parent = Path.GetDirectoryName(folderName);
            string leaf = Path.GetFileName(folderName);
            AssetDatabase.CreateFolder(parent, leaf);
        }

        /// <summary>
        /// Determines whether a Unity asset folder exists at the specified path.
        /// </summary>
        /// <param name="folderName">
        /// Unity-relative folder path (must start with <c>"Assets/"</c>).
        /// </param>
        /// <returns>
        /// <c>true</c> if the folder exists and is a valid Unity asset folder;
        /// otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown if <paramref name="folderName"/> is null, empty, or contains only whitespace.
        /// </exception>
        public static bool FolderExists(this string folderName) {
            return !folderName.IsNullOrWhiteSpace()
                ? AssetDatabase.IsValidFolder(folderName)
                : throw new ArgumentException(nameof(folderName));
        }

        /// <summary>
        /// Determines whether the specified folder contains at least one font file.
        /// </summary>
        /// <param name="folderPath">
        /// Absolute or relative folder path to inspect.
        /// </param>
        /// <returns>
        /// <c>true</c> if the folder contains at least one font file; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="folderPath"/> is null, empty, or contains only whitespace.
        /// </exception>
        public static bool FolderContainsFontFiles(this string folderPath) {
            if (folderPath.IsNullOrWhiteSpace()) {
                throw new ArgumentException(nameof(folderPath));
            }

            string[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string file in files) {
                if (file.IsFileTypeOfFont()) {
                    return true;
                }
            }

            return false;
        }
    }
}