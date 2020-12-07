using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private const float MOVING_SPEED = 40f;
    private const int CELL_COUNT = 4;
    private const float CELL_DISTANCE = 260f;

    private RectTransform rectTransform = default;
    private Vector3 startPosition = default;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        startPosition = rectTransform.localPosition;
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

    private IEnumerator MoveCoroutine()
    {
        for (var i = 0; i < 100; i++)
        {
            yield return new WaitForEndOfFrame();
            MoveDown();
            if (GetPosY() < (-500))
            {
                MoveUp();
            }
        }
        for (; (GetPosY() - startPosition.y) > MOVING_SPEED; )
        {
            yield return new WaitForEndOfFrame();
            MoveDown();
        }
        yield return new WaitForEndOfFrame();
        rectTransform.localPosition = startPosition;
    }
}
