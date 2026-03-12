using System;
using System.Reflection;

namespace Utilitas {
    public static class ReflectionUtilities {
        public static object GetEnumValue(
            string assemblyName,
            string creatorTypeName,
            string enumTypeName,
            int enumValue
        ) {
            Assembly assembly = Assembly.Load(assemblyName);
            if (assembly == null) {
                throw new InvalidOperationException(nameof(assembly));
            }

            Type creatorType = assembly.GetType(creatorTypeName);
            if (creatorType == null) {
                throw new InvalidOperationException(nameof(creatorType));
            }

            Type enumType = creatorType.GetNestedType(
                enumTypeName,
                BindingFlags.NonPublic
            );
            if (enumType == null) {
                throw new InvalidOperationException(nameof(enumType));
            }

            return Enum.IsDefined(enumType, enumValue)
                ? Enum.ToObject(enumType, enumValue)
                : throw new ArgumentOutOfRangeException(
                    nameof(enumValue),
                    $"Specified argument was out of the range of valid values (enumValue: {enumValue} out of {Enum.GetValues(enumType).Length})."
                );
        }

        public static Array GetEnumValues(
            string assemblyName,
            string creatorName,
            string enumName,
            BindingFlags bindingAttr = BindingFlags.NonPublic
        ) {
            Assembly assembly = Assembly.Load(assemblyName);
            if (assembly == null) {
                throw new InvalidOperationException(nameof(assembly));
            }

            Type creatorType = assembly.GetType(creatorName);
            if (creatorType == null) {
                throw new InvalidOperationException(nameof(creatorType));
            }

            Type enumType = creatorType.GetNestedType(enumName, bindingAttr);
            return enumType != null ? Enum.GetValues(enumType) : throw new InvalidOperationException(nameof(enumType));
        }

        public static string[] GetEnumNames(
            string assemblyName,
            string creatorName,
            string enumName,
            BindingFlags bindingAttr = BindingFlags.NonPublic
        ) {
            Assembly assembly = Assembly.Load(assemblyName);
            if (assembly == null) {
                throw new InvalidOperationException(nameof(assembly));
            }

            Type creatorType = assembly.GetType(creatorName);
            if (creatorType == null) {
                throw new InvalidOperationException(nameof(creatorType));
            }

            Type enumType = creatorType.GetNestedType(enumName, bindingAttr);
            return enumType != null ? Enum.GetNames(enumType) : throw new InvalidOperationException(nameof(enumType));
        }
    }
}