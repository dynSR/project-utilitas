using UnityEngine;

namespace Utilitas {
    public static class Vector3Extensions {
        /// <summary>
        /// Sets any x y z values of a Vector3
        /// </summary>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) {
            return new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Returns a float array containing Vector3's axis value
        /// </summary>
        public static float[] ToArray(this Vector3 vector) => new[] { vector.x, vector.y, vector.z };

        /// <summary>
        /// Returns true if all Vector3 values are positives.
        /// </summary>
        public static bool IsPositive(this Vector3 vector) => vector is { x: > 0f, y: > 0f, z: > 0f };
    }
}