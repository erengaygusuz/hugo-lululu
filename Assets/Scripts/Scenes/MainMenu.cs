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

        public void QuitBtnClick()
        {
            Application.Quit();
        }
    }
}
