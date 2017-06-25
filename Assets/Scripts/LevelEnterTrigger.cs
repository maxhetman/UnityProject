using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnterTrigger : MonoBehaviour
{

    public string LevelName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<RabbitController>() != null)
        {
            if (LevelName == "Level2" && GameData.IsSecondLevelOpened() == false)
                return;
            SceneManager.LoadScene(LevelName);
        }
    }
}
