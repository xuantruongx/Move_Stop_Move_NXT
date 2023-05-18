using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public NavMeshTriangulation NavMeshTriangulation;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        NavMeshTriangulation = NavMesh.CalculateTriangulation();
    }
}
