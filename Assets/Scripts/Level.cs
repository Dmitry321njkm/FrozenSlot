using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : Page
{
    [SerializeField]
    private int levelId = default;

    private new void Awake()
    {
        base.Awake();
        LevelPages[levelId] = this;
    }
}
