public class EnemyIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager state)
    {
        if (state.character.Target != null)
            state.agent.speed = 0;
    }
    public override void UpdateState(EnemyStateManager state)
    {
        if (state.character.Target == null)
            state.SwitchState(state.PatrolState);
    }
}
