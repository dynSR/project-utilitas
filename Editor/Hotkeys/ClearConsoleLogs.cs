using System;
using System.Reflection;
using UnityEditor;

namespace Utilitas.Hotkeys {
    internal static class ClearConsoleLogs {
        [MenuItem("Edit/Clear Console %q")]
        static void ClearConsole() {
            var assembly = Assembly.GetAssembly(typeof(Editor));
            Type logEntries = assembly.GetType("UnityEditor.LogEntries");
            MethodInfo clearConsoleMethod = logEntries.GetMethod("Clear");
            clearConsoleMethod?.Invoke(new object(), null);
        }
    }
}