using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTRGames.HugoLuLuLu
{
    public class InsectFight : MonoBehaviour
    {
        [SerializeField]
        private Animator inspectFightAnim;
        public static Animator inspectFightAnimStatic;

        [SerializeField]
        private List<AudioSource> inspectFightsSOs;
        public static List<AudioSource> inspectFightsSOsStatic;

        public static int computerInsectIndex;
        public static int playerInsectIndex;

        public static bool isBeginFightAnimPlayed;

        [SerializeField]
        private Animator beginFightAnim;

        [SerializeField]
        private AudioSource hugoSO, beginFightSO;

        private void Start()
        {
            inspectFightAnimStatic = inspectFightAnim;
            inspectFightsSOsStatic = inspectFightsSOs;

            if (isBeginFightAnimPlayed)
            {
                hugoSO.enabled = false;
                beginFightSO.enabled = false;

                PlayActiveFightAnimation();
                GetActiveFightSO().Play();
            }

            else
            {
                beginFightAnim.Play("BeginFight");
            }
        }

        public static void PlayActiveFightAnimation()
        {
            inspectFightAnimStatic.Play(computerInsectIndex + "-" + playerInsectIndex);
        }

        public static AudioSource GetActiveFightSO()
        {
            for (int i = 0; i < inspectFightsSOsStatic.Count; i++)
            {
                var compIndex = Convert.ToInt32(inspectFightsSOsStatic[i].name.Split('-')[0]);
                var playIndex = Convert.ToInt32(inspectFightsSOsStatic[i].name.Split('-')[1]);

                if ((compIndex == computerInsectIndex || compIndex == playerInsectIndex) && (playIndex == playerInsectIndex || playIndex == computerInsectIndex))
                {
                    inspectFightsSOsStatic[i].enabled = true;

                    return inspectFightsSOsStatic[i];
                }
            }

            return null;
        }
    }
}
