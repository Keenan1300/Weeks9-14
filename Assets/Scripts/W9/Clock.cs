using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clock : MonoBehaviour
{
    float time;

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

    void RotateARM()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += 30;
        transform.eulerAngles = rot;
    }
}
