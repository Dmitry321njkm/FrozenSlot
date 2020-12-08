using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Line
{
    private const float TIME_SHOWING = 1.5f;

    [SerializeField]
    private Image image = default;
    public Vector2[] Points = default;

    public IEnumerator Show()
    {
        image.enabled = true;
        yield return new WaitForSeconds(TIME_SHOWING);
        image.enabled = false;
    }
}
