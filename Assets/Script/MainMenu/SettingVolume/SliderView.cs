using UnityEngine;
using UnityEngine.UI;

public class SliderView : MonoBehaviour
{
    [Header("Volumn Slider")]
    [SerializeField] private Slider MusicSlider, SFXSlider;

    [Header("Button")]
    [SerializeField] private Button CloseButton;

    [Header("GameObject")]
    [SerializeField] private GameObject VolumeSettingPanel;

    private void Start()
    {
        gameObject.SetActive(false);

        LoadVolume();
        MusicSlider.onValueChanged.AddListener(delegate { MusicVolume();
        });
        SFXSlider.onValueChanged.AddListener(delegate { SFXVolume(); });

        SetupButtonListener();
    }

    public void MusicVolume()
    {
        SoundManager.Instance.MusicVolume(MusicSlider.value);
        float VolumeMusic = MusicSlider.value;
        PlayerPrefs.SetFloat("MusicValue", VolumeMusic);
    }

    public void SFXVolume()
    {
        SoundManager.Instance.SFXVolume(SFXSlider.value);
        float VolumeSFX = SFXSlider.value;
        PlayerPrefs.SetFloat("SFXValue", VolumeSFX);

    }

    public void LoadVolume()
    {
        if (PlayerPrefs.HasKey("MusicValue"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("MusicValue");
        }
        if (PlayerPrefs.HasKey("SFXValue"))
        {
            SFXSlider.value = PlayerPrefs.GetFloat("SFXValue");
        }
    }

    private void SetupButtonListener()
    {
        CloseButton.onClick.AddListener(() =>
        {
            VolumeSettingPanel.SetActive(false);
        });
    }
}
