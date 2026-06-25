using System;
using UnityEngine;

namespace Utilitas {
    public static class GUIDExtensions {
        public static int ToInt(this Guid guid) {
            return BitConverter.ToInt32(guid.ToByteArray(), 0);
        }
    }
}