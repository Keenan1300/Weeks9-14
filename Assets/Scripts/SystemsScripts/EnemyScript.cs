using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float HP;
    public float GunCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1) 
        {
        
        }

        Vector3 UFOpos = transform.position;
        //Vector3 UFOrot = transform.eulerAngles;
        Vector3 UFOrot = transform.up;
        transform.eulerAngles = UFOrot;
        transform.position = UFOpos;

        search();
    }


    void search()
    {
        Vector3 UFOrot = transform.up;
        Vector3 UFOpos = transform.position;
        UFOrot.z += 5;
        transform.up = UFOrot;
    }

    void alerted() 
    {

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouse - transform.position;
        transform.up = direction;
        transform.position -= (direction * Time.deltaTime);
    }


    void death()
    {
        //Remove All listeners

    }
}
