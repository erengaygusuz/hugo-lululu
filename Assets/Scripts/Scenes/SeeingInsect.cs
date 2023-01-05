using FTRGames.HugoLuLuLu.System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace FTRGames.HugoLuLuLu.Scenes
{
    public class SeeingInsect : MonoBehaviour
    {
        [SerializeField]
        private Animator frontAnimator;

        [SerializeField]
        private List<AudioSource> ambienceSOs;

        [SerializeField]
        private List<GameObject> insects;

        private List<List<float>> xPositions;

        private List<int> usedOrderList = new List<int>();

        public static List<int> computerInsectOrderList = new List<int>();

        public List<ReferenceInsect> referenceInsects = new List<ReferenceInsect>();

        private void Start()
        {
            Initialization();

            FillingXpositionListWithReferenceValues();

            AssigningPositionValuesToInsectRandomly();
        }        

        private void Update()
        {
            CheckingLeafAnimationAndLoadingNextScene();
        }

        private void Initialization()
        {
            xPositions = new List<List<float>>();

            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
        }

        private void FillingXpositionListWithReferenceValues()
        {
            for (int i = 0; i < referenceInsects.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInsects[i].Insects.Count; j++)
                {
                    tempList.Add(referenceInsects[i].Insects[j].transform.localPosition.x);
                }

                xPositions.Add(tempList);
            }
        }

        private void AssigningPositionValuesToInsectRandomly()
        {
            for (int i = 0; i < insects.Count; i++)
            {
                int selectedIndex = Random.Range(0, xPositions[i].Count);

                if (usedOrderList.Count != 0)
                {
                    while (usedOrderList.Contains(selectedIndex))
                    {
                        selectedIndex = Random.Range(0, xPositions[i].Count);
                    }
                }

                usedOrderList.Add(selectedIndex);

                float selectedPos = PositionConverter.ConvertedX(xPositions[i][selectedIndex]);

                computerInsectOrderList[selectedIndex] = insects[i].transform.GetSiblingIndex();

                insects[i].transform.localPosition = new Vector2(selectedPos, insects[i].transform.localPosition.y);
            }
        }

        private void CheckingLeafAnimationAndLoadingNextScene()
        {
            if (frontAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !frontAnimator.IsInTransition(0))
            {
                for (int i = 0; i < ambienceSOs.Count; i++)
                {
                    if (ambienceSOs[i].isPlaying)
                    {
                        ambienceSOs[i].Stop();
                    }
                }

                SceneManager.LoadScene("3-Throwing-Insect");
            }
        }
    }
}
