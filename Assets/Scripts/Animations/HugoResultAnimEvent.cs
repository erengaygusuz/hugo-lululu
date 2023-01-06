using UnityEngine;

namespace FTRGames.HugoLuLuLu.Animations
{
    public class HugoResultAnimEvent : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;

        public void ActivateGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
