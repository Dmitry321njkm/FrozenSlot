using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : Page
{
    [SerializeField]
    private Button closeButton = default;

    private new void Awake()
    {
        base.Awake();
        SoundSettingsPage = this;

        closeButton.onClick.AddListener(Close);
    }

    private void OnDestroy()
    {
        closeButton.onClick.RemoveListener(Close);
    }
}
