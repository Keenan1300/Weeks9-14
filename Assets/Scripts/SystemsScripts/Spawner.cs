using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    //StoreAllpickupPrefabs
    public GameObject ShieldPickup;
    public GameObject AmmoPickup;
    public GameObject HPPickup;


    //Keep track of buttons for introduction
    public GameObject buttonobject;
    public Button Startwavebutton;


    //Collect player script
    public PlayerShipMovement PlayerShipMovement;


    //Necessary GameObject information for instantiation chains
    //This will act as the UFOs the player will shoot at
    public GameObject UFO;


    //Stores bullet object
    public GameObject bullets;
    public SpriteRenderer bulletsprite;

    //Trackplayerposition at all times
    public Transform player;

    //Track all areas UFOs can potentially spawn
    public Transform Spawnlocation1;
    public Transform Spawnlocation2;
    public Transform Spawnlocation3;
    public Transform Spawnlocation4;

    //T will decided the randomness of spawning at one of these locations
    int T;

    //basic timer
    float Timer;

    //store player ammo
    public float Ammo;

    //store when player can and cannot fire
    public bool Cannotfire;

    //S will dictate the delay between spawns 
    float S = 0;

    //initialize 4 waves the player must survive
    public bool wave1;
    public bool wave2;
    public bool wave3;
    public bool wave4;


    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer bulletsprite = bullets.GetComponent<SpriteRenderer>();

        //listen to when the button is clicked. If it is, spawn UFOs 
        Startwavebutton = buttonobject.GetComponent<Button>();
        Startwavebutton.onClick.AddListener(Startwave1);

        //Define the beginning and end of waves
        wave1 = false;
        wave2 = false;
        wave3 = false;
        wave4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Ammo = PlayerShipMovement.GetComponent<PlayerShipMovement>().Ammo;
        bool Cannotfire = PlayerShipMovement.GetComponent<PlayerShipMovement>().Cannotfire;
        //'S' will be the spawn rate of UFOs, and will vary from wave to wave.

        Debug.Log(S);

        if (wave1 == true)
        {
            S += Time.deltaTime*5;

            if (S > 10)
            {
                spawnUFOs();
                S = 0;
            }

        }

    }

    public void spawnUFOs()
    {
      
        T = Random.Range(1, 5);

        //Random Roll for where UFO will spawn. Decided by T
        if (T == 1)
        {
            Vector3 Spawnlocation = Spawnlocation1.transform.position;
            GameObject newUFO = Instantiate(UFO, Spawnlocation, Quaternion.identity);
            newUFO.GetComponent<EnemyBullets>().player = player.transform;
            newUFO.GetComponent<EnemyScript>().bullets = bullets;
        }
        if (T == 2)
        {
            Vector3 Spawnlocation = Spawnlocation2.transform.position;
            GameObject newUFO = Instantiate(UFO, Spawnlocation, Quaternion.identity);
            newUFO.GetComponent<EnemyScript>().player = player.transform;
            newUFO.GetComponent<EnemyScript>().playership = PlayerShipMovement;
            newUFO.GetComponent<EnemyScript>().bullets = bullets;
        }
        if (T == 3)
        {
            Vector3 Spawnlocation = Spawnlocation3.transform.position;
            GameObject newUFO = Instantiate(UFO, Spawnlocation, Quaternion.identity);
            newUFO.GetComponent<EnemyScript>().player = player.transform;
            newUFO.GetComponent<EnemyScript>().playership = PlayerShipMovement;
            newUFO.GetComponent<EnemyScript>().bullets = bullets;
        }
        if (T >= 4)
        {
            Vector3 Spawnlocation = Spawnlocation4.transform.position;
            GameObject newUFO = Instantiate(UFO, Spawnlocation, Quaternion.identity);
            newUFO.GetComponent<EnemyScript>().player = player.transform;
            newUFO.GetComponent<EnemyScript>().playership = PlayerShipMovement;
            newUFO.GetComponent<EnemyScript>().bullets = bullets;
        }
        
    }

    public void Startwave1()
    {
        S = 0;
        wave1 = true;
    }
}
