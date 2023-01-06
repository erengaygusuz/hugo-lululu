using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTRGames.HugoLuLuLu
{
    public class ChangeActivateInsectSprite : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer baseSprite, baseBackSprite;

        public void DeactivateSprites()
        {
            baseSprite.enabled = false;
        }

        public void ActivateSprites()
        {
            baseBackSprite.enabled = true;
        }
    }
}