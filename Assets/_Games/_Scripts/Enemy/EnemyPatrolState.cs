using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolState : EnemyBaseState
{
    Vector3 position;

    public override void EnterState(EnemyStateManager state)
    {

        MoveToRandomPosition(state);
        state.RandomTime = 10f;
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
        state.RandomTime -= Time.deltaTime;
        if (state.RandomTime <= 0)
        {
            MoveToRandomPosition(state);
            state.RandomTime = 10;
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
        NavMeshHit hit;
        if (NavMesh.SamplePosition(LevelManager.instance.NavMeshTriangulation.vertices[vertexIndex], out hit, 2f, NavMesh.AllAreas))
        {
            state.agent.SetDestination(hit.position + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)));
        }
    }
}
