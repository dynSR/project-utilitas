using System;
using UnityEditor;

namespace Utilitas
{
    public static class SerializedPropertyExtensions
    {
        /// <summary>
        /// Gets the numeric value of a SerializedProperty either as a float or int.
        /// Supports both float and int property types.
        /// </summary>
        /// <param name="property">The SerializedProperty to get the value from.</param>
        /// <returns>The numeric value either as a float or int based on the property type.</returns>
        /// <exception cref="NotSupportedException">Thrown if the property type is neither float nor int.</exception>
        public static float GetNumericValue(this SerializedProperty property)
        {
            if (!property.IsFloat() && !property.IsInt())
            {
                throw new NotSupportedException(
                    $"Property type {property.propertyType} is not numeric"
                );
            }

            return property.IsFloat() ? property.floatValue : property.intValue;
        }

        public static void SetValue<T>(this SerializedProperty property, T value)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    property.intValue = Convert.ToInt32(value);
                    break;

                case SerializedPropertyType.Float:
                    property.floatValue = Convert.ToSingle(value);
                    break;

                case SerializedPropertyType.Boolean:
                    property.boolValue = Convert.ToBoolean(value);
                    break;

                case SerializedPropertyType.String:
                    property.stringValue = value?.ToString();
                    break;

                default:
                    throw new NotSupportedException(
                        $"SerializedPropertyType {property.propertyType} is not supported"
                    );
            }
        }

        public static string GetFloatValueToString(this SerializedProperty property)
        {
            return property.floatValue.ToString("0.##");
        }

        public static bool IsFloat(this SerializedProperty property) =>
            property.IsTypeOf(SerializedPropertyType.Float);

        public static bool IsInt(this SerializedProperty property) =>
            property.IsTypeOf(SerializedPropertyType.Integer);

        public static bool IsTypeOf(this SerializedProperty property, SerializedPropertyType propertyType) =>
            property.propertyType == propertyType;
    }
}