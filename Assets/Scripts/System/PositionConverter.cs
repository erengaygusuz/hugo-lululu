using UnityEngine;

namespace FTRGames.HugoLuLuLu.System
{
    public static class PositionConverter
    {
        public static float ConvertedX(float x)
        {
            return (Screen.width * x) / 1920;
        }
    }
}
