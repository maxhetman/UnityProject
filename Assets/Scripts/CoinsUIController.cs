using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsUIController : MonoBehaviour
{

    [SerializeField] UILabel CoinsLabel;

    void Start()
    {
        LevelController.Instance.OnCoinsAmountChanged += OnCoinsAmountChanged;
        CoinsLabel.text = "0000";

    }

    private void OnCoinsAmountChanged(int coinsAmount)
    {
        CoinsLabel.text = coinsAmount.ToString("0000");
    }
}
