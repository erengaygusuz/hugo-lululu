using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu
{
    public class StartInsectFight : MonoBehaviour
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
