﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialEvent4 : SpecialEvents
{
    private int specialEventCounter = default;

    public override void Open()
    {
        base.Open();
        specialEventCounter = CheckEvents();
        for (var i = 0; i < points.Length; i++)
        {
            Lock(i);
        }
        if (specialEventCounter > 0)
        {
            Unlock(specialEventCounter - 1);
        }
    }

    private int CheckEvents()
    {
        int counter = 0;
        if (SpecialEventsStore.GetDidTenFreeSpins(levelId) >= 10)
        {
            counter++;
            if (SpecialEventsStore.GetCollectedDiamonds(levelId) >= 500)
            {
                counter++;
                if (SpecialEventsStore.NextLevelIsOpen(levelId))
                {
                    counter++;
                }
            }
        }
        return counter;
    }
}
