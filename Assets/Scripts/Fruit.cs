using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Collectable {

    protected override void OnRabitHit(RabbitController rabit)
    {
        LevelController.Instance.CollectFruit();
        CollectedHide();
    }
}
