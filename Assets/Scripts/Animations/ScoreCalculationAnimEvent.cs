using FTRGames.HugoLuLuLu.Scenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu.Animations
{
    public class ScoreCalculationAnimEvent : MonoBehaviour
    {
        [SerializeField]
        private List<Animator> animators;

        [SerializeField]
        private Animator totalScoreAnim;

        public void PlayAnim()
        {
            if (ScoreCalculation.scoreNumberAnimOrder < 4)
            {
                ScoreCalculation.scoreNumberAnimOrder++;

                animators[ScoreCalculation.scoreNumberAnimOrder].Play((ScoreCalculation.scoreNumberAnimOrder + 1) + "-" + ScoreCalculation.scoreList[ScoreCalculation.scoreNumberAnimOrder].EarnedPoint);

                ScoreCalculation.numbersSOsStatic[ScoreCalculation.scoreNumberAnimOrder].Play();
            }
        }

        public void PlayDisappearAnim()
        {
            for (int i = 0; i < ScoreCalculation.scoreList.Count; i++)
            {
                animators[i].Play("d-"+ (i + 1) + "-" + ScoreCalculation.scoreList[i].EarnedPoint);
            }

            StartCoroutine(PlayTotalScoreAnim());
        }

        private IEnumerator PlayTotalScoreAnim()
        {
            yield return new WaitForSeconds(1.0f);

            totalScoreAnim.Play(ScoreCalculation.totalScore.ToString());

            ScoreCalculation.totalScoreSOStatic.Play();
        }

        public void OpenScene()
        {
            SceneManager.LoadScene("7-Hugo-Result");
        }
    }
}
