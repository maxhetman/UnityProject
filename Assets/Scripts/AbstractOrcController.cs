using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public abstract class AbstractOrcController : MonoBehaviour
{

    [SerializeField] private float _offsetX;
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _runSpeed;

    private Mode mode;
    private Rigidbody2D _rigidBody;
    protected SpriteRenderer _spriteRenderer;
    protected Animator _animator;

    private Vector3 pointA;
    private Vector3 pointB;
    protected Vector3 rabbit_pos;
    protected bool _isAttacking = false;
    protected bool _isDying = false;

    public enum Mode
    {
        GoToA,
        GoToB,
        Attack
    }

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        mode = Mode.GoToB;
    }

    void Start()
    {
        pointA = transform.position;
        pointB = new Vector3(pointA.x + _offsetX, pointA.y, pointA.z);
    }

    void FixedUpdate()
    {
        if (_isAttacking || _isDying)
        {
            return;
        }

        if (RabbitIsNear() && mode != Mode.Attack)
        {
            mode = Mode.Attack;
        }
        else if (mode == Mode.Attack && !RabbitIsNear())
        {
            mode = Mode.GoToA;
        }

        float xSpeed = GetDirection();

        if (Mathf.Abs(xSpeed) > 0)
        {
            ApplyMovement(xSpeed);
        }

        if (xSpeed < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (xSpeed > 0)
        {
            _spriteRenderer.flipX = true;
        }

        if (IsArrived() && mode != Mode.Attack)
        {
            Debug.Log("arrived");
            mode = mode == Mode.GoToA ? Mode.GoToB : Mode.GoToA;
        }

        //if user pushed orc out of bounds
        KeepInBounds();
    }

    private void KeepInBounds()
    {
        if (transform.position.x < pointA.x)
        {
            mode = Mode.GoToB;
        }
        else if (transform.position.x > pointB.x)
        {
            mode = Mode.GoToA;
        }
    }

    private void ApplyMovement(float xSpeed)
    {
        Vector2 vel = _rigidBody.velocity;
        if (mode == Mode.Attack)
        {
            vel.x = xSpeed * _runSpeed;
            _animator.SetBool("Walk", false);
            _animator.SetBool("Run", true);
            _animator.SetBool("Attack", false);
        }
        else
        {
            vel.x = xSpeed * _patrolSpeed;
            _animator.SetBool("Walk", true);
            _animator.SetBool("Run", false);
            _animator.SetBool("Attack", false);
        }
        _rigidBody.velocity = vel;
    }
    protected bool RabbitIsNear()
    {
        rabbit_pos = RabbitController.Instance.transform.position;
        return rabbit_pos.x >= pointA.x && rabbit_pos.x <= pointB.x;
    }

    public abstract void AttackRabbit();

    float GetDirection()
    {
        if (mode == Mode.Attack)
        {
            if (transform.position.x < rabbit_pos.x)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }


        if (mode == Mode.GoToA)
        {
            return -1; //Move left
        }
        else if (mode == Mode.GoToB)
        {
            return 1; //Move right
        }
        return 0; //No movement
    }

    bool IsArrived()
    {
        if (mode == Mode.GoToA)
        {
            return IsNearPoint(transform.position, pointA);
        }
        else if (mode == Mode.GoToB)
        {
            return IsNearPoint(transform.position, pointB);
        }
        else return false;
    }

    public void Die()
    {
        if (_isDying)
        {
            return;
        }
        _animator.SetBool("Die", true);
        _isDying = true;
        Destroy(this.gameObject, 0.7f);
    }
    bool IsNearPoint(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;
        pos.y = 0;
        target.y = 0;
        return Vector3.Distance(pos, target) < 0.1f;
    }
}
