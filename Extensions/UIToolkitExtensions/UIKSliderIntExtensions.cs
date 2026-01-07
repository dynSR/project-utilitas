using UnityEngine.UIElements;

namespace Utilitas {
    public static class UIKSliderIntExtensions {
        public static void Init(this SliderInt slider, int min, int max, int initialValue) {
            Set(slider, initialValue);
            SetMinMax(slider, min, max);
        }

        public static void Set(this SliderInt slider, int value) {
            slider.value = value;
        }

        public static void SetMinMax(this SliderInt slider, int min, int max) {
            slider.lowValue = min;
            slider.highValue = max;
        }
    }
}