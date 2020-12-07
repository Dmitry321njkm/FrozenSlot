using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : Page
{
    internal const int MIN_BET = 50;
    internal const int MAX_BET = 3000;
    internal const int BET_STEP = 50;
    internal const float SPIN_DELAY = .35f;


    [SerializeField]
    internal int levelId = default;

    [SerializeField]
    internal Text coinText = default;
    [SerializeField]
    internal Text diamondText = default;

    [SerializeField]
    internal Button spinButton = default;

    [SerializeField]
    internal RectTransform[] columns = default;
    internal List<List<Cell>> cells = new List<List<Cell>>();

    private new void Awake()
    {
        base.Awake();
        LevelPages[levelId] = this;
        spinButton.onClick.AddListener(Spin);
        for (var i = 0; i < columns.Length; i++)
        {
            cells.Add(new List<Cell>());
            cells[i].AddRange(columns[i].GetComponentsInChildren<Cell>());
        }
    }

    private void Spin()
    {
        StartCoroutine(SpinCoroutine());
    }

    private IEnumerator SpinCoroutine()
    {
        foreach (var cell in cells)
        {
            yield return new WaitForSeconds(SPIN_DELAY);
            foreach (var c in cell)
            {
                c.Move();
            }
        }
    }
}
