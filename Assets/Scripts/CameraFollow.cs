using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform RabitTransform;

    private Vector2 _offset;
    void Awake()
    {
        _offset = new Vector2(transform.position.x - RabitTransform.position.x,
            transform.position.y - RabitTransform.position.y);
    }

    void Update()
    {
        transform.position = new Vector3(
            RabitTransform.position.x - _offset.x, 
            RabitTransform.position.y - _offset.y, 
            transform.position.z);
    }
  
}
