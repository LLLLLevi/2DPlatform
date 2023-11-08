using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public EnemyAttackState attackState;

    public void TriggerAttack()
    {
        attackState.TriggerAttack();
    }
    public void FinishAttack()
    {
        attackState.FinishAttack();
    }
}
