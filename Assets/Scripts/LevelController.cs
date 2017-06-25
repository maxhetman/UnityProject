using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour, IMusicToggler
{

    public static LevelController Instance;
    public Transform StartingTransform;
    public Action<int> OnCoinsAmountChanged;
    public Action<int> FruitCollectedAmountChanged;
    public Action<CrystalsUIController.CrystalType> OnCrystalPicked;
    public Action OnLifeLost;
    public int MaxFruitAmount;
    public int MaxCrystalAmount;
    private int _coinsAmount;
    private int _fruitCollected;
    public AudioSource bgMusic;
    private LevelData _levelData;
    public GameObject LoseWindow;
    public GameObject WinWindow;
    private List<CrystalsUIController.CrystalType> collectedCrystals = new List<CrystalsUIController.CrystalType>();

    public bool IsLevelFinished { get; set; }
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (SoundManager.isMusicOn())
        {
            SetMusic(true);
        }
        _levelData = GameData.GetLevelData(SceneManager.GetActiveScene().name);
        if (_levelData == null)
        {
            _levelData = new LevelData();
        }
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
        _fruitCollected++;
        if (FruitCollectedAmountChanged != null)
        {
            FruitCollectedAmountChanged(_fruitCollected);
        }
    }

    public void PickCrystal(CrystalsUIController.CrystalType type)
    {
        collectedCrystals.Add(type);
        if (OnCrystalPicked != null)
        {
            OnCrystalPicked(type);
        }
    }

    public void SetMusic(bool state)
    {
        if (state)
        {
            bgMusic.Play();
        }
        else
        {
            bgMusic.Stop();
        }
    }

    public void EndLevel(bool win)
    {

        IsLevelFinished = true;
        if (win)
        {
            LevelWin();
        }
        else
        {
            LevelLose();
        }
    }

    private void LevelWin()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            GameData.SetSecondLevelOpen(true);
        }
        ShowWinWindow();
        SaveStatistics();
    }

    private void LevelLose()
    {
        ShowLoseWindow();
    }

    private void ShowWinWindow()
    {
        WinWindow.SetActive(true);
        WinWindowLinkSaver linkSaver = WinWindow.GetComponent<WinWindowLinkSaver>();
        if (collectedCrystals.Contains(CrystalsUIController.CrystalType.BLUE))
        {
            linkSaver.BlueCrystalPlaceholder.sprite2D = linkSaver.BlueCrystalSprite;
        }
        if (collectedCrystals.Contains(CrystalsUIController.CrystalType.RED))
        {
            linkSaver.RedCrystalPlaceHolder.sprite2D = linkSaver.RedCrystalSprite;
        }
        if (collectedCrystals.Contains(CrystalsUIController.CrystalType.GREEN))
        {
            linkSaver.GreenCrystalPlaceholder.sprite2D = linkSaver.GreenCrystalSprite;
        }
        linkSaver.CoinsLabel.text = "+" + _coinsAmount.ToString();
        linkSaver.FruitLabel.text = _fruitCollected + "/" + MaxFruitAmount;
    }

    private void ShowLoseWindow()
    {
        LoseWindow.SetActive(true);
    }

    private void SaveStatistics()
    {
        GameData.AddCoins(_coinsAmount);
        string levelName = SceneManager.GetActiveScene().name;
        ConfigLevelData();
        GameData.SetLevelData(levelName, _levelData);
    }

    private void ConfigLevelData()
    {
        _levelData.HasAllFruits = _levelData.HasAllFruits || _fruitCollected == MaxFruitAmount;
        _levelData.HasAllCrystals = _levelData.HasAllCrystals || collectedCrystals.Count == MaxCrystalAmount;
        _levelData.HasSuccessfullyFinished = true;
    }
}
