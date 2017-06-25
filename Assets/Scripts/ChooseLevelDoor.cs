using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelDoor: MonoBehaviour
{

    public string LevelName;


    public GameObject CompletedCheckmark;
    public SpriteRenderer CrystalsPlaceholder;
    public SpriteRenderer FruitPlaceholder;
    public GameObject Lock;

    public Sprite FruitSprite;
    public Sprite CrystalSprite;

    private LevelData _levelData;
    void Awake()
    {
        _levelData = GameData.GetLevelData(LevelName);
        if (_levelData == null)
        {
            _levelData = new LevelData();
        }
    }

    void Start()
    {
        InitDoorUI();
    }

    private void InitDoorUI()
    {
        if (_levelData.HasSuccessfullyFinished)
        {
            CompletedCheckmark.SetActive(true);
        }

        if (_levelData.HasAllCrystals)
        {
            CrystalsPlaceholder.sprite = CrystalSprite;
        }

        if (_levelData.HasAllFruits)
        {
            FruitPlaceholder.sprite = FruitSprite;
        }

        if (LevelName == "Level2" && GameData.IsSecondLevelOpened() == false)
        {
            Lock.SetActive(true);
        }


    }
}
