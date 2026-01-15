// using System;
// using System.Collections.Generic;
// using System.Linq;
// using JetBrains.Annotations;
// using UnityEditor;
// using UnityEngine;
//
// namespace Utilitas {
//     [Serializable]
//     internal class FolderColorEntry {
//         public string guid;
//         public Color color;
//     }
//
//     internal class PersistedFolderColors : ScriptableObject {
//         public List<FolderColorEntry> entries = new();
//
//         public void Save(FolderColorEntry entry) {
//             entries.Add(entry);
//         }
//
//         public void Delete(FolderColorEntry entry) {
//             entries.Remove(entry);
//         }
//     }
//
//     internal static class FolderColorDatabase {
//         private const string DB_ASSET_PATH = "Assets/Utilitas/Editor/ProjectWindow/FolderColorDatabase.asset";
//         private static PersistedFolderColors database;
//
//         public static PersistedFolderColors Database {
//             get {
//                 if (database == null) {
//                     EditorApplication.delayCall += CreateOrLoad;
//                 }
//
//                 return database;
//             }
//         }
//
//         static void CreateOrLoad() {
//             database = AssetDatabase.LoadAssetAtPath<PersistedFolderColors>(DB_ASSET_PATH);
//
//             if (database != null) {
//                 Debug.Log($"Folder Color DB loaded under {DB_ASSET_PATH}");
//                 return;
//             }
//
//             database = ScriptableObject.CreateInstance<PersistedFolderColors>();
//             // database.Init();
//             AssetDatabase.CreateAsset(database, DB_ASSET_PATH);
//             AssetDatabase.SaveAssets();
//
//             EditorGUIUtility.PingObject(database);
//             Debug.Log($"Folder Color DB created under {DB_ASSET_PATH}");
//         }
//
//         public static bool TryGetColor(string guid, out Color color) {
//             FolderColorEntry entry = GetEntryById(guid);
//             if (entry != null) {
//                 color = entry.color;
//                 return true;
//             }
//
//             color = default;
//             return false;
//         }
//
//         public static void SetColor(string guid, Color color) {
//             FolderColorEntry entry = GetEntryById(guid);
//             if (entry != null) {
//                 entry.color = color;
//             }
//             else {
//                 Database.Save(new FolderColorEntry {
//                     guid = guid,
//                     color = color
//                 });
//             }
//
//             EditorUtility.SetDirty(Database);
//             AssetDatabase.SaveAssets();
//         }
//
//         [CanBeNull]
//         static FolderColorEntry GetEntryById(string guid) {
//             if (Database.entries.IsEmpty()) {
//                 return null;
//             }
//
//             return Database.entries.FirstOrDefault(e => e.guid == guid);
//         }
//     }
// }