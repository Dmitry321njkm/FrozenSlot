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
    private const int WILD_ID = 0;
    private const int MIN_COUNT = 3;

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
    private List<List<Cell>> cellsBig = new List<List<Cell>>();
    private List<List<Cell>> cells = new List<List<Cell>>();

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

    private int freeSpin
    {
        get
        {
            return LevelsState.GetFreeSpin(levelId);
        }
        set
        {
            freeSpinImage.fillAmount = (float)freeSpin / (float)LevelsState.MAX_FREE_SPIN;
            freeSpinText.text = freeSpin + "/" + LevelsState.MAX_FREE_SPIN;
        }
    }

    [SerializeField]
    private Text freeSpinText = default;
    [SerializeField]
    private Image freeSpinImage = default;

    [SerializeField]
    private TypeCell[] typeCells = default;
    [SerializeField]
    private Line[] lines = default;

    [SerializeField]
    private RectTransform UpPosition = default;
    [SerializeField]
    private RectTransform DownPosition = default;

    [SerializeField]
    private Button levelMenuButton = default;
    [SerializeField]
    private Button soundSettingsButton = default;
    [SerializeField]
    private Button specialEventsButton = default;
    [SerializeField]
    private Button dailyBonusButton = default;
    [SerializeField]
    private Button achivementsButton = default;

    [SerializeField]
    private LevelMenu levelMenu = default;
    [SerializeField]
    private Achivement achivement = default;
    [SerializeField]
    private Page infoPanel = default;

    private new void Awake()
    {
        base.Awake();
        LevelPages[levelId] = this;
        bet = 0;
        freeSpin = freeSpin;
        coins = Purse.Coins;
        diamonds = Purse.Diamonds;
        levelMenuButton.onClick.AddListener(OpenLevelMenu);
        soundSettingsButton.onClick.AddListener(OpenSoundSettings);
        specialEventsButton.onClick.AddListener(OpenSpecialEvents);
        dailyBonusButton.onClick.AddListener(OpenDailyBonus);
        achivementsButton.onClick.AddListener(OpenAchivement);
        getLowerBetButton.onClick.AddListener(GetLowerBet);
        getUpperBetButton.onClick.AddListener(GetUpperBet);
        getMaxBetButton.onClick.AddListener(GetMaxBet);
        spinButton.onClick.AddListener(Spin);
        for (var i = 0; i < columns.Length; i++)
        {
            cellsBig.Add(new List<Cell>());
            cellsBig[i].AddRange(columns[i].GetComponentsInChildren<Cell>());
        }
        Cell.UpPosition = UpPosition.position.y;
        Cell.DownPosition = DownPosition.position.y;
    }

    private void OpenLevelMenu()
    {
        if (infoPanel.GetComponent<CanvasGroup>().alpha == 0)
        {
            levelMenu.Open();
        }
        else
        {
            infoPanel.Close();
        }
    }

    private void OpenSoundSettings()
    {
        SoundSettingsPage.Open();
    }

    private void OpenSpecialEvents()
    {
        //не свертано
    }

    private void OpenDailyBonus()
    {
        //не сверстано
    }

    private void OpenAchivement()
    {
        achivement.Open();
    }

    private void Spin()
    {
        if (IsSpinning())
        {
            return;
        }
        if (freeSpin > 0)
        {
            bet = MAX_BET;
            LevelsState.RemoveFreeSpin(levelId);
            freeSpin = freeSpin;
            StartCoroutine(SpinCoroutine());
        }
        else if (coins >= bet)
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
        if (IsSpinning())
        {
            return;
        }
        FillCells();
        winText.text = CheckLines() + "";
        Purse.AddMoney(CheckLines());
        coins += CheckLines();
    }

    private void FillCells()
    {
        cells.Clear();
        for (var i = 0; i < 5; i++)
        {
            cells.Add(new List<Cell>());
        }
        for (var i = 1; i < 4; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                cells[j].Add(cellsBig[j][i]);
            }
        }
    }

    private int CheckLines()
    {
        int win = 0;
        foreach (var typeCell in typeCells)
        {
            foreach(var line in lines)
            {
                int counter = 0;
                foreach (var point in line.Points)
                {
                    if ((cells[(int)point.x][(int)point.y].TypeCell.Id == typeCell.Id) ||
                        (cells[(int)point.x][(int)point.y].TypeCell.Id == WILD_ID))
                    {
                        counter++;
                    }
                }
                if (counter >= MIN_COUNT)
                {
                    win += (int)((float)typeCell.GetScore(counter) * .005f * (float)bet);
                    StartCoroutine(line.Show());
                }
            }
        }
        return win;
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
        foreach (var cell in cellsBig)
        {
            yield return new WaitForSeconds(SPIN_DELAY);
            foreach (var c in cell)
            {
                c.Move();
            }
        }
    }
}
