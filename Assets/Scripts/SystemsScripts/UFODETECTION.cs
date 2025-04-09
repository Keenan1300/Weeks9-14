using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UFODETECTION : MonoBehaviour
{
    //Get data from field of view sprite
    SpriteRenderer sr;
    public GameObject Seeker;

    //allow access to main enemy script for data
    public EnemyScript enemyScript;

    //Get player data
    public Transform playerlocation;

    //Create an event around what happens when the player is found
    public UnityEvent<bool> playerfound;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //get player location data from main UFO script
        playerlocation = enemyScript.GetComponent<EnemyScript>().player;

        //Get the sprite data from the field of view sprite (invisible sprite)
        sr = Seeker.GetComponent<SpriteRenderer>();

        //If the player is within field of view, enable boolean
        bool playerinsight = sr.bounds.Contains(playerlocation.transform.position);
        if (playerinsight)
        {
            print("found em!!");
            playerfound.Invoke(true);
           
        }
        else
        {
            print("lostem");
        }
    }








    public void checkbounds()
    {
        Vector3 pos = playerlocation.transform.position;
        sr = Seeker.GetComponent<SpriteRenderer>();
        Bounds spritebounds = sr.sprite.bounds;
        bool playerinsight = spritebounds.Contains(pos);

        if (playerinsight)
        {
            print("found em!!");
            //Seeker.invoke(1);

        }
        else
        {
            print("lostem");
        }

        //(sr.bounds.Contains(collidingplayer.transform.position) == true)
    }
}
