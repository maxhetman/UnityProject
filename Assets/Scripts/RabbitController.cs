using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{

    #region Variables
    public static RabbitController Instance;
    public float Speed = 2.0f;
    public float MaxJumpTime = 2f;
    public float JumpSpeed = 2f;
    public float BiggerSize = 1.4f;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _isGrounded = false;
    private bool _jumpActive = false;
    private float _jumpTime = 0f;
    private bool _isDead = false;
    private bool isBig = false;

    public const int MAX_HEALTH = 3;

    //audio 
    public AudioSource RabbitAudioSource;

    public AudioClip RunAudioClip;
    public AudioClip DieAudioClip;
    public AudioClip JumpAudioClip;

    [HideInInspector] public int CurrentHealth;

    #endregion

    #region Unity
    void Awake()
    {
        Instance = this;
        CurrentHealth = MAX_HEALTH;
    }

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (LevelController.Instance != null && LevelController.Instance.IsLevelFinished)
        {
            return;
        }

        if (_isDead)
        {
            return;
        }

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
            if (SoundManager.isSoundOn())
            {
                PlayRunSound();
            }

        }

        Vector3 from = transform.position + Vector3.up * 0.3f;
        Vector3 to = transform.position + Vector3.down * 0.1f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");
        //Перевіряємо чи проходить лінія через Collider з шаром Ground
        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            if (hit.transform.GetComponent<MovingPlatform>() != null)
            {
                transform.SetParent(hit.transform);
            }
            else
            {
                transform.SetParent(null);   
            }
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        Debug.DrawLine(from, to, Color.red);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            this._jumpActive = true;
            if (SoundManager.isSoundOn())
            {
                PlayJumpSound();
            }
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

    #endregion

    private void PlayRunSound()
    {
        RabbitAudioSource.clip = RunAudioClip;
        RabbitAudioSource.loop = true;
        RabbitAudioSource.Play();
    }

    private void PlayJumpSound()
    {
        RabbitAudioSource.clip = JumpAudioClip;
        RabbitAudioSource.loop = false;
        RabbitAudioSource.Play();
    }

    private void PlayDieSound()
    {
        RabbitAudioSource.clip = DieAudioClip;
        RabbitAudioSource.loop = false;
        RabbitAudioSource.Play();
    }
    public void OnBomb()
        {
        if (isBig)
        {
            transform.localScale = new Vector3(1f, 1f, 0f);
            isBig = false;
        }
        else
        {
            Die();
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(2f);
        LevelController.Instance.OnRabitDeath(this);
        _isDead = false;
        _animator.SetBool("Die", false);
    }

    public void Die()
    {
        if (_isDead)
            return;
        _animator.SetBool("Die", true);
        if (SoundManager.isSoundOn())
        {
            PlayDieSound();
        }
        _isDead = true;
        StartCoroutine(Respawn());
    }

    public void RabbitGrow()
    {
        if (isBig)

        {
            return;
        }
        else
        {
            transform.localScale = new Vector3(BiggerSize, BiggerSize, 0);
            isBig = true;
        }
    }
}
