using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : Page
{
    private const int MIN_BET = 50;
    private const int MAX_BET = 3000;
    private const int BET_STEP = 50;
    private const float SPIN_DELAY = .35f;

    [SerializeField]
    private int levelId = default;

    [SerializeField]
    private Text coinText = default;
    [SerializeField]
    private Text diamondText = default;

    [SerializeField]
    private RectTransform[] columns = default;
    private List<List<Cell>> cells = new List<List<Cell>>();

    [HideInInspector]
    public int cellCounter = 0;

    [SerializeField]
    private Text winText = default;
    [SerializeField]
    private Text betText = default;
    [SerializeField]
    private Button getLowerRateButton = default;
    [SerializeField]
    private Button getUpperRateButton = default;

    [SerializeField]
    private Button maxBetButton = default;
    [SerializeField]
    private Button spinButton = default;

    [SerializeField]
    private Sprite[] cellImages = default;

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
        if (cellCounter == 0)
        {
            StartCoroutine(SpinCoroutine());
        }
    }

    public Cell.CellSprite GetRandomCellSprite()
    {
        int rand = Random.Range(0, cellImages.Length);
        return new Cell.CellSprite(rand, cellImages[rand]);
    }

    public void EndSpin()
    {
        if (cellCounter != 0)
        {
            return;
        }
        for (var i = 0; i < cells.Count; i++)
        {
            string str = "";
            for (var j = 0; j < cells[i].Count; j++)
            {
                str += cells[i][j].GetName() + " ";
            }
            Debug.Log(str);
        }
    }

    private void AddMoney(int coins, int diamonds)
    {
        Purse.AddMoney(coins, diamonds);
        coinText.text = Purse.Coins + "";
        diamondText.text = Purse.Diamonds + "";
    }

    private void RemoveMoney(int coins, int diamonds)
    {
        if (Purse.RemoveMoney(coins, diamonds))
        {
            coinText.text = Purse.Coins + "";
            diamondText.text = Purse.Diamonds + "";
        }
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
