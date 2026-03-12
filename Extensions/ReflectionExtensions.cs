using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Utilitas {
    public static class ReflectionExtensions {
        private static readonly Dictionary<Type, Dictionary<string, FieldInfo>> fieldInfoCache =
            new();

        public const BindingFlags FIELD_FLAGS = BindingFlags.Public |
                                                BindingFlags.NonPublic |
                                                BindingFlags.Instance |
                                                BindingFlags.Static;

        // public const BindingFlags MAX_BINDING_FLAGS = (BindingFlags)62;

        /// <summary>
        /// Set the value of a field by name, supporting static and instance fields,
        /// public and non-public, and inherited fields.
        /// Throws clear exceptions if the field is missing or value type is incompatible.
        /// </summary>
        public static void SetFieldValue(this object obj, string fieldName, object value) {
            if (obj == null) {
                throw new ArgumentNullException(nameof(obj));
            }

            Type type = obj.GetInspectedType();
            object target = obj.GetTarget();

            FieldInfo fieldInfo = type.GetFieldInfo(fieldName);
            if (fieldInfo == null) {
                throw new MissingFieldException(type.FullName, fieldName);
            }

            if (value != null && !fieldInfo.FieldType.IsAssignableFrom(value.GetType())) {
                throw new ArgumentException(
                    $"Cannot assign value of type {value.GetType()} to field '{fieldName}' of type {fieldInfo.FieldType}"
                );
            }

            fieldInfo.SetValue(target, value);
        }

        // public static object GetPropertyValue(this object obj, string propertyName) {
        //     if (obj == null) {
        //         throw new ArgumentNullException(nameof(obj));
        //     }
        //
        //     Type type = obj.GetInspectedType();
        //     object target = obj.GetTarget();
        //
        //     PropertyInfo property = type.GetProperty(propertyName, FIELD_FLAGS);
        //     if (property == null)
        //         throw new MissingMemberException(type.FullName, propertyName);
        //
        //     // Prevent invalid static/instance access
        //     if (property.GetMethod.IsStatic && target != null) {
        //         throw new InvalidOperationException($"Property '{propertyName}' is static");
        //     }
        //
        //     if (!property.GetMethod.IsStatic && target == null) {
        //         throw new InvalidOperationException($"Property '{propertyName}' is instance-based");
        //     }
        //
        //     // Prevent indexers
        //     if (property.GetIndexParameters().Length > 0) {
        //         throw new NotSupportedException("Indexed properties are not supported");
        //     }
        //
        //     return property.GetValue(target);
        // }

        /// <summary>
        /// Get a FieldInfo by name, including static/private/protected and inherited fields.
        /// Uses a cache for repeated lookups.
        /// </summary>
        public static FieldInfo GetFieldInfo(this Type type, string fieldName) {
            if (type == null) {
                throw new ArgumentNullException(nameof(type));
            }

            if (fieldName.IsNullOrWhiteSpace()) {
                throw new ArgumentNullException(nameof(fieldName));
            }

            if (!fieldInfoCache.TryGetValue(type, out Dictionary<string, FieldInfo> typeCache)) {
                typeCache = new Dictionary<string, FieldInfo>(StringComparer.OrdinalIgnoreCase);
                fieldInfoCache[type] = typeCache;
            }

            if (typeCache.TryGetValue(fieldName, out FieldInfo cachedField)) {
                return cachedField;
            }

            Type currentType = type;
            FieldInfo field = null;
            while (currentType != null) {
                field = currentType.GetField(fieldName, FIELD_FLAGS);
                if (field != null) {
                    break;
                }

                currentType = currentType.BaseType;
            }

            return field;
        }

        private static Type GetInspectedType(this object obj) {
            // Determine the Type to inspect:
            // - if obj is already a Type (for static properties), use it directly
            // - otherwise, get the runtime type of the instance (for instance properties)
            return obj as Type ?? obj.GetType();
        }

        private static object GetTarget(this object obj) {
            // Determine the target for reflection:
            // - for static members, target must be null
            // - for instance members, target is the actual object
            return obj is Type ? null : obj;
        }
    }
}