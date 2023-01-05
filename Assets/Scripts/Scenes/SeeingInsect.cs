using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace FTRGames.HugoLuLuLu
{
    public class SeeingInsect : MonoBehaviour
    {
        [SerializeField]
        private Animator frontAnimator;

        [SerializeField]
        private List<AudioSource> ambienceSOs;

        [SerializeField]
        private List<GameObject> inspects;

        private List<List<float>> xPositions;

        private List<int> usedOrderList = new List<int>();

        public static List<int> computerInsectOrderList = new List<int>();

        [Serializable]
        public class ReferenceInsect
        {
            public List<GameObject> ReferenceInspect;
        }

        public List<ReferenceInsect> referenceInspects = new List<ReferenceInsect>();

        private void Start()
        {
            xPositions = new List<List<float>>();

            for (int i = 0; i < referenceInspects.Count; i++)
            {
                List<float> tempList = new List<float>();

                for (int j = 0; j < referenceInspects[i].ReferenceInspect.Count; j++)
                {
                    tempList.Add(referenceInspects[i].ReferenceInspect[j].transform.localPosition.x);
                }

                xPositions.Add(tempList);
            }

            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);
            computerInsectOrderList.Add(0);

            for (int i = 0; i < inspects.Count; i++)
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

                float selectedPos = ConvertedX(xPositions[i][selectedIndex]);

                computerInsectOrderList[selectedIndex] = inspects[i].transform.GetSiblingIndex();

                inspects[i].transform.localPosition = new Vector2(selectedPos, inspects[i].transform.localPosition.y);
            }
        }

        private void Update()
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

        private float ConvertedX(float x)
        {
            return (Screen.width * x) / 1920;
        }
    }
}
