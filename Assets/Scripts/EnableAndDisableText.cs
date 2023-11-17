using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Namespace for Unity's UI system

public class EnableAndDisableText : MonoBehaviour
{
    [SerializeField] Text text; // Text that you want to disable

    private void Update() // Called every frame
    {
        if (Input.GetKeyDown(KeyCode.E)) // If the 'E' key is pressed,
        {
            text.enabled = false; // Disable text
        }
    }

}

