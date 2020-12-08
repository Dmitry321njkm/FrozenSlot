using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private const float MOVING_SPEED = 30f;
    private const int SPINNING_TIME = 300;

    private Level currentLevel = default;

    private RectTransform rectTransform = default;
    private Vector2 startPosition = default;

    private Image cellImage = default;
    private TypeCell typeCell = default;

    public static float UpPosition = default;
    public static float DownPosition = default;

    private void Awake()
    {
        currentLevel = GetComponentInParent<Level>();
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.anchoredPosition;
        cellImage = GetComponentsInChildren<Image>()[1];
        SetImage();
    }

    private void SetImage()
    {
        typeCell = currentLevel.GetRandomTypeCell();
        cellImage.sprite = typeCell.GetSprite();
    }

    public void Move()
    {
        StartCoroutine(MoveCoroutine());
    }

    private void MoveDown()
    {
        rectTransform.anchoredPosition -= new Vector2(0, MOVING_SPEED);
    }

    private void MoveUp()
    {
        rectTransform.position = new Vector3(rectTransform.position.x, UpPosition, 0);
    }

    public float GetPosY()
    {
        return rectTransform.anchoredPosition.y;
    }

    public int GetCellId()
    {
        return 0;
    }

    private IEnumerator MoveCoroutine()
    {
        currentLevel.cellCounter++;
        for (var i = 0; i < SPINNING_TIME; i++)
        {
            yield return new WaitForEndOfFrame();
            MoveDown();
            if (rectTransform.position.y <= DownPosition)
            {
                SetImage();
                MoveUp();
            }
        }
        for (; (GetPosY() - startPosition.y) > MOVING_SPEED; )
        {
            yield return new WaitForEndOfFrame();
            MoveDown();
        }
        yield return new WaitForEndOfFrame();
        rectTransform.anchoredPosition = startPosition;
        currentLevel.cellCounter--;
        currentLevel.EndSpin();
    }
}
