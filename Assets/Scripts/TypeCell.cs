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

    [SerializeField]
    private int id = default;
    [SerializeField]
    private Sprite sprite = default;
    [SerializeField]
    private CellValue[] cellValues = default;

    public Sprite GetSprite()
    {
        return sprite;
    }
}
