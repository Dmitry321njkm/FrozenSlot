using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private const float MOVING_SPEED = 30f;
    private const int SPINNING_TIME = 300;

    public class CellSprite
    {
        internal int id = default;
        internal Sprite sprite = default;

        public CellSprite() { }

        public CellSprite(int _id, Sprite _sprite)
        {
            id = _id;
            sprite = _sprite;
        }
    }

    private Level currentLevel = default;

    private RectTransform rectTransform = default;
    private Vector2 startPosition = default;

    private Image cellImage = default;
    private CellSprite cellSprite = default;

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
        cellSprite = currentLevel.GetRandomCellSprite();
        cellImage.sprite = cellSprite.sprite;
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

    public string GetName()
    {
        return cellImage.sprite.name;
    }

    public int GetCellId()
    {
        return cellSprite.id;
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
            if (rectTransform.position.y <= DownPosition)
            {
                SetImage();
                MoveUp();
            }
        }
        yield return new WaitForEndOfFrame();
        rectTransform.anchoredPosition = startPosition;
        currentLevel.cellCounter--;
        currentLevel.EndSpin();
    }
}
