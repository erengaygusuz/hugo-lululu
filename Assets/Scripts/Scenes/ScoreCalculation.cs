using FTRGames.HugoLuLuLu.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FTRGames.HugoLuLuLu
{
    public class ScoreCalculation : MonoBehaviour
    {
        [SerializeField]
        private Animator scoreNumber1Anim;

        [SerializeField]
        private List<GameObject> inspectWinOrEqualFront, inspectWinOrEqualBack;

        [SerializeField]
        private List<GameObject> inspectLoseFront, inspectLoseBack;

        private List<List<float>> xPosInsectWinOrEqualFront, xPosInsectWinOrEqualBack, xPosInsectLoseFront, xPosInsectLoseBack;

        public static int scoreNumberAnimOrder = 0;

        public static List<ScoreInfo> scoreList = new List<ScoreInfo>();

        public static int totalScore;

        [SerializeField]
        private List<AudioSource> numbersSOs;

        [SerializeField]
        private AudioSource totalScoreSO;

        public static List<AudioSource> numbersSOsStatic;
        public static AudioSource totalScoreSOStatic;

        [Serializable]
        public class ReferenceInsect
        {
            public List<GameObject> Insects;
        }

        public List<ReferenceInsect> referenceInsectsWinOrEqualFront = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsWinOrEqualBack = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsLoseFront = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsLoseBack = new List<ReferenceInsect>();

        private void Start()
        {
            numbersSOsStatic = numbersSOs;
            totalScoreSOStatic = totalScoreSO;

            CalculateScore();

            totalScore = GetTotalScore();

            xPosInsectWinOrEqualFront = new List<List<float>>();

            for (int i = 0; i < referenceInsectsWinOrEqualFront.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsWinOrEqualFront[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsWinOrEqualFront[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectWinOrEqualFront.Add(tempList);
            }

            xPosInsectWinOrEqualBack = new List<List<float>>();

            for (int i = 0; i < referenceInsectsWinOrEqualBack.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsWinOrEqualBack[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsWinOrEqualBack[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectWinOrEqualBack.Add(tempList);
            }

            xPosInsectLoseFront = new List<List<float>>();

            for (int i = 0; i < referenceInsectsLoseFront.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsLoseFront[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsLoseFront[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectLoseFront.Add(tempList);
            }

            xPosInsectLoseBack = new List<List<float>>();

            for (int i = 0; i < referenceInsectsLoseBack.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsLoseBack[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsLoseBack[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectLoseBack.Add(tempList);
            }

            for (int i = 0; i < scoreList.Count; i++)
            {
                if (scoreList[i].EarnedPoint == 0) // lose
                {
                    inspectWinOrEqualBack[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;
                    inspectLoseFront[scoreList[i].LooserIndex].GetComponent<Renderer>().enabled = true;

                    inspectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(ConvertedX(xPosInsectWinOrEqualBack[scoreList[i].WinnerIndex][i]), inspectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition.y);
                    inspectLoseFront[scoreList[i].LooserIndex].transform.localPosition = new Vector2(ConvertedX(xPosInsectLoseFront[scoreList[i].LooserIndex][i]), inspectLoseFront[scoreList[i].LooserIndex].transform.localPosition.y);
                }

                else if (scoreList[i].EarnedPoint == 2) // winner
                {
                    inspectLoseBack[scoreList[i].LooserIndex].GetComponent<Renderer>().enabled = true;
                    inspectWinOrEqualFront[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;

                    inspectLoseBack[scoreList[i].LooserIndex].transform.localPosition = new Vector2(ConvertedX(xPosInsectLoseBack[scoreList[i].LooserIndex][i]), inspectLoseBack[scoreList[i].LooserIndex].transform.localPosition.y);
                    inspectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(ConvertedX(xPosInsectWinOrEqualFront[scoreList[i].WinnerIndex][i]), inspectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition.y);
                }

                else // equal
                {
                    inspectWinOrEqualBack[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;
                    inspectWinOrEqualFront[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;

                    inspectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(ConvertedX(xPosInsectWinOrEqualBack[scoreList[i].WinnerIndex][i]), inspectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition.y);
                    inspectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(ConvertedX(xPosInsectWinOrEqualFront[scoreList[i].WinnerIndex][i]), inspectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition.y);
                }
            }

            scoreNumber1Anim.Play("1-" + scoreList[0].EarnedPoint);
        }

        private void CalculateScore()
        {
            for (int i = 0; i < 5; i++)
            {
                string fightType = (SeeingInsect.computerInsectOrderList[i] + "-" + ThrowingInsect.playerInsectOrderList[i]);

                var fightInfo = InsectComparison.fightInfos.Where(x => x.Type == fightType).FirstOrDefault();

                if (fightInfo != null)
                {
                    int winner = fightInfo.Winner;

                    if (winner == ThrowingInsect.playerInsectOrderList[i])
                    {
                        scoreList.Add(new ScoreInfo
                        {
                            EarnedPoint = 2,
                            WinnerIndex = ThrowingInsect.playerInsectOrderList[i],
                            LooserIndex = SeeingInsect.computerInsectOrderList[i]
                        });
                    }

                    else
                    {
                        scoreList.Add(new ScoreInfo
                        {
                            EarnedPoint = 0,
                            WinnerIndex = SeeingInsect.computerInsectOrderList[i],
                            LooserIndex = ThrowingInsect.playerInsectOrderList[i]
                        });
                    }
                }

                else
                {
                    scoreList.Add(new ScoreInfo
                    {
                        EarnedPoint = 1,
                        WinnerIndex = SeeingInsect.computerInsectOrderList[i],
                        LooserIndex = ThrowingInsect.playerInsectOrderList[i]
                    });
                }
            }
        }

        private int GetTotalScore()
        {
            int total = 0;

            for (int i = 0; i < scoreList.Count; i++)
            {
                total += scoreList[i].EarnedPoint;
            }

            return total;
        }

        private float ConvertedX(float x)
        {
            return (Screen.width * x) / 1920;
        }
    }

    public class ScoreInfo
    {
        public int EarnedPoint { get; set; }
        public int WinnerIndex { get; set; }
        public int LooserIndex { get; set; }
    }
}
