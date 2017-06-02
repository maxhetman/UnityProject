
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrcController : AbstractOrcController
{
    [SerializeField] private GreenOrcAttackTrigger _attackRadius;

    public override void AttackRabbit()
    {
        if (!_isAttacking && !_isDying)
            StartCoroutine(Attacking());
    }

    private IEnumerator Attacking()
    {
        _isAttacking = true;
        _animator.SetBool("Attack", true);
        yield return new WaitForSeconds(.2f);
        if (_attackRadius.RabbitClose)
        {
            RabbitController.Instance.Die();
        }
        _isAttacking = false;

    }

}
