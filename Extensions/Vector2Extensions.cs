using UnityEngine;

namespace Utilitas {
    public static class Vector2Extensions {
        /// <summary>
        /// Sets any x y values of a Vector2
        /// </summary>
        public static Vector2 With(this Vector2 vector, float? x = null, float? y = null) {
            return new Vector2(x ?? vector.x, y ?? vector.y);
        }

        /// <summary>
        /// Returns a float array containing Vector2's axis value
        /// </summary>
        public static float[] ToArray(this Vector2 vector) => new[] { vector.x, vector.y };

        /// <summary>
        /// Returns true if all Vector2 values are positives.
        /// </summary>
        public static bool IsPositive(this Vector2 vector) => vector is { x: > 0f, y: > 0f };
    }
}