using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : Collectable {

    protected override void OnRabitHit(RabbitController rabit)
    {
        LevelController.Instance.AddCoins(1);
        CollectedHide();
    }
}
