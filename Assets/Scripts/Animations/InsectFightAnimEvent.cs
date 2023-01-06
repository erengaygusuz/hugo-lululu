using FTRGames.HugoLuLuLu.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu.Animations
{
    public class InsectFightAnimEvent : MonoBehaviour
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

        public void OpenInsectComparisonScene()
        {
            if (InsectComparison.activeFightIndex < 4)
            {
                SceneManager.LoadScene("4-Insect-Comparison");
            }

            else
            {
                SceneManager.LoadScene("6-Score-Calculation");
            }
        }
    }
}
