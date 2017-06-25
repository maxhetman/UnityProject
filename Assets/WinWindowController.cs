using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWindowController : MonoBehaviour {

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("ChooseLevelScene");
    }
}
