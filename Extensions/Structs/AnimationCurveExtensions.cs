using UnityEngine;

namespace Utilitas {
    public static class AnimationCurveExtensions {
        public static void AddKeys(this AnimationCurve curve, params Keyframe[] keys) {
            foreach (Keyframe key in keys) {
                curve.AddKey(key);
            }
        }

        public static Keyframe? GetKeyByTime(this AnimationCurve curve, float time)
            => curve.FindKey(k => Mathf.Approximately(k.time, time));

        public static Keyframe? GetKeyByValue(this AnimationCurve curve, float value)
            => curve.FindKey(k => Mathf.Approximately(k.value, value));

        private static Keyframe? FindKey(this AnimationCurve curve, System.Func<Keyframe, bool> predicate) {
            foreach (Keyframe key in curve.keys) {
                if (predicate(key)) {
                    return key;
                }
            }

            return null;
        }
    }
}