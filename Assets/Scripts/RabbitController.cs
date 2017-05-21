using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

    public float Speed = 2.0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isGrounded = false;
    private bool _jumpActive = false;
    private float _jumpTime = 0f;



    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
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

        if (Mathf.Abs(xSpeed) > 0)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }

        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }
        //Намалювати лінію (для розробника)
        Debug.DrawLine(from, to, Color.red);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            this._jumpActive = true;
        }
        if (this._jumpActive)
        {
            //Якщо кнопку ще тримають
            if (Input.GetButton("Jump"))
            {
                this._jumpTime += Time.deltaTime;
                if (this._jumpTime < this.MaxJumpTime)
                {
                    Vector2 vel = _rigidBody.velocity;
                    vel.y = JumpSpeed * (1.0f - _jumpTime / MaxJumpTime);
                    _rigidBody.velocity = vel;
                }
            }
            else
            {
                this._jumpActive = false;
                this._jumpTime = 0;
            }
        }

        if (this._isGrounded)
        {
            _animator.SetBool("Jump", false);
        }
        else
        {
            _animator.SetBool("Jump", true);
        }
    }
}
