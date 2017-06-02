using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcDeathTrigger : MonoBehaviour
{

    [SerializeField] private AbstractOrcController _orcScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<RabbitController>() != null)
        {
            if (collider.transform.position.y > transform.position.y + 1.6f)
            {
                _orcScript.Die();
            }
        }

    }
}
