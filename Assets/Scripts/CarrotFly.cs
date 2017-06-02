using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CarrotFly : Collectable
{

    [SerializeField] private float _speed = 5.0f;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
    }

    public void Launch(float direction)
    {
        if (direction < 0)
        {
            _speed = -_speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    protected override void OnRabitHit(RabbitController rabit)
    {
        rabit.Die();
        CollectedHide();
    }

}
