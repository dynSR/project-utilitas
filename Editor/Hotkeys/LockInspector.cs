using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Utilitas.Hotkeys {
    internal static class LockInspector {
        private static readonly MethodInfo flipLocked;
        private static readonly PropertyInfo constrainProportions;
        private const BindingFlags BINDING_FLAGS = BindingFlags.NonPublic | BindingFlags.Instance;

        static LockInspector() {
            // Cache static MethodInfo and PropertyInfo for performance
#if UNITY_2023_2_OR_NEWER
            var editorLockTrackerType =
                typeof(EditorGUIUtility).Assembly.GetType("UnityEditor.EditorGUIUtility+EditorLockTracker");
            flipLocked = editorLockTrackerType.GetMethod("FlipLocked", BINDING_FLAGS);
#endif
            constrainProportions = typeof(Transform).GetProperty("constrainProportionsScale", BINDING_FLAGS);
        }

        [MenuItem("Edit/Toggle Inspector Lock %l")]
        static void Lock() {
            // New approach for Unity 2023.2 and above, including Unity 6
            Type inspectorWindowType = typeof(Editor).Assembly.GetType("UnityEditor.InspectorWindow");
            foreach (var inspectorWindow in Resources.FindObjectsOfTypeAll(inspectorWindowType)) {
                var lockTracker = inspectorWindowType.GetField("m_LockTracker", BINDING_FLAGS)
                    ?.GetValue(inspectorWindow);
                flipLocked?.Invoke(lockTracker, new object[] { });
            }

            // Constrain Proportions lock for all versions including Unity 6
            foreach (var activeEditor in ActiveEditorTracker.sharedTracker.activeEditors) {
                if (activeEditor.target is not Transform target) continue;

                var currentValue = (bool)constrainProportions.GetValue(target, null);
                constrainProportions.SetValue(target, !currentValue, null);
            }

            ActiveEditorTracker.sharedTracker.ForceRebuild();
        }

        [MenuItem("Edit/Toggle Inspector Lock %l", true)]
        public static bool Valid() {
            return ActiveEditorTracker.sharedTracker.activeEditors.Length != 0;
        }
    }
}