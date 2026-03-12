using UnityEditor;
using UnityEngine;

namespace Utilitas.Hotkeys {
    internal static class CloseWindowTab {
        [MenuItem("File/Close Window Tab %w")]
        static void CloseTab() {
            EditorWindow focusedWindow = EditorWindow.focusedWindow;
            if (focusedWindow != null) {
                CloseTab(focusedWindow);
            }
            else {
                Debug.LogWarning("Found no focused window to close");
            }
        }

        static void CloseTab(EditorWindow editorWindow) {
            editorWindow.Close();
        }
    }
}