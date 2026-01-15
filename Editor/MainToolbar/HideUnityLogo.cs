using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace Utilitas.Utilitas.Editor {
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UIElements;

    [InitializeOnLoad]
    public static class UnityLogoHider {
        static UnityLogoHider() => EditorApplication.delayCall += EditorApplication_DelayCall;

        static void EditorApplication_DelayCall() =>
            Resources.FindObjectsOfTypeAll<EditorWindow>().First(X => X.GetType().Name == "MainToolbarWindow")
                .rootVisualElement.Q("ToolbarProductCaption").style.display = DisplayStyle.None;
    }
}