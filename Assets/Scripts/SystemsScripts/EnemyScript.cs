using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{

    public UnityEvent SeekPlayer;


    //UFO stats
    public float HP;
    public float GunCoolDown;
    
    //Booleans for player detection
    public bool foundplayer;

    // Start is called before the first frame update
    void Start()
    {
        foundplayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1) 
        {
        
        }

        if (foundplayer == false)
        {
            search();
        }



        Vector3 UFOpos = transform.position;
        //Vector3 UFOrot = transform.eulerAngles;
        Vector3 UFOrot = transform.up;
        transform.eulerAngles = UFOrot;
        transform.position = UFOpos;
    }


    public void search()
    {
        Vector3 UFOrot = transform.up;
        Vector3 UFOpos = transform.position;
        UFOrot.z += 5;
        transform.up = UFOrot;
    }



    public void death()
    {
        //Remove All listeners

    }
}
