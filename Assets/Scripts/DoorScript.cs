using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;
    public GameObject IntereactText;

    private bool opened = false;
    private Animator anim;
    private float distanceToClosestDoor; // Variable to store the distance to the closest door
    private float distanceToPlayer; // Variable to store the distance to the player

    void Update()
    {
        // Calculate distances to closest door and player each frame
        CalculateDistances();

        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
        }
    }

    void Pressed()
    {
        // This will name the Raycasthit and came information of which object the raycast hit.
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            // If raycast hits, then it checks if it hit an object with the tag Door.
            if (doorhit.transform.CompareTag("Door"))
            {
                // This line will get the Animator from Parent of the door that was hit by the raycast.
                anim = doorhit.transform.GetComponentInParent<Animator>();

                // Get the current state of the door
                opened = anim.GetBool("Opened");

                // Toggle the state of the door
                opened = !opened;

                // This line will set the bool true so it will play the animation.
                anim.SetBool("Opened", opened);
            }
        }
    }

    void CalculateDistances()
    {
        // Calculate distance to the closest door
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject door in doors)
        {
            float distance = Vector3.Distance(transform.position, door.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
            }
        }

        distanceToClosestDoor = closestDistance;

        Debug.Log(distanceToClosestDoor);

        if (distanceToClosestDoor < 2)
        {
            IntereactText.SetActive(true);
        }

        // Calculate distance to the player
        if (PlayerCamera != null)
        {
            distanceToPlayer = Vector3.Distance(transform.position, PlayerCamera.position);
        }
        else
        {
            distanceToPlayer = Mathf.Infinity; // Set to infinity if PlayerCamera is not assigned
        }
    }
}
