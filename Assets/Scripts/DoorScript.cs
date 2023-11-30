using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform PlayerCamera;
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;

    void Update()
    {
        // Check if the 'E' key is pressed down this frame
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pressed();
            Debug.Log("You Press E");
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        // Use Input.GetKey instead of Input.GetKeyDown to make sure you're not checking every frame
        // Also, consider checking for other conditions (e.g., raycast hit) before proceeding
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance) && doorhit.transform.tag == "Door")
        {
            anim = doorhit.transform.GetComponentInParent<Animator>();
            opened = !opened;
            anim.SetBool("Opened", opened);
        }
    }
}




