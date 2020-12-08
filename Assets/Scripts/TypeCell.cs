using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TypeCell
{
    [Serializable]
    public class CellValue
    {
        public int count = default;
        public int value = default;
    }

    public int Id = default;
    [SerializeField]
    private Sprite sprite = default;
    [SerializeField]
    private CellValue[] cellValues = default;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public int GetScore(int count)
    {
        int maxCount = 0;
        int value = 0;
        foreach (var cellValue in cellValues)
        {
            if ((count >= cellValue.count) && (maxCount < cellValue.count))
            {
                maxCount = cellValue.count;
                value = cellValue.value;
            }
        }
        return value;
    }
}
