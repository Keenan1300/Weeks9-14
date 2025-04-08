using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFODETECTION : MonoBehaviour
{
    SpriteRenderer sr;
    GameObject collidingplayer;
    GameObject Seeker;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkbounds()
    {

        if (sr.bounds.Contains(collidingplayer.transform.position))
        {
            print("found em!!");
            //Seeker.invoke(1);

        }

    }
}
