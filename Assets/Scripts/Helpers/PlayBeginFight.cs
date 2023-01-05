using System.Collections;
using System.Collections.Generic;
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
