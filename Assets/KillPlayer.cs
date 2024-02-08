using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillPlayer : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public float killdist;
    public GameObject YouDiedText;

    void Start()
    {
        
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, enemy.transform.position);
        if (dist < killdist)
        {
            YouDiedText.SetActive(true);
            player.GetComponent<SC_CharacterController>().enabled = false;
        }
    }
}
