using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementUI : MonoBehaviour
{
    [SerializeField] private AchivementCell _openTheGame;
    [SerializeField] private AchivementCell _freeSpin;
    [SerializeField] private AchivementCell _scatter;
    [SerializeField] private AchivementCell _wild;
    [SerializeField] private AchivementCell _maxBet;
    [SerializeField] private AchivementCell _doSpecialEvents;
    [SerializeField] private AchivementCell _collectDiamond;
    [SerializeField] private AchivementCell _openAllLevel;
    [SerializeField] private AchivementCell _collectMoney;
    [SerializeField] private AchivementCell _getDailyBonus;
    [SerializeField] private AchivementCell _makeLines;
    [SerializeField] private AchivementCell _openAchivement;


    private void OnEnable()
    {
        CheckValueAchivement();
    }

    void CheckValueAchivement()
    {
        OpenTheGameCheck();
        FreeSpeenCheck();
        ScatterCheck();
        WildCheck();
        MaxBetCheck();
        DoSpecialEventsCheck();
        CollectDiamondCheck();
        OpenAllLevelCheck();
        CollectMoneyCheck();
        GetDailyBonusCheck();
        MakeItemsCheck();
        OpenAchivementsCheck();
    }

    void OpenTheGameCheck()
    { 
        AchivementCheck(_openTheGame, Achivements.GetOpenTheGameProcent());
    }

    void FreeSpeenCheck()
    {
        AchivementCheck(_freeSpin, Achivements.GetFreeSpinProcent());
    }

    void ScatterCheck()
    {
        AchivementCheck(_scatter, Achivements.GetScatterProcent());
    }

    void WildCheck()
    {
        AchivementCheck(_wild, Achivements.GetWildProcent());
    }

    void MaxBetCheck()
    {
        AchivementCheck(_maxBet, Achivements.GetCompleteSpecialEventsProcent());
    }

    void DoSpecialEventsCheck()
    {
        AchivementCheck(_doSpecialEvents, Achivements.GetCompleteSpecialEventsProcent());
    }

    void CollectDiamondCheck()
    {
        AchivementCheck(_collectDiamond, Achivements.GetCollectDiamondsProcent());
    }

    void OpenAllLevelCheck()
    {
        AchivementCheck(_openAllLevel, Achivements.GetOpenTheLevelProcent());
    }

    void CollectMoneyCheck()
    {
        AchivementCheck(_collectMoney, Achivements.GetCollectMoneyProcent());
    }

    void GetDailyBonusCheck()
    {
        AchivementCheck(_getDailyBonus, Achivements.GetGetDailyBonusCounterProcent());
    }

    void MakeItemsCheck()
    {
        AchivementCheck(_makeLines, Achivements.GetLinesCounterProcent());
    }

    void OpenAchivementsCheck()
    {
        AchivementCheck(_openAchivement, Achivements.GetOpenAchivementsCounterProcent());
    }

    void AchivementCheck(AchivementCell _cell, float _percent)
    {
        _cell.Percent.text = (_percent * 100).ToString() + "%";
        _cell.ImageProgress.fillAmount = _percent;

    }

   
}


[System.Serializable]
public class AchivementCell
{
    public Image ImageProgress;
    public Text Percent;
}
