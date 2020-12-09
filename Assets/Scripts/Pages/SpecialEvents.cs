using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialEvents : Page
{
    [SerializeField]
    private Button backButton = default;
    [SerializeField]
    private Button soundSettingsButton = default;
    [SerializeField]
    private Text coinText = default;
    [SerializeField]
    private Text diamondsText = default;

    private new void Awake()
    {
        base.Awake();
        backButton.onClick.AddListener(Close);
        soundSettingsButton.onClick.AddListener(OpenSoundSettings);
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(Close);
        soundSettingsButton.onClick.RemoveListener(OpenSoundSettings);
    }

    public override void Open()
    {
        base.Open();
        coinText.text = Purse.Coins + "";
        diamondsText.text = Purse.Diamonds + "";
    }

    private void OpenSoundSettings()
    {
        SoundSettingsPage.Open();
    }
}
