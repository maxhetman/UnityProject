using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    private int _totalCoins;

    
    public static int TotalCoins
    {
        get { return PlayerPrefs.GetInt("total_coins", 0); }
    }

    public static void AddCoins(int amount)
    {
        int totalCoins = TotalCoins + amount;
        PlayerPrefs.SetInt("total_coins", totalCoins);
    }

    public static LevelData GetLevelData(string LevelName)
    {
        string str =  PlayerPrefs.GetString("level_stat_" + LevelName, null);
        LevelData result =JsonUtility.FromJson<LevelData>(str);
        return result;
    }

    public static void SetLevelData(string LevelName, LevelData data)
    {
        string str = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("level_stat_" + LevelName, str);
    }

    public static bool IsSecondLevelOpened()
    {
        return PlayerPrefs.GetInt("second_level_open", 0) == 1;
    }

    public static void SetSecondLevelOpen(bool state)
    {
        PlayerPrefs.SetInt("second_level_open", state ? 1 : 0);
    }
}
