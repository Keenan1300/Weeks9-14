using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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

    //GameLostIndicator
    public GameObject GameOver;

    //Spawn data holder
    public Spawner Spawn;


    //Collect player script
    public PlayerShipMovement PlayerShipMovement;


    //Necessary GameObject information for instantiation chains
    //This will act as the UFOs the player will shoot at
    public GameObject UFO;

    //Count the amount of UFOs to ensure there isnt too many
    int UFOSpawncount;

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


    //establish game loss condition
    float losscondition;



    // Start is called before the first frame update
    void Start()
    {
        UFOSpawncount = 0;
        //Make sure the game isnt over before it has started.
        //disable gameover screen
        GameOver.SetActive(false);

        //gather sprite renderer for bullets
        SpriteRenderer bulletsprite = bullets.GetComponent<SpriteRenderer>();

        //listen to when the button is clicked. If it is, spawn UFOs 
        Startwavebutton = buttonobject.GetComponent<Button>();
        Startwavebutton.onClick.AddListener(Startwave1);

        //Define the beginning and end of waves
        wave1 = false;

    }

    // Update is called once per frame
    void Update()
    {
        //keep track of how many UFOs are in the scene
        Debug.Log(UFOSpawncount);

        //check if the player has lost the game
        losscondition = PlayerShipMovement.GetComponent<PlayerShipMovement>().HP;

        if (losscondition < 1)
        {
            GameOver.SetActive(true);
        }

        //establish when the player can and cannot fire due to ammo shortage 
        float Ammo = PlayerShipMovement.GetComponent<PlayerShipMovement>().Ammo;
        bool Cannotfire = PlayerShipMovement.GetComponent<PlayerShipMovement>().Cannotfire;
        //'S' will be the spawn rate of UFOs, and will vary from wave to wave.

        if (wave1 == true)
        {
            S += Time.deltaTime*5;

            if (S > 10)
            {
                if(UFOSpawncount < 10)
                {
                    spawnUFOs();
                    S = 0;
                }
               
            }

        }

    }

    public void spawnUFOs()
    {
        UFOSpawncount += 1;
        T = Random.Range(1, 5);

        //Random Roll for where UFO will spawn. Decided by T
        if (T == 1)
        {
            Vector3 Spawnlocation = Spawnlocation1.transform.position;
            GameObject newUFO = Instantiate(UFO, Spawnlocation, Quaternion.identity);
            newUFO.GetComponent<EnemyScript>().player = player.transform;
            newUFO.GetComponent<EnemyScript>().playership = PlayerShipMovement;
            newUFO.GetComponent<EnemyScript>().bullets = bullets;
            newUFO.GetComponent<EnemyScript>().Spawn = Spawn;
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

    public void ReduceCount() 
    {
        UFOSpawncount -= 1;

    }
}
