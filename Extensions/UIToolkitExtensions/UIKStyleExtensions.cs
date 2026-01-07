using System;
using UnityEngine.UIElements;

namespace Utilitas {
    public static class UIKStyleExtensions {
        public static T WithMargin<T>(
            this T element,
            params StyleLength[] margins
        ) where T : VisualElement {
            element.SetMargin(margins);
            return element;
        }

        public static void SetMargin<T>(
            this T element,
            params StyleLength[] margins
        ) where T : VisualElement {
            switch (margins.Length) {
                case 1:
                    element.style.marginTop = margins[0];
                    element.style.marginRight = margins[0];
                    element.style.marginBottom = margins[0];
                    element.style.marginLeft = margins[0];
                    break;
                case 2:
                    element.style.marginTop = margins[0];
                    element.style.marginRight = margins[1];
                    element.style.marginBottom = margins[0];
                    element.style.marginLeft = margins[1];
                    break;
                case 4:
                    element.style.marginTop = margins[0];
                    element.style.marginRight = margins[1];
                    element.style.marginBottom = margins[2];
                    element.style.marginLeft = margins[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(margins),
                        $"Margins must be provided in group of : 1, 2 or 4. Here: {margins.Length}"
                    );
            }
        }

        public static T WithPadding<T>(
            this T element,
            params StyleLength[] paddings
        ) where T : VisualElement {
            element.SetPadding(paddings);
            return element;
        }

        public static void SetPadding<T>(
            this T element,
            params StyleLength[] paddings
        ) where T : VisualElement {
            switch (paddings.Length) {
                case 1:
                    element.style.paddingTop = paddings[0];
                    element.style.paddingRight = paddings[0];
                    element.style.paddingBottom = paddings[0];
                    element.style.paddingLeft = paddings[0];
                    break;
                case 2:
                    element.style.paddingTop = paddings[0];
                    element.style.paddingRight = paddings[1];
                    element.style.paddingBottom = paddings[0];
                    element.style.paddingLeft = paddings[1];
                    break;
                case 4:
                    element.style.paddingTop = paddings[0];
                    element.style.paddingRight = paddings[1];
                    element.style.paddingBottom = paddings[2];
                    element.style.paddingLeft = paddings[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(paddings),
                        $"Paddings must be provided in group of : 1, 2 or 4. Here: {paddings.Length}"
                    );
            }
        }

        public static T WithBorders<T>(
            this T element,
            StyleFloat width,
            StyleColor color,
            params StyleLength[] radius
        ) where T : VisualElement {
            return element
                .WithBorders(width, color)
                .WithBorderRadius(radius);
        }

        public static T WithBorders<T>(
            this T element,
            StyleFloat width,
            StyleColor color
        ) where T : VisualElement {
            return element
                .WithBorderWidth(width)
                .WithBorderColor(color);
        }

        public static T WithBorderWidth<T>(
            this T element,
            StyleFloat width
        ) where T : VisualElement {
            element.SetBorderWidth(width);
            return element;
        }

        public static void SetBorderWidth<T>(this T element, StyleFloat width) where T : VisualElement {
            element.style.borderTopWidth = width;
            element.style.borderRightWidth = width;
            element.style.borderBottomWidth = width;
            element.style.borderLeftWidth = width;
        }

        public static T WithBorderColor<T>(
            this T element,
            StyleColor color
        ) where T : VisualElement {
            element.SetBorderColor(color);
            return element;
        }

        public static void SetBorderColor<T>(
            this T element,
            StyleColor color
        ) where T : VisualElement {
            element.style.borderTopColor = color;
            element.style.borderRightColor = color;
            element.style.borderBottomColor = color;
            element.style.borderLeftColor = color;
        }

        public static T WithBorderRadius<T>(
            this T element,
            params StyleLength[] radius
        ) where T : VisualElement {
            element.SetBorderRadius(radius);
            return element;
        }

        public static void SetBorderRadius<T>(
            this T element,
            params StyleLength[] radius
        ) where T : VisualElement {
            switch (radius.Length) {
                case 1:
                    element.style.borderTopLeftRadius = radius[0];
                    element.style.borderTopRightRadius = radius[0];
                    element.style.borderBottomRightRadius = radius[0];
                    element.style.borderBottomLeftRadius = radius[0];
                    break;
                case 2:
                    element.style.borderTopLeftRadius = radius[0];
                    element.style.borderTopRightRadius = radius[0];
                    element.style.borderBottomRightRadius = radius[1];
                    element.style.borderBottomLeftRadius = radius[1];
                    break;
                case 4:
                    element.style.borderTopLeftRadius = radius[0];
                    element.style.borderTopRightRadius = radius[1];
                    element.style.borderBottomRightRadius = radius[2];
                    element.style.borderBottomLeftRadius = radius[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(radius),
                        $"Paddings must be provided in group of : 1, 2 or 4. Here: {radius.Length}"
                    );
            }
        }

        public static T WithWidth<T>(
            this T element,
            StyleLength width
        ) where T : VisualElement {
            element.style.width = width;
            return element;
        }

        public static T WithFlexGrow<T>(
            this T element,
            StyleFloat flexGrow
        ) where T : VisualElement {
            element.style.flexGrow = flexGrow;
            return element;
        }

        public static T Centered<T>(this T element) where T : VisualElement {
            return element
                .FlexAlignedTo(Align.Center)
                .JustifiedTo(Justify.Center);
        }

        public static T FlexAlignedTo<T>(
            this T element,
            Align align
        ) where T : VisualElement {
            element.style.alignItems = align;
            return element;
        }

        public static T JustifiedTo<T>(
            this T element,
            Justify justify
        ) where T : VisualElement {
            element.style.justifyContent = justify;
            return element;
        }

        public static void Center<T>(this T element) where T : VisualElement {
            element.style.alignItems = Align.Center;
            element.style.justifyContent = Justify.Center;
        }

        public static void SetFixedWidth<T>(this T element, StyleLength width) where T : VisualElement {
            element.style.minWidth = width;
            element.style.maxWidth = width;
        }

        public static void SetSize<T>(this T element, StyleLength size) where T : VisualElement {
            element.SetSize(size, size);
        }
        
        public static void SetSize<T>(this T element, StyleLength width, StyleLength height) where T : VisualElement {
            element.style.width = width;
            element.style.height = height;
        }
    }
}