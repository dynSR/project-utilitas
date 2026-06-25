using UnityEngine;

namespace Utilitas
{
    public static class AnimationClipExtensions
    {
        public static int GetTotalFramesCount(this AnimationClip animationClip) =>
            animationClip == null ? 0 : Mathf.RoundToInt(animationClip.length * animationClip.frameRate);
    }
}