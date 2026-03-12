using UnityEngine;
using UnityEngine.UIElements;

namespace Utilitas {
    public static class UIKButtonExtensions {
        public static Button WithText(
            this Button button,
            string text
        ) {
            button.text = text;
            return button;
        }

        public static Button WithImage(
            this Button button,
            Texture texture
        ) {
            button.Add(new Image { image = texture });
            return button;
        }

        public static Button WithWidth(
            this Button button,
            StyleLength width
        ) {
            button.style.width = width;
            return button;
        }

        public static Button UnfocusedOnClick(this Button button) {
            button.clicked += () => button.focusController.focusedElement.Blur();
            return button;
        }
    }
}