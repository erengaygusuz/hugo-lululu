using FTRGames.HugoLuLuLu.Scenes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FTRGames.HugoLuLuLu.Animations
{
    public class ThrowingInsectAnimEvent : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer baseSprite, baseBackSprite;

        [SerializeField]
        private Animator backAnim;

        [SerializeField]
        private List<AudioSource> jeanPaulSOs;

        public void DeactivateSprites()
        {
            baseSprite.enabled = false;
        }

        public void ActivateSprites()
        {
            baseBackSprite.enabled = true;
        }

        public void LoadNextScene()
        {
            backAnim.SetInteger("activeInsectOrder", ThrowingInsect.activeInsectOrder);

            if (ThrowingInsect.activeInsectOrder != 5)
            {
                ThrowingInsect.activeInsectOrder++;

                jeanPaulSOs[ThrowingInsect.activeInsectOrder - 1].Play();
            }

            if (ThrowingInsect.isNumber1BtnClicked == true &&
                ThrowingInsect.isNumber2BtnClicked == true &&
                ThrowingInsect.isNumber3BtnClicked == true &&
                ThrowingInsect.isNumber4BtnClicked == true &&
                ThrowingInsect.isNumber5BtnClicked == true)
            {
                InsectComparison.isFernandoSoundPlayed = true;

                SceneManager.LoadScene("4-Insect-Comparison");
            }
        }
    }
}