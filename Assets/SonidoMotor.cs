using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoMotor : MonoBehaviour
{

    public AudioSource Motor;
    public AudioSource Motor2;

    // Use this for initialization
    void Start()
    {

        Motor.GetComponent<AudioSource>();
        Motor2.GetComponent<AudioSource>();
        Motor.Play();
        Motor2.time = 2;
    }

    // Update is called once per frame
    void Update()
    {
    }
}