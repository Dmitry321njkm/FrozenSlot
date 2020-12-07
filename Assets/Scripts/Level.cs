using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : Page
{
    internal const int MIN_BET = 50;
    internal const int MAX_BET = 3000;
    internal const int BET_STEP = 50;


    [SerializeField]
    internal int levelId = default;

    [SerializeField]
    internal Text coinText = default;
    [SerializeField]
    internal Text diamondText = default;

    [SerializeField]
    internal Button spinButton = default;

    [SerializeField]
    internal RectTransform column = default;
    internal Cell[] cells = default;

    private new void Awake()
    {
        base.Awake();
        LevelPages[levelId] = this;
        spinButton.onClick.AddListener(Spin);
        cells = column.GetComponentsInChildren<Cell>();
    }

    private void Spin()
    {
        StartCoroutine(MoveCell());
    }

    private IEnumerator MoveCell ()
    {
        for (var i = 0; ; i++)
        {
            yield return new WaitForEndOfFrame();
            for (var j = 0; j < cells.Length; j++)
            {
                cells[j].MoveDown();
            }
        }
    }

    private void GetMinPosCell()
    {
        for (var i = 0; i < cells.Length; i++)
        {

        }
    }
}
