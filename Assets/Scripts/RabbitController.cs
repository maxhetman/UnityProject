using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

    public float Speed = 2.0f;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;


    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        float xSpeed = Input.GetAxis("Horizontal");

        if (Mathf.Abs(xSpeed) > 0)
        {
            Vector2 vel = _rigidBody.velocity;
            vel.x = xSpeed * Speed;
            _rigidBody.velocity = vel;
        }

        if (xSpeed < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (xSpeed > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}
