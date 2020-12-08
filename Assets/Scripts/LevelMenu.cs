using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : Page
{
    [SerializeField]
    private Button backButton = default;
    [SerializeField]
    private Button mapButton = default;
    [SerializeField]
    private Button infoButton = default;
    [SerializeField]
    private Page infoPanel = default;
    private Level currentLevel = default;

    private new void Awake()
    {
        base.Awake();
        currentLevel = GetComponentInParent<Level>();
        backButton.onClick.AddListener(Back);
        mapButton.onClick.AddListener(OpenMenu);
        infoButton.onClick.AddListener(OpenInfo);
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(Back);
        mapButton.onClick.RemoveListener(OpenMenu);
        infoButton.onClick.RemoveListener(OpenInfo);
    }

    private void Back()
    {
        Close();
    }

    private void OpenMenu()
    {
        Close();
        currentLevel.Close();
        MenuPage.Open();
    }

    private void OpenInfo()
    {
        Close();
        infoPanel.Open();
    }
}
