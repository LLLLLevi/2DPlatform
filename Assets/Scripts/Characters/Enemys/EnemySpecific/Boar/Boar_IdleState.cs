public class Boar_IdleState : EnemyIdleState
{
    Boar boar;
    public Boar_IdleState(EnemyEntity entity, FiniteStateMachine stateMachine, string animBoolName, Boar boar) : base(entity, stateMachine, animBoolName)
    {
        this.boar = boar;       
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //玩家进入小范围检测
        if (isMinRangDectctedPlayer)
        {
            stateMachine.ChangState(boar.playerDetectedState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangState(boar.moveState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
