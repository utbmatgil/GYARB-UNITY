using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(SphereCollider))]
public class LineOfSight : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float detection_delay = 0.5f;
    private Collider player_collider;
    private SphereCollider detection_collider;
    private Coroutine detect_player;
    public NavMeshAgent enemy;
    public GameObject chaseobject;
    public Transform player;
    public List<Transform> waypoints;
    Transform currenTarget;
    private int _index = 1;
    private bool inReverse;
    private bool atEnd;
    private bool Moving; 

    private void Awake() => detection_collider = this.GetComponent<SphereCollider>();

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            target = other.gameObject;
            detect_player = StartCoroutine(DetectPlayer());
            player_collider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            target = null;
            StopCoroutine(detect_player);
        }
    }

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();

        if (waypoints.Count > 0 && waypoints[0] != null)
        {
            currenTarget = waypoints[_index];
            enemy.SetDestination(currenTarget.position);

        }
    }

    private void Update()
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

    IEnumerator DetectPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(detection_delay);
            if (target != null)
            {
                Vector3[] points = GetBoundingPoints(player_collider.bounds);
                int points_hidden = 0;
                foreach (Vector3 point in points)
                {
                    Vector3 target_direction = point - this.transform.position;
                    float target_distance = Vector3.Distance(this.transform.position, point);
                    float target_angle = Vector3.Angle(target_direction, this.transform.forward);
                    if (IsPointCovered(target_direction, target_distance) || target_angle > 70)
                        ++points_hidden;
                }
                if (points_hidden >= points.Length)
                {
                    chaseobject.SetActive(false);
                    // Go to waypoints
                }
                else
                {
                    chaseobject.SetActive(true);
                    enemy.SetDestination(player.position);
                }
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

    private Vector3[] GetBoundingPoints(Bounds bounds)
    {
        Vector3[] bounding_points =
        {
            bounds.min,
            bounds.max,
            new Vector3(bounds.min.x, bounds.min.y, bounds.max.z),
            new Vector3(bounds.min.x, bounds.max.y, bounds.min.z),
            new Vector3(bounds.max.x, bounds.min.y, bounds.min.z),
            new Vector3(bounds.min.x, bounds.max.y, bounds.max.z),
            new Vector3(bounds.max.x, bounds.min.y, bounds.max.z),
            new Vector3(bounds.max.x, bounds.max.y, bounds.min.z)
        };
        return bounding_points;
    }
}
