using System;
using UnityEngine.UIElements;

namespace Utilitas {
    public static class UIKVisualElementExtensions {
        public static VisualElement WithUserData(
            this VisualElement element,
            object userData
        ) {
            element.userData ??= userData;
            return element;
        }

        public static void AddMultiple(this VisualElement parent, params VisualElement[] elements) {
            foreach (VisualElement e in elements) {
                parent.Add(e);
            }
        }

        public static VisualElement FindElementByName(this VisualElement element, string name) {
            return element.FindElement(e => e.name == name);
        }

        public static VisualElement FindElementByTooltip(this VisualElement element, string tooltip) {
            return element.FindElement(e => e.tooltip == tooltip);
        }

        public static VisualElement FindElementByClass(
            this VisualElement element,
            string className,
            Func<VisualElement, bool> filter = null
        ) {
            return element.FindElement(e => e.ClassListContains(className) && (filter == null || filter(e)));
        }

        private static VisualElement FindElement(this VisualElement element, Func<VisualElement, bool> predicate) {
            return predicate(element) ? element : element.Query<VisualElement>().Where(predicate).First();
        }
    }
}