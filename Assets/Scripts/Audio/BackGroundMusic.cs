using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : Singleton<BackGroundMusic>
{
    [HideInInspector]
    public AudioSource _backGroundMusic;
    
    void Start()
    {
        _backGroundMusic = GetComponent<AudioSource>();
    }

}
