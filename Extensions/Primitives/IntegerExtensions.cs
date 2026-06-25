using System;

namespace Utilitas {
    public static class IntegerExtensions {
        public static float PercentageOf(this int part, int whole) {
            return part.RatioOf(whole) * 100f;
        }

        public static float RatioOf(this int part, int whole) {
            if (whole == 0) return 0;
            return (float)part / whole;
        }

        public static float ToFloat(this int value) => Convert.ToSingle(value);
        public static bool IsOdd(this int value) => value % 2 == 1;
        public static bool IsEven(this int value) => value % 2 == 0;

        public static Guid ToGuid(this int value) {
            var bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}