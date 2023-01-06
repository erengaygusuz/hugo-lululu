using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FTRGames.HugoLuLuLu.Core
{
    public class Settings : MonoBehaviour
    {
        [SerializeField]
        private Slider soundSlider;

        [SerializeField]
        private TextMeshProUGUI sliderValueLabel;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            GettingSoundLevelValue();
        }

        private void GettingSoundLevelValue()
        {
            if (PlayerPrefs.HasKey("HugoLuLuLu-SoundLevel"))
            {
                soundSlider.value = PlayerPrefs.GetFloat("HugoLuLuLu-SoundLevel");
            }

            else
            {
                soundSlider.value = AudioListener.volume;
            }

            sliderValueLabel.text = Mathf.RoundToInt(soundSlider.value * 100).ToString();
        }

        public void ChangeAudioLevel(Slider slider)
        {
            AudioListener.volume = slider.value;
            sliderValueLabel.text = Mathf.RoundToInt(slider.value * 100).ToString();

            PlayerPrefs.SetFloat("HugoLuLuLu-SoundLevel", slider.value);
            PlayerPrefs.Save();
        }
    }
}
