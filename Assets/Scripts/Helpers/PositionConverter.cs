using UnityEngine;

namespace FTRGames.HugoLuLuLu.Helpers
{
    public static class PositionConverter
    {
        public static float ConvertedX(float x)
        {
#if UNITY_ANDROID
            return (Screen.width * x) / 1920;
#endif

#if UNITY_WEBGL
            return x;
#endif

#if UNITY_EDITOR
            return (Screen.width * x) / 1920;
#endif
        }

        public static float ConvertedY(float y)
        {
#if UNITY_ANDROID
            return (Screen.height * y) / 1080;
#endif

#if UNITY_WEBGL
            return y;
#endif

#if UNITY_EDITOR
            return (Screen.height * y) / 1080;
#endif

        }
    }
}
