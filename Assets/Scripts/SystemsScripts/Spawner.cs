using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //This will act as the UFOs the player will shoot at
    public GameObject UFO; 


    //initialize 4 waves the player must survive
    public bool wave1;
    public bool wave2;
    public bool wave3;
    public bool wave4;


    // Start is called before the first frame update
    void Start()
    {
        wave1 = false;
        wave2 = false;
        wave3 = false;
        wave4 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (wave1 == true)
        { 
        
        
        
        }

    }

    public void spawnUFOs()
    {

    }
}
