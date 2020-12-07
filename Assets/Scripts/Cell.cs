using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private const float MOVING_SPEED = 1f;

    private RectTransform rectTransform = default;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void MoveDown()
    {
        rectTransform.localPosition -= new Vector3(0, MOVING_SPEED, 0);
    }

    public float GetPosY()
    {
        return rectTransform.localPosition.y;
    }
}
