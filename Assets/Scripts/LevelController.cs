using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

    public static LevelController Instance;
    public Transform StartingTransform;
    public Action<int> OnCoinsAmountChanged;
    public Action<int> FruitCollectedAmountChanged;
    public Action<CrystalsUIController.CrystalType> OnCrystalPicked;
    public Action OnLifeLost;
    public int MaxFruitAmount;
    private int _coinsAmount;
    private int _fruitAmount;

    void Awake()
    {
        Debug.Log("AWAKE");
        Instance = this;
    }
    
    public void OnRabitDeath(RabbitController rabit)
    {
        rabit.transform.position = StartingTransform.position;
        rabit.CurrentHealth -= 1;
        if (rabit.CurrentHealth <= 0)
        {
            GameOver();
        }
        else
        {
            if (OnLifeLost != null)
            {
                OnLifeLost();
            }
        }

    }

    private void GameOver()
    {
        SceneManager.LoadScene("ChooseLevelScene");
    }

    public void AddCoins(int amount)
    {
        _coinsAmount += amount;
        if (OnCoinsAmountChanged != null)
        {
            OnCoinsAmountChanged(_coinsAmount);
        }
    }

    public void CollectFruit()
    {
        _fruitAmount++;
        if (FruitCollectedAmountChanged != null)
        {
            FruitCollectedAmountChanged(_fruitAmount);
        }
    }

    public void PickCrystal(CrystalsUIController.CrystalType type)
    {
        if (OnCrystalPicked != null)
        {
            OnCrystalPicked(type);
        }
    }

}
