using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFODETECTION : MonoBehaviour
{
    SpriteRenderer sr;
    SpriteRenderer Pr;
    
    public GameObject collidingplayer;
    public GameObject Seeker;
    public Transform playerlocation;
    public PlayerShipMovement r;
    public float h;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //h = r.GetComponent<PlayerShipMovement>().pos;
        sr = Seeker.GetComponent<SpriteRenderer>();

        bool playerinsight = sr.bounds.Contains(playerlocation.transform.position);



        if (playerinsight)
        {
            print("found em!!");
            //Seeker.invoke(1);

        }
        else
        {
            print("lostem");
        }
    }








    public void checkbounds()
    {
        Vector3 pos = collidingplayer.transform.position;
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
