
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrcController : AbstractOrcController
{
    [SerializeField] private GreenOrcAttackTrigger _attackRadius;
    [SerializeField] private AudioSource AttackAudio;

    public override void AttackRabbit()
    {
        if (!_isAttacking && !_isDying)
            StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        _isAttacking = true;
        _animator.SetBool("Attack", true);
        if (SoundManager.isSoundOn())
        {
            AttackAudio.Play();
        }
        yield return new WaitForSeconds(.2f);
        if (_attackRadius.RabbitClose)
        {
            RabbitController.Instance.Die();
        }
        _isAttacking = false;

    }

}
