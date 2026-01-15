using UnityEditor;
using UnityEngine;
using UnityEditor.Toolbars;
using UnityEngine.UIElements;

namespace Utilitas {
    internal class MainToolbarTimescaleSlider {
        private const float MIN_TIME_SCALE = 0f;
        private const float MAX_TIME_SCALE = 10f;
        private const string PATH = "Timescale/Slider";

        [MainToolbarElement(PATH, defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement TimeSlider() {
            var content = new MainToolbarContent("Time Scale", " Time Scale Slider");
            var slider = new MainToolbarSlider(
                content,
                Time.timeScale,
                MIN_TIME_SCALE,
                MAX_TIME_SCALE,
                OnSliderValueChanged
            );

            slider.populateContextMenu = (menu) => {
                menu.AppendAction("Reset", _ => {
                    Time.timeScale = 1f;
                    MainToolbar.Refresh(PATH);
                });
            };

            MainToolbarElementStyler.StyleElement<VisualElement>(PATH,
                (element) => { element.style.paddingLeft = 10f; });

            return slider;
        }

        private static void OnSliderValueChanged(float value) {
            Time.timeScale = value;
        }

        [MainToolbarElement("Timescale/Reset", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement ResetTimescaleButton() {
            var icon = EditorGUIUtility.IconContent("Refresh").image as Texture2D;
            var content = new MainToolbarContent(icon, "Reset Timescale");
            var button = new MainToolbarButton(content, () => {
                Time.timeScale = 1f;
                MainToolbar.Refresh("Timescale/Slider");
            });

            MainToolbarElementStyler.StyleElement<EditorToolbarButton>("Timescale/Reset",
                element => {
                    element.SetPadding(0f);
                    element.SetMargin(0f);
                    element.SetFixedWidth(20f);

                    var image = element.Q<Image>();
                    image?.SetSize(14f);
                });

            return button;
        }
    }
}