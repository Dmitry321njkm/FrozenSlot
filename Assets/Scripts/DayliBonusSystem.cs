using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayliBonusSystem : MonoBehaviour
{
    [SerializeField]
    private int getBonus = 0;

    private Button getBonusButton;

    [SerializeField]
    private Text lastTimeText;

    private string takeBonus = "TakeBonus";
    private string dataTakeBonus = "DataTakeBonus";
   

    private int currentSecondTime;

   
    private void OnEnable()
    {
        getBonusButton = GetComponent<Button>();

        var currentDate = System.DateTime.Now;

        if (PlayerPrefs.HasKey(takeBonus))
        {
            if (PlayerPrefs.GetInt(dataTakeBonus) == currentDate.Day)
            {
                getBonus = PlayerPrefs.GetInt(takeBonus);
            }

            else
            {
                getBonus = 0;
                PlayerPrefs.SetInt(dataTakeBonus, currentDate.Day);
            }

            if (PlayerPrefs.GetInt(takeBonus) == 1)
            {
                lastTimeText.gameObject.SetActive(true);
            }
        }

        getBonusButton.onClick.AddListener(TakeBonus);
    }

    void TakeBonus()
    {
        if (getBonus != 1)
        {
            lastTimeText.gameObject.SetActive(true);

            getBonus = 1;

            PlayerPrefs.SetInt(takeBonus, getBonus);

            var currentDate = System.DateTime.Now;

            PlayerPrefs.SetInt(dataTakeBonus, currentDate.Day);
        }

    }

    private void Update()
    {

        if (getBonus == 1)
        {
            var time = System.DateTime.Now;
            int minute = time.Minute;
            int hour = time.Hour;

            int lastMinute = 60 - minute;
            int lastHour = 23 - hour;

            string textTimer;

            if (lastMinute > 9)
            {
                textTimer = lastHour + "h " + lastMinute +"m";
                lastTimeText.text = textTimer;
            }

            else
            {
                textTimer = lastHour + "h" + lastMinute + "m";
                lastTimeText.text = textTimer;
            }


            

        }

        
    }
}


