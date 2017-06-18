using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevelController : MonoBehaviour
{
    public static ChooseLevelController Instance;

    private Vector3 _startPosition;
    void Awake()
    {
        Instance = this;
        _startPosition = RabbitController.Instance.transform.position;
    }

    public void ResetRabbit()
    {
        RabbitController.Instance.transform.position = _startPosition;
    }
}
