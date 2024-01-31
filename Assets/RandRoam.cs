using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class RandRoam : MonoBehaviour
{
    public float walkRadius;
    public float speed;
    public NavMeshAgent enemy;
    public GameObject enemyobject;
    public Vector3 waypoint1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(waypoint1);

    }
}
