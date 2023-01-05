using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu.Scenes
{
    public class Intro : MonoBehaviour
    {
        [SerializeField]
        private AudioSource fernandoSO;

        [SerializeField]
        private AudioSource hugoSO;

        [SerializeField]
        private List<AudioSource> ambienceSOs;

        private void Update()
        {
            PlayingHugoSoundAfterFernandoSound();

            StopAllAmbienceSoundsAndOpenNextScene();
        }

        private void PlayingHugoSoundAfterFernandoSound()
        {
            if (!fernandoSO.isPlaying)
            {
                if (!hugoSO.enabled)
                {
                    hugoSO.enabled = true;
                }
            }
        }

        private void StopAllAmbienceSoundsAndOpenNextScene()
        {
            if (hugoSO.enabled == true && !hugoSO.isPlaying)
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