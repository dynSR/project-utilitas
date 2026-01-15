using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utilitas {
    internal class ClearConsoleLogs {
        [MenuItem("Tools/Clear Console %q")]
        static void ClearConsole() {
            Assembly assembly = Assembly.GetAssembly(typeof(Editor));
            Type logEntries = assembly.GetType("UnityEditor.LogEntries");
            MethodInfo clearConsoleMethod = logEntries.GetMethod("Clear");
            clearConsoleMethod?.Invoke(new object(), null);
        }
    }
}