using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{

    public UnityEvent SeekPlayer;

    public UFODETECTION detect;

    //UFO stats
    public float HP;
    public float GunCoolDown;
    
    //Booleans for player detection
    public bool found;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        found = detect.GetComponent<UFODETECTION>().foundplayer;

        

        if (HP < 1) 
        {
        
        }

        if (found == false)
        {
            search();
        }

        //Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = mouse - transform.position;

        //Vector3 UFOrot = transform.up;
        //Vector2 UFOpointer = transform.position;
        //UFOpointer.x += Time.deltaTime*0.004f;
        //transform.up = UFOpointer;

        detect.foundplayer = found;

    }


    public void search()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += Time.deltaTime * 100;
        transform.eulerAngles = rot;
    }



    public void death()
    {
        //Remove All listeners

    }
}
