using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelCoins : MonoBehaviour {


    [SerializeField] UILabel CoinsLabel;

    void Start()
    {
        CoinsLabel.text = GameData.TotalCoins.ToString("0000");
    }


}
