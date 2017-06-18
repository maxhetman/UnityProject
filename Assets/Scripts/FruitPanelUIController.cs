using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitPanelUIController : MonoBehaviour
{

    [SerializeField] private UILabel FruitLabel;

    void Start()
    {
        LevelController.Instance.FruitCollectedAmountChanged += OnFruitAmountChanged;
        FruitLabel.text =0 + "/" + LevelController.Instance.MaxFruitAmount;
    }

    private void OnFruitAmountChanged(int amount)
    {
        FruitLabel.text = amount + "/" + LevelController.Instance.MaxFruitAmount;
    }
}
