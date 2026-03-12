// using System.Reflection;
// using UnityEditor;
// using UnityEngine;
// using Type = System.Type;
//
// namespace Utilitas {
//     [InitializeOnLoad]
//     internal class ProjectWindow {
//         // A way to get the project browser ???
//         static Type projectBrowserType = typeof(Editor).Assembly.GetType("UnityEditor.ProjectBrowser");
//
//         private const BindingFlags METHOD_FLAGS = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
//
//         // static IEnumerable<EditorWindow> allBrowsers => _allBrowsers ??=
//         //     projectBrowserType.GetField("s_ProjectBrowsers").GetValue().Cast<EditorWindow>();
//         //
//         // static IEnumerable<EditorWindow> _allBrowsers;
//
//         static ProjectWindow() {
//             EditorApplication.projectWindowItemOnGUI += OnProjectItemGUI;
//         }
//
//         private static void OnProjectItemGUI(string guid, Rect rect) {
//             // Debug.Log(projectBrowserType.Name);
//             // Debug.Log(projectBrowserType.GetMembers());
//
//             // var projectBrowser = Resources.FindObjectsOfTypeAll(projectBrowserType).FirstOrDefault() as EditorWindow;
//             // MethodInfo method = projectBrowserType.GetMethod("GetCurrentVisibleNames", METHOD_FLAGS);
//             // var elements = method?.Invoke(projectBrowser, null);
//
//             if (Event.current.type != EventType.Repaint) {
//                 return;
//             }
//
//             //
//             // string[] guids = AssetDatabase.FindAssets("", new[] { "Assets/_project" });
//             //
//             // foreach (string id in guids) {
//             //     string path = AssetDatabase.GUIDToAssetPath(id);
//             //     var asset = AssetDatabase.LoadAssetAtPath<Object>(path);
//             //     Debug.Log(asset.name);
//             // }
//
//             // ZebraOverlay.Draw(guid, rect);
//             // ProjectFolderBackground.Draw(guid, rect);
//         }
//
//         // public static object GetFieldValue(this object o, string fieldName) {
//         //     var type = o as Type ?? o.GetType();
//         //     var target = o is Type ? null : o;
//         //
//         //
//         //     if (type.GetFieldInfo(fieldName) is FieldInfo fieldInfo)
//         //         return fieldInfo.GetValue(target);
//         //
//         //
//         //     throw new System.Exception($"Field '{fieldName}' not found in type '{type.Name}' and its parent types");
//         // }
//     }
// }