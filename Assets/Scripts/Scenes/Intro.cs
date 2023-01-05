using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu
{
    public class Intro : MonoBehaviour
    {
        [SerializeField]
        private AudioSource fernandoSO;

        [SerializeField]
        private AudioSource hugoSO;

        [SerializeField]
        private List<AudioSource> ambienceSOs;

        private bool isHugoASEnabled;

        private void Update()
        {
            if (!fernandoSO.isPlaying)
            {
                if (!isHugoASEnabled)
                {
                    hugoSO.enabled = true;

                    isHugoASEnabled = true;
                }
            }

            if (isHugoASEnabled && !hugoSO.isPlaying)
            {
                for (int i = 0; i < ambienceSOs.Count; i++)
                {
                    if (ambienceSOs[i].isPlaying)
                    {
                        ambienceSOs[i].Stop();
                    }
                }

                SceneManager.LoadScene("2-Seeing-Insect");
            }
        }
    }
}