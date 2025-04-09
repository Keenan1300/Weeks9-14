using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunDetection : MonoBehaviour
{
    SpriteRenderer sr;
    
    //Define the range where the UFO will shoot at the player
    public GameObject Seeker;

    //allow access to main enemy script for player data
    public EnemyScript enemyScript;
    public Transform playerlocation;


    public UnityEvent<bool> Fire;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerlocation = enemyScript.GetComponent<EnemyScript>().player;
        checkbounds();
    }

    public void checkbounds()
    {

        sr = Seeker.GetComponent<SpriteRenderer>();

        bool playerinsight = sr.bounds.Contains(playerlocation.transform.position);



        if (playerinsight)
        {
            print("found em and gonna shoot this mofo");
            firebullets();
        }
        else if (!playerinsight)
        {
            print("Gunslostem");
        }
    }


    public void firebullets()
    {
        Fire.Invoke(true);
    }


}
