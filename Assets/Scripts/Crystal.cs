﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable {

    protected override void OnRabitHit(RabbitController rabit)
    {
        //do something
        CollectedHide();
    }
}
