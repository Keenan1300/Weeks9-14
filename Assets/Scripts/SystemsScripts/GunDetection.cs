using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDetection : MonoBehaviour
{
    SpriteRenderer sr;
    
    public GameObject Seeker;
    public Transform playerlocation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        else
        {
            print("Gunslostem");
        }
    }


    public void firebullets()
    {
        //instantiate()
    }


}
