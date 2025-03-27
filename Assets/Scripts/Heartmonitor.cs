using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Heartmonitor : MonoBehaviour
{

    public AnimationCurve Pulse;
    [Range(0,1)]

    float speed = 0.01f;
    float verticalspeed;
    float t;
    float V;
    float C;

    // Start is called before the first frame update
    void Start()
    {
        float t = Random.Range(2, 5);
        Vector3 pos = transform.position;
        pos.x = -8;
        pos.y = 0;
        C = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (pos.x > 10)
        {
            C = 0;
            pos.x = -9;
        }
        if (pos.x < -9)
        {
            C = 1;
            pos.x = 10;
        }


        float directionH = Input.GetAxis("Horizontal");
        float directionV = Input.GetAxis("Vertical");

        if (Input.GetKey("d")) 
        {
            speed = 0.01f;
            pos.x += speed;
            C += 0.001f;
        }

        if (Input.GetKey("a"))
        {
            speed = 0.01f;
            pos.x -= speed;
            C -= 0.001f;
        }

        transform.position = pos;


    



        pos.y = Pulse.Evaluate(C) * 8;
        pos.y -= 4;

        transform.position = pos;
        speed = 0f;
    }
}
