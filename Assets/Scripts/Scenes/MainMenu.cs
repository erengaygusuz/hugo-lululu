using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayBtnClick()
        {
            SceneManager.LoadScene("1-Intro");
        }

        public void SettingsBtnClick()
        {

        }

        public void QuitBtnClick()
        {
            Application.Quit();
        }
    }
}
