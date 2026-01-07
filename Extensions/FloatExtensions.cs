using UnityEngine;

namespace Utilitas {
    public static class FloatExtensions {
        public static int ToInt(this float value) => Mathf.RoundToInt(value);

        public static float Normalized(this float value, float min, float max) {
            if (Mathf.Approximately(max, min)) {
                return 0;
            }
            return Mathf.Clamp((value - min) / (max - min), 0, 1);
        }
    }
}