using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Collectable {

    protected override void OnRabitHit(RabbitController rabit)
    {
        rabit.RabbitGrow();
        CollectedHide();
    }
}
