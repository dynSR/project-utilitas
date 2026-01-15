// using System.IO;
// using UnityEditor;
// using UnityEngine;
//
// namespace Utilitas {
//     internal class ZebraOverlay {
//         private static readonly Color darkColor = new(0f, 0f, 0f, 0.05f);
//         private static readonly Color lightColor = new(255f, 255f, 255f, 0.025f);
//
//         public static void Draw(string guid, Rect rect) {
//             string assetPath = AssetDatabase.GUIDToAssetPath(guid);
//             if (assetPath.IsNullOrEmpty()) {
//                 return;
//             }
//
//             int rowIndex = Mathf.FloorToInt(rect.y / rect.height);
//             EditorGUI.DrawRect(rect, rowIndex.IsEven() ? darkColor : lightColor);
//         }
//     }
// }