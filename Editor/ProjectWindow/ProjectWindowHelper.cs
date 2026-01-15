// using System;
// using System.Collections.Generic;
// using System.Reflection;
// using UnityEditor;
// using UnityEngine;
// using Object = UnityEngine.Object;
//
// namespace Utilitas {
//     internal class ProjectWindowHelper {
//         static Type projectBrowserType = typeof(Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
//
//         static PropertyInfo lastInteractedBrowserProperty =
//             projectBrowserType.GetProperty("lastInteractedProjectBrowser", BindingFlags.Static | BindingFlags.Public);
//
//         static FieldInfo treeViewField =
//             projectBrowserType.GetField("m_TreeView", BindingFlags.NonPublic | BindingFlags.Instance);
//
//         public static object GetActiveTreeView() {
//             var browser = lastInteractedBrowserProperty.GetValue(null);
//             return browser == null ? null : treeViewField.GetValue(browser);
//         }
//
//         public static (string path, Rect rect)[] GetVisibleItems() {
//             var treeView = GetActiveTreeView();
//             if (treeView == null) return Array.Empty<(string, Rect)>();
//
//             var getRows = treeView.GetType()
//                 .GetMethod("GetRows", BindingFlags.NonPublic | BindingFlags.Instance);
//
//             var result = new List<(string, Rect)>();
//             if (getRows?.Invoke(treeView, null) is System.Collections.IList rows) {
//                 foreach (object row in rows) {
//                     // var itemField = row.GetType().GetProperty("id");
//                     // var id = itemField.GetValue(row);
//                     string path = AssetDatabase.GetAssetPath(row as Object);
//                     Debug.Log($"Row path : {path}");
//
//                     var rectField =
//                         row.GetType().GetProperty("controlRect", BindingFlags.NonPublic | BindingFlags.Instance);
//                     Rect rect = rectField != null ? (Rect)rectField.GetValue(row) : new Rect();
//
//                     result.Add((path, rect));
//                 }
//             }
//             else {
//                 return Array.Empty<(string, Rect)>();
//             }
//
//             return result.ToArray();
//         }
//     }
// }