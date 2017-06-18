using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZoneChooseLevel : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        RabbitController rc = col.GetComponent<RabbitController>();
        if (rc != null)
        {
            ChooseLevelController.Instance.ResetRabbit();
        }
    }
}
