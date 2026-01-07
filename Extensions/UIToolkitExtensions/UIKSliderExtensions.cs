using UnityEngine;
using UnityEngine.UIElements;

namespace Utilitas {
    public static class UIKSliderExtensions {
        public static void Init(this Slider slider, float min, float max, float initialValue) {
            Set(slider, initialValue);
            SetMinMax(slider, min, max);
        }

        public static void Set(this Slider slider, float value) {
            slider.value = value;
        }

        public static void SetMinMax(this Slider slider, float min, float max) {
            slider.lowValue = min;
            slider.highValue = max;
        }

        public static string GetFloatValueToString(this Slider slider) {
            return slider.value.ToString("0.##");
        }
    }
}