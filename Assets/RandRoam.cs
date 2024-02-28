using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class RandRoam : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float detection_delay = 0.5f;
    private Collider player_collider;
    private SphereCollider detection_collider;
    private Coroutine detect_player;
    public NavMeshAgent enemy;
    public Transform player;
    public List<Transform> waypoints;
    Transform currenTarget;
    private int _index = 1;
    private bool inReverse;
    private bool atEnd;
    private bool Moving;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();

        if (waypoints.Count > 0 && waypoints[0] != null)
        {
            currenTarget = waypoints[_index];
            enemy.SetDestination(currenTarget.position);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currenTarget != null)
        {
            if ((Vector3.Distance(transform.position, currenTarget.position) <= 2f) && Moving)
            {
                Moving = false;
                StartCoroutine("MoveToNextWayPoint");
            }
        }

    }

    IEnumerator MoveToNextWayPoint()
    {
        if (!inReverse)
        {
            _index++;
        }

        if (_index < waypoints.Count && !inReverse)
        {
            if (_index == 1)
                yield return new WaitForSeconds(Random.Range(3f, 6f));

            currenTarget = waypoints[_index];
        }
        else
        {
            if (!atEnd)
            {
                atEnd = true;
                yield return new WaitForSeconds(Random.Range(3f, 6f));
            }

            _index--;
            inReverse = true;

            if (_index == 0)
            {
                inReverse = false;
                atEnd = false;

            }

            currenTarget = waypoints[_index];
        }

        enemy.SetDestination(currenTarget.position);
        Moving = true;

    }

    private bool IsPointCovered(Vector3 target_direction, float target_distance)
    {
        RaycastHit[] hits = Physics.RaycastAll(this.transform.position, target_direction, detection_collider.radius);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Cover"))
            {
                float cover_distance = Vector3.Distance(this.transform.position, hit.point);
                if (cover_distance < target_distance)
                    return true;
            }
        }
        return false;
    }
}
