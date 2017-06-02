using System.Collections;
using UnityEngine;


public class BrownOrcController : AbstractOrcController
{

    [SerializeField] private GameObject _carrotPrefab;
    [SerializeField] private Transform _launchPoint;
    [SerializeField] private float _shootDelay;

    private float _shootTimeLeft;
    void Update()
    {
        if (RabbitIsNear())
        {
            _isAttacking = true;
            Debug.Log("Is attacking" + _isAttacking);
            _animator.SetBool("Run", false);
            _animator.SetBool("Walk", false);

            float rabbitDirection = GetRabbitDirection();

            _shootTimeLeft -= Time.deltaTime;
            if (_shootTimeLeft <= 0)
            {
                AttackRabbit();
                LookAtRabbit(rabbitDirection);
                LaunchCarrot(rabbitDirection);
            }
        }
        else
        {
            _isAttacking = false;
        }
    }

    private void LookAtRabbit(float direction)
    {
        if (direction < 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction > 0)
        {
            _spriteRenderer.flipX = true;
        }
    }
    public override void AttackRabbit()
    {
        
        if (_isAttacking)
            StartCoroutine(Attacking());


    }

    private IEnumerator Attacking()
    {
        _animator.SetBool("Attack", true);
        _shootTimeLeft = _shootDelay;
        yield return new WaitForSeconds(0.8f);
        _animator.SetBool("Attack", false);
    }

    private void LaunchCarrot(float direction)
    {
        GameObject carrot = Instantiate(_carrotPrefab, _launchPoint.position, Quaternion.identity);
        CarrotFly carrotScript = carrot.GetComponent<CarrotFly>();
        carrotScript.Launch(direction);
        Destroy(carrot, 2f);
    }

    private float GetRabbitDirection()
    {
        rabbit_pos = RabbitController.Instance.transform.position;
        if (rabbit_pos.x < transform.position.x)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
