// using System.Collections.Generic;
// using System.IO;
// using UnityEditor;
// using UnityEngine;
//
// namespace Utilitas {
//     [InitializeOnLoad]
//     internal class ProjectFolderBackground {
//         static readonly Color[] colorPalette = {
//             new(0.9f, 0.3f, 0.3f),
//             new(0.9f, 0.6f, 0.3f),
//             new(0.9f, 0.9f, 0.3f),
//             new(0.3f, 0.9f, 0.3f),
//             new(0.3f, 0.6f, 0.9f),
//             new(0.6f, 0.3f, 0.9f),
//         };
//
//         static ProjectFolderBackground() {
//             EditorApplication.projectWindowItemOnGUI += Draw;
//         }
//
//         public static void Draw(string guid, Rect rect) {
//             Event e = Event.current;
//
//             string assetPath = AssetDatabase.GUIDToAssetPath(guid);
//             if (!assetPath.IsFolder()) {
//                 return;
//             }
//
//             if (e.type == EventType.MouseDown && e.button == 0 && e.alt) {
//                 var mousePos = e.mousePosition;
//                 var visibleItems = ProjectWindowHelper.GetVisibleItems();
//
//                 foreach (var (path, rowRect) in visibleItems) {
//                     if (!rowRect.Contains(mousePos)) {
//                         break;
//                     }
//
//                     string clickedGuid = AssetDatabase.AssetPathToGUID(path);
//
//                     // Stocker dans ta popup
//                     FolderColorPopup.TargetGuid = clickedGuid;
//                     FolderColorPopup.AnchorRect = rowRect;
//                     FolderColorPopup.IsOpen = true;
//                     FolderColorPopup.HoverColor = null;
//
//                     e.Use();
//                     EditorApplication.RepaintProjectWindow();
//                     break;
//                 }
//             }
//
//             if (FolderColorPopup.IsOpen) {
//                 DrawPopup();
//             }
//
//             if (FolderColorPopup.IsOpen && e.type == EventType.MouseDown) {
//                 Rect popupRect = FolderColorPopup.AnchorRect;
//                 popupRect.y += popupRect.height;
//                 popupRect.width = colorPalette.Length * (18f + 4f) + 4f; // width popup
//                 popupRect.height = 18f + 4f * 2;
//
//                 if (!popupRect.Contains(e.mousePosition)) {
//                     ClosePopup();
//                     e.Use();
//                     EditorApplication.RepaintProjectWindow();
//                 }
//             }
//
//             if (e.type != EventType.Repaint) {
//                 return;
//             }
//
//             bool isTarget = FolderColorPopup.IsOpen &&
//                             FolderColorPopup.TargetGuid == guid;
//
//             if (isTarget && FolderColorPopup.HoverColor.HasValue) {
//                 EditorGUI.DrawRect(rect, FolderColorPopup.HoverColor.Value);
//             }
//             else if (FolderColorDatabase.TryGetColor(guid, out Color color)) {
//                 EditorGUI.DrawRect(rect, color);
//             }
//             else {
//                 ZebraOverlay.Draw(guid, rect);
//             }
//         }
//
//         static void DrawPopup() {
//             // Debug.Log("POPUP SHOULD BE OPENED");
//
//             const float size = 24f;
//             const float padding = 6f;
//
//             Rect popupRect = FolderColorPopup.AnchorRect;
//             popupRect.y += popupRect.height;
//             popupRect.width = colorPalette.Length * (size + padding) + padding;
//             popupRect.height = size + padding * 2;
//
//             GUI.Box(popupRect, GUIContent.none, EditorStyles.helpBox);
//
//             var cell = new Rect(popupRect.x + padding, popupRect.y + padding, size, size);
//
//             foreach (Color color in colorPalette) {
//                 EditorGUI.DrawRect(cell, color);
//
//                 if (cell.Contains(Event.current.mousePosition)) {
//                     FolderColorPopup.HoverColor = color;
//
//                     if (Event.current.type == EventType.MouseDown) {
//                         FolderColorDatabase.SetColor(FolderColorPopup.TargetGuid, color);
//                         ClosePopup();
//                     }
//                 }
//
//                 cell.x += size + padding;
//             }
//         }
//
//         static void ClosePopup() {
//             FolderColorPopup.IsOpen = false;
//             FolderColorPopup.TargetGuid = null;
//             FolderColorPopup.HoverColor = null;
//             EditorApplication.RepaintProjectWindow();
//
//             Debug.Log("POPUP SHOULD BE CLOSED");
//         }
//     }
// }