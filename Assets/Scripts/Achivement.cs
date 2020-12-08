using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achivement : Page
{
    [SerializeField]
    private Button backButton = default;

    private new void Awake()
    {
        base.Awake();
        backButton.onClick.AddListener(Back);
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(Back);
    }

    public override void Open()
    {
        base.Open();
        Achivements.SetOpenAchivementsCounter();
    }

    private void Back()
    {
        Close();
    }
}
