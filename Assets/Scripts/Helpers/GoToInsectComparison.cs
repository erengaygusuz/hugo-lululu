using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu
{
    public class GoToInsectComparison : MonoBehaviour
    {
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
