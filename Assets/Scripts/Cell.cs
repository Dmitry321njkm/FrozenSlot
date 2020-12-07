using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private const float MOVING_SPEED = 40f;
    private const int CELL_COUNT = 4;
    private const float CELL_DISTANCE = 260f;

    public class CellSprite
    {
        public int id = default;
        public Sprite sprite = default;

        public CellSprite(int _id, Sprite _sprite)
        {
            id = _id;
            sprite = _sprite;
        }
    }

    private Level currentLevel = default;

    private RectTransform rectTransform = default;
    private Vector3 startPosition = default;

    private Image cellImage = default;
    private CellSprite cellSprite = default;

    private void Awake()
    {
        currentLevel = GetComponentInParent<Level>();

        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
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
        rectTransform.localPosition -= new Vector3(0, MOVING_SPEED, 0);
    }

    private void MoveUp()
    {
        rectTransform.localPosition += new Vector3(0, CELL_COUNT * CELL_DISTANCE, 0);
    }

    private float GetPosY()
    {
        return rectTransform.localPosition.y;
    }

    public string GetName()
    {
        return cellImage.sprite.name;
    }

    private IEnumerator MoveCoroutine()
    {
        currentLevel.cellCounter++;
        for (var i = 0; i < 100; i++)
        {
            yield return new WaitForEndOfFrame();
            MoveDown();
            if (GetPosY() < (-500))
            {
                MoveUp();
                SetImage();
            }
        }
        for (; (GetPosY() - startPosition.y) > MOVING_SPEED; )
        {
            yield return new WaitForEndOfFrame();
            MoveDown();
        }
        yield return new WaitForEndOfFrame();
        rectTransform.localPosition = startPosition;
        currentLevel.cellCounter--;
        currentLevel.EndSpin();
    }
}
