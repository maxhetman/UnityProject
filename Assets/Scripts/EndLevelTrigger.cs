using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<RabbitController>() != null)
        {
            LevelController.Instance.EndLevel(true);
        }
    }
}
