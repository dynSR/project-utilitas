using UnityEngine;

namespace Utilitas {
    public static class Vector2Extensions {
        /// <summary>
        /// Sets any x y values of a Vector2
        /// </summary>
        public static Vector2 With(this Vector2 vector2, float? x = null, float? y = null) {
            return new Vector2(x ?? vector2.x, y ?? vector2.y);
        }
    }
}