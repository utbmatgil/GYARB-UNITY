using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaticWhenClose : MonoBehaviour
{
    public AudioSource closeMusic;
    public GameObject enemy;
    public GameObject player;
    public float minDistance = 0f;
    public float maxDistance = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, enemy.transform.position);
        float scaledDistance = Mathf.Clamp01((dist - minDistance) / (maxDistance - minDistance));
        float invertedDistance = 1 - scaledDistance;
        closeMusic.volume = 0f;

        if (invertedDistance > 0f)
        {
            closeMusic.volume = invertedDistance;
        }


    }
}
