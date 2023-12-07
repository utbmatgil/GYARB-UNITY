using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashlight;
    public GameObject flashlight2;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;




    void Start()
    {
        off = true;
        flashlight.SetActive(false);
        flashlight2.SetActive(false);
    }




    void Update()
    {
        if(off && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(true);
            flashlight2.SetActive(true);
            //turnOn.Play();
            off = false;
            on = true;
        }

        else if (on && Input.GetKeyDown(KeyCode.F))
        {
            flashlight.SetActive(false);
            flashlight2.SetActive(false);
            //turnOff.Play();
            off = true;
            on = false;
        }



    }
}
