using System;
using TMPro;
using UnityEngine;

namespace Utilitas {
    public static class TMPFontAssetExtensions {
        public static void PrepopulateCharacters(this TMP_FontAsset fontAsset, string characters) {
            bool success = fontAsset.TryAddCharacters(characters, out string missingCharacters);
            if (!success && !missingCharacters.IsNullOrEmpty()) {
                Debug.LogWarning(
                    $"Some characters could not be added to '{fontAsset.sourceFontFile.name}':" +
                    Environment.NewLine +
                    $"{missingCharacters}"
                );
            }
        }
    }
}