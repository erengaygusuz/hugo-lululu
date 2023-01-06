using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu.Scenes
{
    public class HugoResult : MonoBehaviour
    {
        [SerializeField]
        private Animator mainSpriteAnim;

        [SerializeField]
        private List<AudioSource> goodResultSOs, badResultSOs;

        private void Start()
        {
            CalculateResultAndShowAnim();
        }

        private void CalculateResultAndShowAnim()
        {
            if (ScoreCalculation.totalScore >= 5)
            {
                mainSpriteAnim.Play("good-result");

                for (int i = 0; i < goodResultSOs.Count; i++)
                {
                    goodResultSOs[i].Play();
                }
            }

            else
            {
                mainSpriteAnim.Play("bad-result");

                for (int i = 0; i < badResultSOs.Count; i++)
                {
                    badResultSOs[i].Play();
                }
            }
        }

        private void MakeDefaultStaticVariables()
        {
            InsectComparison.leafAnimStatic = null;
            InsectComparison.activeFightIndex = -1;
            InsectComparison.fightInfos.Clear();
            InsectComparison.isFernandoSoundPlayed = false;

            InsectFight.insectFightAnimStatic = null;
            InsectFight.insectFightsSOsStatic = null;
            InsectFight.computerInsectIndex = 0;
            InsectFight.playerInsectIndex = 0;
            InsectFight.isBeginFightAnimPlayed = false;

            ScoreCalculation.scoreNumberAnimOrder = 0;
            ScoreCalculation.scoreList.Clear();
            ScoreCalculation.totalScore = 0;
            ScoreCalculation.numbersSOsStatic = null;
            ScoreCalculation.totalScoreSOStatic = null;

            SeeingInsect.computerInsectOrderList.Clear();

            ThrowingInsect.isNumber1BtnClicked = false;
            ThrowingInsect.isNumber2BtnClicked = false;
            ThrowingInsect.isNumber3BtnClicked = false;
            ThrowingInsect.isNumber4BtnClicked = false;
            ThrowingInsect.isNumber5BtnClicked = false;
            ThrowingInsect.activeInsectOrder = 1;
            ThrowingInsect.playerInsectOrderList.Clear();
        }

        public void PlayAgainBtnClick()
        {
            MakeDefaultStaticVariables();

            SceneManager.LoadScene("1-Intro");
        }

        public void MainMenuBtnClick()
        {
            MakeDefaultStaticVariables();

            SceneManager.LoadScene("0-MainMenu");
        }

        public void QuitBtnClick()
        {
            Application.Quit();
        }
    }
}