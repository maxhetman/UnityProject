using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Collectable
{

    public CrystalsUIController.CrystalType CrystalKind;

    protected override void OnRabitHit(RabbitController rabit)
    {
        LevelController.Instance.PickCrystal(CrystalKind);
        CollectedHide();
    }

}
