using FTRGames.HugoLuLuLu.System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FTRGames.HugoLuLuLu.Scenes
{
    public class ScoreCalculation : MonoBehaviour
    {
        [SerializeField]
        private Animator scoreNumber1Anim;

        [SerializeField]
        private List<GameObject> insectWinOrEqualFront, insectWinOrEqualBack;

        [SerializeField]
        private List<GameObject> insectLoseFront, insectLoseBack;

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

        public List<ReferenceInsect> referenceInsectsWinOrEqualFront = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsWinOrEqualBack = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsLoseFront = new List<ReferenceInsect>();
        public List<ReferenceInsect> referenceInsectsLoseBack = new List<ReferenceInsect>();

        private void Start()
        {
            Initialization();

            CalculateScore();

            AssignTotalScoreValue();

            FillInsectsWinOrEqualFrontPosListWithReferenceValues();

            FillInsectsWinOrEqualBackPosListWithReferenceValues();

            FillInsectsLoseFrontPosListWithReferenceValues();

            FillInsectsLoseBackPosListWithReferenceValues();

            ActivateInsectsGameObjectAccordingToScoreValues();

            PlayScore1Anim();
        }

        private void Initialization()
        {
            NumbersSoundObjectInit();
            TotalScoreSoundObjectInit();
            XPosInsectWinOrEqualFrontInit();
            XPosInsectWinOrEqualBackInit();
            XPosInsectLoseFrontInit();
            XPosInsectLoseBackInit();
        }

        private void NumbersSoundObjectInit()
        {
            numbersSOsStatic = numbersSOs;
        }

        private void TotalScoreSoundObjectInit()
        {
            totalScoreSOStatic = totalScoreSO;
        }

        private void XPosInsectWinOrEqualFrontInit()
        {
            xPosInsectWinOrEqualFront = new List<List<float>>();
        }

        private void XPosInsectWinOrEqualBackInit()
        {
            xPosInsectWinOrEqualBack = new List<List<float>>();
        }

        private void XPosInsectLoseFrontInit()
        {
            xPosInsectLoseFront = new List<List<float>>();
        }

        private void XPosInsectLoseBackInit()
        {
            xPosInsectLoseBack = new List<List<float>>();
        }

        private void AssignTotalScoreValue()
        {
            totalScore = GetTotalScore();
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
    
        private void FillInsectsWinOrEqualFrontPosListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsectsWinOrEqualFront.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsWinOrEqualFront[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsWinOrEqualFront[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectWinOrEqualFront.Add(tempList);
            }
        }

        private void FillInsectsWinOrEqualBackPosListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsectsWinOrEqualBack.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsWinOrEqualBack[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsWinOrEqualBack[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectWinOrEqualBack.Add(tempList);
            }
        }

        private void FillInsectsLoseFrontPosListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsectsLoseFront.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsLoseFront[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsLoseFront[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectLoseFront.Add(tempList);
            }
        }

        private void FillInsectsLoseBackPosListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsectsLoseBack.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsectsLoseBack[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsectsLoseBack[i].Insects[j].transform.localPosition.x);
                }

                xPosInsectLoseBack.Add(tempList);
            }
        }

        private void ActivateInsectsGameObjectAccordingToScoreValues()
        {
            for (int i = 0; i < scoreList.Count; i++)
            {
                if (scoreList[i].EarnedPoint == 0) // lose
                {
                    insectWinOrEqualBack[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;
                    insectLoseFront[scoreList[i].LooserIndex].GetComponent<Renderer>().enabled = true;

                    insectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(PositionConverter.ConvertedX(xPosInsectWinOrEqualBack[scoreList[i].WinnerIndex][i]), insectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition.y);
                    insectLoseFront[scoreList[i].LooserIndex].transform.localPosition = new Vector2(PositionConverter.ConvertedX(xPosInsectLoseFront[scoreList[i].LooserIndex][i]), insectLoseFront[scoreList[i].LooserIndex].transform.localPosition.y);
                }

                else if (scoreList[i].EarnedPoint == 2) // winner
                {
                    insectLoseBack[scoreList[i].LooserIndex].GetComponent<Renderer>().enabled = true;
                    insectWinOrEqualFront[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;

                    insectLoseBack[scoreList[i].LooserIndex].transform.localPosition = new Vector2(PositionConverter.ConvertedX(xPosInsectLoseBack[scoreList[i].LooserIndex][i]), insectLoseBack[scoreList[i].LooserIndex].transform.localPosition.y);
                    insectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(PositionConverter.ConvertedX(xPosInsectWinOrEqualFront[scoreList[i].WinnerIndex][i]), insectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition.y);
                }

                else // equal
                {
                    insectWinOrEqualBack[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;
                    insectWinOrEqualFront[scoreList[i].WinnerIndex].GetComponent<Renderer>().enabled = true;

                    insectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(PositionConverter.ConvertedX(xPosInsectWinOrEqualBack[scoreList[i].WinnerIndex][i]), insectWinOrEqualBack[scoreList[i].WinnerIndex].transform.localPosition.y);
                    insectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition = new Vector2(PositionConverter.ConvertedX(xPosInsectWinOrEqualFront[scoreList[i].WinnerIndex][i]), insectWinOrEqualFront[scoreList[i].WinnerIndex].transform.localPosition.y);
                }
            }
        }

        private void PlayScore1Anim()
        {
            scoreNumber1Anim.Play("1-" + scoreList[0].EarnedPoint);
        }
    }

    public class ScoreInfo
    {
        public int EarnedPoint { get; set; }
        public int WinnerIndex { get; set; }
        public int LooserIndex { get; set; }
    }
}
