using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    Vector3 position;
    public override void EnterState(EnemyStateManager state)
    {
        MoveToRandomPosition(state);
    }
    public override void UpdateState(EnemyStateManager state)
    {
        if (state.character.Target == null && Vector3.Distance(state.character.CharacterTransform.position, position) <= state.agent.stoppingDistance)
        {
            MoveToRandomPosition(state);
        }
        if (state.character.Target != null)
        {
            state.SwitchState(state.IdleState);
        }
    }

    public void MoveToRandomPosition(EnemyStateManager state)
    {
        state.agent.speed = 3;
        int vertexIndex = Random.Range(0, LevelManager.instance.NavMeshTriangulation.vertices.Length);
        //while (Vector3.Distance(LevelManager.instance.NavMeshTriangulation.vertices[vertexIndex], state.character.CharacterTransform.position) >= 15)
        //{
        //    vertexIndex = Random.Range(0, LevelManager.instance.NavMeshTriangulation.vertices.Length);
        //}
        position = LevelManager.instance.NavMeshTriangulation.vertices[vertexIndex];
        state.agent.SetDestination(position);
    }
}
