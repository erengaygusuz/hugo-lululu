using FTRGames.HugoLuLuLu.Scenes;
using UnityEngine;

namespace FTRGames.HugoLuLuLu
{
    public class PlayBeginFight : MonoBehaviour
    {
        public void PlayFightAnim()
        {
            if (!InsectFight.isBeginFightAnimPlayed)
            {
                InsectFight.isBeginFightAnimPlayed = true;

                InsectFight.PlayActiveFightAnimation();
                InsectFight.GetActiveFightSO().Play();
            }
        }
    }
}
