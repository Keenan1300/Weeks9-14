using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{

    public GameObject bullets;

    //initialize unity events to seek the player
    public UnityEvent SeekPlayer;


    //Read player position
    public Transform player;


    //intialize enemy firerate
    float interval;


    //UFO stats
    public float HP;
    public float GunCoolDown;
    
    //Booleans for player detection
    public bool found;

    // Start is called before the first frame update
    void Start()
    {
        interval = 0;
    }

    // Update is called once per frame
    void Update()
    {

        

        if (HP < 1) 
        {
        
        }

        if (found == false)
        {
            search();
        }
        else
        {
            //Enemy ship will find the distance between itself and the player
            //and quickly move towards the player to be in firing range
            Vector3 Playerpos = player.transform.position;
            Vector3 direction = Playerpos - transform.position;
            direction.z = 0;
            transform.up = direction;

            transform.position += (direction * Time.deltaTime);
        }

    }

    public void isfound() 
    {
        found = true;
    }


    public void search()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += Time.deltaTime * 100;
        transform.eulerAngles = rot;
    }

    public void FireGun()
    {
        //interval controls the rate of fire for bullets. After a bullet is fire, this interval
        //resets back to 0
        if (interval > 1.5f)
        {
            //create a bullet instance, and give it the knowledge of the player position
            GameObject bullet = Instantiate(bullets, transform.position, Quaternion.identity);
            bullet.GetComponent<EnemyScript>().player = player;
            interval = 0;
        }

        //recharge interval over time
        interval += Time.deltaTime;
    }

    public void death()
    {
        //Remove All listeners

    }
}
