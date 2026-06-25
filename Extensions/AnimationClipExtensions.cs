using UnityEngine;

namespace Utilitas
{
    public static class AnimationClipExtensions
    {
        public static int GetTotalFramesCount(this AnimationClip animationClip) =>
            Mathf.RoundToInt(animationClip.length * animationClip.frameRate);
    }
}