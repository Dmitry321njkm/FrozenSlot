using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    private const float OPEN_CLOSE_SPEED = .05f;

    private CanvasGroup canvasGroup = default;

    public static StartScreen StartScreenPage = default;
    public static Menu MenuPage = default;
    public static Level[] LevelPages = new Level[6];
    public static SoundSettings SoundSettingsPage = default;

    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Open()
    {
        StartCoroutine(OpenCoroutine());
    }

    public virtual void Close()
    {
        StartCoroutine(CloseCoroutine());
    }

    private IEnumerator OpenCoroutine()
    {
        for (; canvasGroup.alpha < 1; )
        {
            yield return new WaitForFixedUpdate();
            canvasGroup.alpha += OPEN_CLOSE_SPEED;
        }
        canvasGroup.blocksRaycasts = true;
    }

    private IEnumerator CloseCoroutine()
    {
        canvasGroup.blocksRaycasts = false;
        for (; canvasGroup.alpha > 0;)
        {
            yield return new WaitForFixedUpdate();
            canvasGroup.alpha -= OPEN_CLOSE_SPEED;
        }
    }
}
