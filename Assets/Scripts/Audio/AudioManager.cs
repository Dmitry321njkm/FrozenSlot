using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _audioManager;

    [SerializeField] private AudioClip _dailyEvents;

    [SerializeField] private AudioClip _bigWin;

    [SerializeField] private AudioClip _line;

    [SerializeField] private AudioClip _moneyBalanceAndCristal;

    [SerializeField] private AudioClip _scrollingSlots;

    [SerializeField] private AudioClip _scatterWild;


    //[SerializeField] private 

    private void Start()
    {
        _audioManager = GetComponent<AudioSource>();
    }

    public void DaylyEventsSound()
    {
        _audioManager.clip = _dailyEvents;
        _audioManager.Play();
    }

    public void BigWinSound()
    {
        _audioManager.clip = _bigWin;
        _audioManager.Play();
    }

    public void LineSound()
    {
        _audioManager.clip = _line;
        _audioManager.Play();
    }

    public void MoneySound()
    {
        _audioManager.clip = _moneyBalanceAndCristal;
        _audioManager.Play();
    }

    public void ScrolingSlotSound()
    {
        _audioManager.clip = _scrollingSlots;
        _audioManager.Play();
    }

    public void ScatterWildSound()
    {
        _audioManager.clip = _scatterWild;
        _audioManager.Play();
    }


}
