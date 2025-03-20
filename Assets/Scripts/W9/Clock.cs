using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;


public class Clock : MonoBehaviour
{
    float time;
    public AudioSource Sound;
    public UnityEvent clock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += Time.deltaTime  * 2;
        transform.eulerAngles = rot;
    }

    public void RotateARM()
    {
        Sound.Play();
        Vector3 rot = transform.eulerAngles;
        rot.z += 30;
        transform.eulerAngles = rot;
    }
}
