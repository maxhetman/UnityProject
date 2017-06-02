using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrcAttackTrigger : MonoBehaviour
{

    [SerializeField] private GreenOrcController _greenOrcScript;

    public bool RabbitClose;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<RabbitController>() != null)
        {

            if (collider.transform.position.y > transform.position.y + 0.4f)
            {
                _greenOrcScript.Die();
            }
            else
            {
                _greenOrcScript.AttackRabbit();
                RabbitClose = true;
            }
        }

    }

    void OnTriggerExit2D()
    {
        RabbitClose = false;
    }
}
