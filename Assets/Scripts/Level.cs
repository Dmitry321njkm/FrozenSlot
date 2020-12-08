using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : Page
{
    private const int MIN_BET = 50;
    private const int MAX_BET = 3000;
    private const int BET_STEP = 50;
    private const float SPIN_DELAY = .2f;

    [SerializeField]
    private int levelId = default;

    [SerializeField]
    private Text coinText = default;
    protected int _coins;
    private int coins
    {
        get
        {
            return _coins;
        }
        set
        {
            _coins = value;
            coinText.text = _coins + "";
        }
    }

    [SerializeField]
    private Text diamondText = default;
    protected int _diamonds;
    private int diamonds
    {
        get
        {
            return _diamonds;
        }
        set
        {
            _diamonds = value;
            diamondText.text = _diamonds + "";
        }
    }

    [SerializeField]
    private RectTransform[] columns = default;
    private List<List<Cell>> cells = new List<List<Cell>>();
    private List<List<int>> cellIds = new List<List<int>>();

    [HideInInspector]
    public int cellCounter = 0;

    protected int _bet = 0;
    private int bet
    {
        get
        {
            return _bet;
        }
        set
        {
            _bet = value;
            if (_bet < MIN_BET)
            {
                _bet = MIN_BET;
            }
            if (_bet > MAX_BET)
            {
                _bet = MAX_BET;
            }
            betText.text = _bet + "";
        }
    }

    [SerializeField]
    private Text winText = default;
    [SerializeField]
    private Text betText = default;
    [SerializeField]
    private Button getLowerBetButton = default;
    [SerializeField]
    private Button getUpperBetButton = default;

    [SerializeField]
    private Button getMaxBetButton = default;
    [SerializeField]
    private Button spinButton = default;

    [SerializeField]
    private TypeCell[] typeCells = default;

    [SerializeField]
    private RectTransform UpPosition = default;
    [SerializeField]
    private RectTransform DownPosition = default;

    private new void Awake()
    {
        base.Awake();
        LevelPages[levelId] = this;
        bet = 0;
        coins = Purse.Coins;
        diamonds = Purse.Diamonds;
        getLowerBetButton.onClick.AddListener(GetLowerBet);
        getUpperBetButton.onClick.AddListener(GetUpperBet);
        getMaxBetButton.onClick.AddListener(GetMaxBet);
        spinButton.onClick.AddListener(Spin);
        for (var i = 0; i < columns.Length; i++)
        {
            cells.Add(new List<Cell>());
            cells[i].AddRange(columns[i].GetComponentsInChildren<Cell>());
        }
        Cell.UpPosition = UpPosition.position.y;
        Cell.DownPosition = DownPosition.position.y;
    }

    private void Spin()
    {
        if ((!IsSpinning()) && (coins >= bet))
        {
            coins -= bet;
            Purse.RemoveMoney(bet, 0);
            StartCoroutine(SpinCoroutine());
        }
    }

    public TypeCell GetRandomTypeCell()
    {
        return typeCells[Random.Range(0, typeCells.Length)];
    }

    private bool IsSpinning()
    {
        return cellCounter == 0 ? false : true;
    }

    public void EndSpin()
    {
        if (!IsSpinning())
        {
            FillCellIds();
        }
    }

    private void FillCellIds()
    {
        cellIds.Clear();
        for (var i = 0; i < 3; i++)
        {
            cellIds.Add(new List<int>());
        }
        for (var i = 1; i < 4; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                cellIds[i - 1].Add(cells[j][i].GetCellId());
            }
        }
    }

    private void GetLowerBet()
    {
        if (!IsSpinning())
        {
            bet -= BET_STEP;
        }
    }

    private void GetUpperBet()
    {
        if (!IsSpinning())
        {
            bet += BET_STEP;
        }
    }

    private void GetMaxBet()
    {
        if (!IsSpinning())
        {
            bet = MAX_BET;
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
