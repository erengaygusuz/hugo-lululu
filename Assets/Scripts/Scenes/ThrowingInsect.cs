using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FTRGames.HugoLuLuLu
{
    public class ThrowingInsect : MonoBehaviour
    {
        [SerializeField]
        private Animator antAnim, sumoAnim, mosquitoAnim, snailAnim, nerdAnim;

        [SerializeField]
        private Button number1Btn, number2Btn, number3Btn, number4Btn, number5Btn;

        public static bool isNumber1BtnClicked, isNumber2BtnClicked, isNumber3BtnClicked, isNumber4BtnClicked, isNumber5BtnClicked;

        [SerializeField]
        private List<AudioSource> jeanPaulSOs, knipsSOs;

        public static int activeInsectOrder = 1;

        [SerializeField]
        private List<GameObject> inspects;

        private List<List<float>> xPositions;

        public static List<int> playerInsectOrderList = new List<int>();

        [SerializeField]
        private List<GameObject> playerInsects;

        [Serializable]
        public class ReferenceInsect
        {
            public List<GameObject> ReferenceInspect;
        }

        public List<ReferenceInsect> referenceInspects = new List<ReferenceInsect>();

        private void Start()
        {
            for (int i = 0; i < playerInsects.Count; i++)
            {
                playerInsects[i].transform.localPosition = new Vector2(ConvertedX(playerInsects[i].transform.position.x), playerInsects[i].transform.position.y);
            }

            jeanPaulSOs[0].Play();

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
        }

        public void Number1BtnClick()
        {
            inspects[0].transform.position = new Vector2(ConvertedX(xPositions[0][activeInsectOrder - 1]), inspects[0].transform.position.y);

            playerInsectOrderList.Add(0);

            number1Btn.interactable = false;

            knipsSOs[activeInsectOrder - 1].Play();

            RunAnimation(snailAnim, "isSnailThrow", activeInsectOrder);

            isNumber1BtnClicked = true;
        }

        public void Number2BtnClick()
        {
            inspects[1].transform.position = new Vector2(ConvertedX(xPositions[1][activeInsectOrder - 1]), inspects[1].transform.position.y);

            playerInsectOrderList.Add(1);

            number2Btn.interactable = false;

            knipsSOs[activeInsectOrder - 1].Play();

            RunAnimation(nerdAnim, "isNerdThrow", activeInsectOrder);

            isNumber2BtnClicked = true;
        }

        public void Number3BtnClick()
        {
            inspects[2].transform.position = new Vector2(ConvertedX(xPositions[2][activeInsectOrder - 1]), inspects[2].transform.position.y);

            playerInsectOrderList.Add(2);

            number3Btn.interactable = false;

            knipsSOs[activeInsectOrder - 1].Play();

            RunAnimation(mosquitoAnim, "isMosquitoThrow", activeInsectOrder);

            isNumber3BtnClicked = true;           
        }

        public void Number4BtnClick()
        {
            inspects[3].transform.position = new Vector2(ConvertedX(xPositions[3][activeInsectOrder - 1]), inspects[3].transform.position.y);

            playerInsectOrderList.Add(3);

            number4Btn.interactable = false;

            knipsSOs[activeInsectOrder - 1].Play();

            RunAnimation(antAnim, "isAntThrow", activeInsectOrder);

            isNumber4BtnClicked = true;
        }

        public void Number5BtnClick()
        {
            inspects[4].transform.position = new Vector2(ConvertedX(xPositions[4][activeInsectOrder - 1]), inspects[4].transform.position.y);

            playerInsectOrderList.Add(4);

            number5Btn.interactable = false;

            knipsSOs[activeInsectOrder - 1].Play();

            RunAnimation(sumoAnim, "isSumoThrow", activeInsectOrder);

            isNumber5BtnClicked = true;
        }

        private void RunAnimation(Animator anim, string animVarName, int index)
        {
            anim.SetBool(animVarName + index.ToString(), true);
        }

        private float ConvertedX(float x)
        {
            return (Screen.width * x) / 1920;
        }
    }
}