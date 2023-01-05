using System;
using System.Collections.Generic;
using UnityEngine;

namespace FTRGames.HugoLuLuLu.Scenes
{
    public class InsectFight : MonoBehaviour
    {
        [SerializeField]
        private Animator insectFightAnim;
        public static Animator insectFightAnimStatic;

        [SerializeField]
        private List<AudioSource> insectFightsSOs;
        public static List<AudioSource> insectFightsSOsStatic;

        public static int computerInsectIndex;
        public static int playerInsectIndex;

        public static bool isBeginFightAnimPlayed;

        [SerializeField]
        private Animator beginFightAnim;

        [SerializeField]
        private AudioSource hugoSO, beginFightSO;

        private void Start()
        {
            Initialization();

            CheckBeginFightAnim();
        }

        private void Initialization()
        {
            InsectFightAnimInit();
            InsectFightSOsInit();
        }

        private void InsectFightAnimInit()
        {
            insectFightAnimStatic = insectFightAnim;
        }

        private void InsectFightSOsInit()
        {
            insectFightsSOsStatic = insectFightsSOs;
        }

        private void CheckBeginFightAnim()
        {
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
            insectFightAnimStatic.Play(computerInsectIndex + "-" + playerInsectIndex);
        }

        public static AudioSource GetActiveFightSO()
        {
            for (int i = 0; i < insectFightsSOsStatic.Count; i++)
            {
                var compIndex = Convert.ToInt32(insectFightsSOsStatic[i].name.Split('-')[0]);
                var playIndex = Convert.ToInt32(insectFightsSOsStatic[i].name.Split('-')[1]);

                if ((compIndex == computerInsectIndex || compIndex == playerInsectIndex) && (playIndex == playerInsectIndex || playIndex == computerInsectIndex))
                {
                    insectFightsSOsStatic[i].enabled = true;

                    return insectFightsSOsStatic[i];
                }
            }

            return null;
        }
    }
}
