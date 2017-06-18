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
            SceneManager.LoadScene(LevelName);
        }
    }
}
