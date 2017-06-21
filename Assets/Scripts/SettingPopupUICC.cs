using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopupUICC : MonoBehaviour {

    public static SettingPopupUICC Instance;

    public GameObject Root;

    public void TogglePause()
    {
        if (Root.activeSelf)
        {
            Root.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            Root.SetActive(true);
            Time.timeScale = 0f;
        }
    }

}
