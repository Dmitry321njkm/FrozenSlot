using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : Page
{
    private const float STEP_SET_VOLUME = .25f;
    private const string VOLUME = "Volume";

    [SerializeField]
    private Button closeButton = default;

    [SerializeField]
    private Button soundMinusButton = default;
    [SerializeField]
    private Button soundPlusButton = default;
    [SerializeField]
    private Image[] soundPanel = default;
    [SerializeField]
    private AudioSource backgroundMusic = default;
    [SerializeField]
    private AudioSource sounds = default;

    [SerializeField]
    private Sprite onSprite = default;
    [SerializeField]
    private Sprite offSprite = default;

    private float volume
    {
        get
        {
            if (!PlayerPrefs.HasKey(VOLUME))
            {
                volume = 1;
            }
            return PlayerPrefs.GetFloat(VOLUME);
        }
        set
        {
            PlayerPrefs.SetFloat(VOLUME, value);
        }
    }

    private new void Awake()
    {
        base.Awake();
        SoundSettingsPage = this;

        closeButton.onClick.AddListener(Close);
        soundMinusButton.onClick.AddListener(RemoveVolume);
        soundPlusButton.onClick.AddListener(AddVolume);
        SetSounds(volume);
    }

    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(Close);
        soundMinusButton.onClick.RemoveListener(RemoveVolume);
        soundPlusButton.onClick.RemoveListener(AddVolume);
    }

    private void SetSounds(float _volume)
    {
        volume = _volume;
        backgroundMusic.volume = volume;
        sounds.volume = volume;
        foreach (var soundImage in soundPanel)
        {
            soundImage.sprite = offSprite;
        }
        for (var i = 0; i < (int)(volume * (float)soundPanel.Length); i++)
        {
            soundPanel[i].sprite = onSprite;
        }
    }

    private void AddVolume()
    {
        if (volume + STEP_SET_VOLUME <= 1)
        {
            SetSounds(volume + STEP_SET_VOLUME);
        }
    }

    private void RemoveVolume()
    {
        if (volume - STEP_SET_VOLUME >= 0)
        {
            SetSounds(volume - STEP_SET_VOLUME);
        }
    }
}
