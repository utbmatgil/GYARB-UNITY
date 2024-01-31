using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ZombiMove : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    void Start()
    {

    }

    void Update()
    {
        enemy.SetDestination(player.position);
    }
}