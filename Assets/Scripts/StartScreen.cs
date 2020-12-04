using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : Page
{
    private const float SHOW_NAME_SPEED = .05f;
    private const float DELAY_SCENE_TIME = 1f;

    [SerializeField]
    private CanvasGroup nameImage = default;

    private new void Awake()
    {
        base.Awake();
        StartScreenPage = this;

        Open();
    }

    public override void Open()
    {
        base.Open();
        StartCoroutine(ShowName());
    }

    private IEnumerator ShowName()
    {
        nameImage.alpha = 0;
        for (; nameImage.alpha < 1; )
        {
            yield return new WaitForEndOfFrame();
            nameImage.alpha += SHOW_NAME_SPEED;
        }
        yield return new WaitForSeconds(DELAY_SCENE_TIME);
        OpenMenu();
    }

    private void OpenMenu()
    {
        Close();
        MenuPage.Open();
    }
}
