using FTRGames.HugoLuLuLu.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu.Animations
{
    public class InsectComparisonAnimEvent : MonoBehaviour
    {
        public void StartFight()
        {
            if (InsectComparison.activeFightIndex < 4)
            {
                if (InsectFight.computerInsectIndex == InsectFight.playerInsectIndex)
                {
                    InsectComparison.PlayLeafAnim();
                }

                else if (InsectFight.computerInsectIndex != InsectFight.playerInsectIndex)
                {
                    SceneManager.LoadScene("5-Insect-Fight");
                }
            }

            else if (InsectComparison.activeFightIndex == 4)
            {
                if (InsectFight.computerInsectIndex == InsectFight.playerInsectIndex)
                {
                    SceneManager.LoadScene("6-Score-Calculation");
                }

                else if (InsectFight.computerInsectIndex != InsectFight.playerInsectIndex)
                {
                    SceneManager.LoadScene("5-Insect-Fight");
                }
            }

            else
            {
                SceneManager.LoadScene("6-Score-Calculation");
            }
        }
    }
}
