﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialEventUI : MonoBehaviour
{
    [SerializeField]
    private Button specialEventButton = default;
    [SerializeField]
    private Text specialEventText = default;
    [SerializeField]
    private SpecialEvents SpecialEvent = default;

    private int hour = 0;
    private int minute = 0;

    private void Awake()
    {
        specialEventButton.onClick.AddListener(OpenSpecialEvent);
        hour = LevelsState.GetRestOfTime(Page.CurrentLevelId).Days * 24 + LevelsState.GetRestOfTime(Page.CurrentLevelId).Hours;
        minute = LevelsState.GetRestOfTime(Page.CurrentLevelId).Minutes;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        for (; ; )
        {
            specialEventText.text = hour + "h " + minute + "m";
            minute--;
            if (minute < 0)
            {
                hour--;
                minute = 59;
            }
            if ((hour < 0) && (minute < 0))
            {
                gameObject.SetActive(false);
                specialEventText.gameObject.SetActive(false);
            }
            yield return new WaitForSeconds(60);
        }
    }

    private void OpenSpecialEvent()
    {
        SpecialEvent.Open();
    }
}
