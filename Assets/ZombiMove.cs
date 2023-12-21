using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZombiMove : MonoBehaviour
{
    public float speed;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        //Alternate Solution
        //transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}