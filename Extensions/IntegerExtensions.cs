using System;

namespace Utilitas {
    public static class IntegerExtensions {
        public static float ToFloat(this int value) => Convert.ToSingle(value);
    }
}