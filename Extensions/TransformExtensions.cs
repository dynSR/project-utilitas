using UnityEngine;
using System.Collections.Generic;

namespace Utilitas {
    public static class TransformExtensions {
        public static void Unparent(this Transform trs, bool debug = false) {
            if (debug) Debug.Log($"Unparent() called on {trs.gameObject.name}");
            trs.SetParent(null);
        }

        public static bool HasChild(this Transform trs) => trs.childCount >= 1;

        /// <summary>
        /// Retrieves all the children of a given Transform.
        /// </summary>
        /// <remarks>
        /// This method can be used with LINQ to perform operations on all child Transforms. For example,
        /// you could use it to find all children with a specific tag, to disable all children, etc.
        /// Transform implements IEnumerable and the GetEnumerator method which returns an IEnumerator of all its children.
        /// </remarks>
        /// <param name="parent">The Transform to retrieve children from.</param>
        /// <returns>An IEnumerable&lt;Transform&gt; containing all the child Transforms of the parent.</returns>    
        public static IEnumerable<Transform> Children(this Transform parent) {
            foreach (Transform child in parent) {
                yield return child;
            }
        }

        /// <summary>
        /// Resets transform's position, scale and rotation
        /// </summary>
        /// <param name="transform">Transform to use</param>
        public static void Reset(this Transform transform) {
            transform.position = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        /// <summary>
        /// Destroys all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The Transform whose child game objects are to be destroyed.</param>
        public static void DestroyChildren(this Transform parent) {
            parent.ForEveryChild(child => Object.Destroy(child.gameObject));
        }

        /// <summary>
        /// Immediately destroys all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The Transform whose child game objects are to be immediately destroyed.</param>
        public static void DestroyChildrenImmediate(this Transform parent) {
            parent.ForEveryChild(child => Object.DestroyImmediate(child.gameObject));
        }

        /// <summary>
        /// Enables all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The Transform whose child game objects are to be enabled.</param>
        public static void EnableChildren(this Transform parent) {
            parent.ForEveryChild(child => child.gameObject.SetActive(true));
        }

        /// <summary>
        /// Disables all child game objects of the given transform.
        /// </summary>
        /// <param name="parent">The Transform whose child game objects are to be disabled.</param>
        public static void DisableChildren(this Transform parent) {
            parent.ForEveryChild(child => child.gameObject.SetActive(false));
        }

        /// <summary>
        /// Executes a specified action for each child of a given transform.
        /// </summary>
        /// <param name="parent">The parent transform.</param>
        /// <param name="action">The action to be performed on each child.</param>
        /// <remarks>
        /// This method iterates over all child transforms in reverse order and executes a given action on them.
        /// The action is a delegate that takes a Transform as parameter.
        /// </remarks>
        public static void ForEveryChild(this Transform parent, System.Action<Transform> action) {
            for (var i = parent.childCount - 1; i >= 0; i--) {
                action(parent.GetChild(i));
            }
        }

        #region Position Setters

        public static void SetPositionX(this Transform transform, float x) {
            transform.position = transform.position.With(x: x);
        }

        public static void SetPositionY(this Transform transform, float y) {
            transform.position = transform.position.With(y: y);
        }

        public static void SetPositionZ(this Transform transform, float z) {
            transform.position = transform.position.With(z: z);
        }

        #endregion

        #region Local Position Setters

        public static void SetLocalPositionX(this Transform transform, float x) {
            transform.localPosition = transform.localPosition.With(x: x);
        }

        public static void SetLocalPositionY(this Transform transform, float y) {
            transform.localPosition = transform.localPosition.With(y: y);
        }

        public static void SetLocalPositionZ(this Transform transform, float z) {
            transform.localPosition = transform.localPosition.With(z: z);
        }

        #endregion

        #region Local Scale Setters

        public static void SetLocalScaleX(this Transform transform, float x) {
            transform.localScale = transform.localScale.With(x: x);
        }

        public static void SetLocalScaleY(this Transform transform, float y) {
            transform.localScale = transform.localScale.With(y: y);
        }

        public static void SetLocalScaleZ(this Transform transform, float z) {
            transform.localScale = transform.localScale.With(z: z);
        }

        #endregion

        #region Local EulerAngles Setters

        public static void SetLocalEulerAnglesX(this Transform transform, float x) {
            transform.localEulerAngles = transform.localEulerAngles.With(x: x);
        }

        public static void SetLocalEulerAnglesY(this Transform transform, float y) {
            transform.localEulerAngles = transform.localEulerAngles.With(y: y);
        }

        public static void SetLocalEulerAnglesZ(this Transform transform, float z) {
            transform.localEulerAngles = transform.localEulerAngles.With(z: z);
        }

        #endregion

        #region EulerAngles Setters

        public static void SetEulerAnglesX(this Transform transform, float x) {
            transform.eulerAngles = transform.eulerAngles.With(x: x);
        }

        public static void SetEulerAnglesY(this Transform transform, float y) {
            transform.eulerAngles = transform.eulerAngles.With(y: y);
        }

        public static void SetEulerAnglesZ(this Transform transform, float z) {
            transform.eulerAngles = transform.eulerAngles.With(z: z);
        }

        #endregion
    }
}