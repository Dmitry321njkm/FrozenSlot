using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyBonus : Page
{
    private const float TIME_DELAY = 2f;

    [SerializeField]
    private GameObject titleText = default;
    [SerializeField]
    private GameObject[] bonusTexts = default;
    [SerializeField]
    private Button[] bonusButtons = default;
    [SerializeField]
    private GameObject[] bonusImages = default;

    private new void Awake ()
    {
        base.Awake();
        DailyBonusPage = this;
        bonusButtons[0].onClick.AddListener(() => { SetBonus(0); });
        bonusButtons[1].onClick.AddListener(() => { SetBonus(1); });
        bonusButtons[2].onClick.AddListener(() => { SetBonus(2); });
    }

    public override void Open()
    {
        base.Open();
        titleText.SetActive(true);
        for (var i = 0; i < bonusTexts.Length; i++)
        {
            bonusTexts[i].SetActive(false);
            bonusButtons[i].gameObject.SetActive(true);
            bonusButtons[i].interactable = true;
            bonusImages[i].SetActive(false);
        }
        SpecialEventsStore.SetDailyBonusIsGet(CurrentLevelId);
    }

    private void SetBonus(int count)
    {
        StartCoroutine(SetBonusCoroutine(count));
    }

    private IEnumerator SetBonusCoroutine(int count)
    {
        Achivements.SetGetDailyBonusCounter();
        titleText.SetActive(false);
        bonusTexts[count].SetActive(true);
        for (var i = 0; i < bonusTexts.Length; i++)
        {
            bonusButtons[i].interactable = false;
        }
        bonusButtons[count].gameObject.SetActive(false);
        int rand = Random.Range(0, bonusImages.Length);
        bonusImages[rand].SetActive(true);
        bonusImages[rand].transform.position = new Vector3(bonusButtons[count].transform.position.x, 0f, 0f);
        switch (rand)
        {
            case 0:
                Purse.AddMoney(0, 100);
                break;
            case 1:
                Purse.AddMoney(5000);
                break;
            case 2:
                Purse.AddMoney(15000, 100);
                break;
        }
        foreach (var level in LevelPages)
        {
            level.UpdateMoney();
        }
        yield return new WaitForSeconds(TIME_DELAY);
        Close();
    }
}
