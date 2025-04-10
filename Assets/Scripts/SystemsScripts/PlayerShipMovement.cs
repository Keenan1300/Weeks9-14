using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;

public class PlayerShipMovement : MonoBehaviour
{
    //Store Enemy locations from spawner
    public Spawner GetUFOData;
    public GameObject UFO;
    public SpriteRenderer UFOBOUNDS;


    //store bullets
    public GameObject bullets;

    //Store player starship booster sounds
    public AudioSource boost;
    public AudioClip playboost;

    //Store player data
    public Transform player;


    //Add unity events for each stat the player has. These will increase or decrease the 
    //values of each stat when invoked
    public UnityEvent<float> ConsumeBoost;
    public UnityEvent<float> RefillBoost;
    public UnityEvent<float> ConsumeHealth;
    public UnityEvent<float> RefillHealth;
    public UnityEvent<float> ConsumeAmmo;
    public UnityEvent<float> RefillAmmo;


    public float pos;

    //Player position data
    float Ppos;

    //Player statistics
    public float Ammo;
    public float Boost;
    public float HP;

    //Reload times for firing mechanic
    public float R;

    //Fire intervaltimes
    public float interval;

    //Boost time duration
    float B;

    //Default Speed of player ship
    float Speed = 0.015f;
    float rotspeed = 0.05f;


    //Initialize coroutine for 
    Coroutine BoosterIsBoosting;
    IEnumerator Boosted;


    // Start is called before the first frame update
    void Start()
    {
        interval = 0;
        HP = 100;
        Ammo = 12;
        Boost = 10;
        B = 10;
        BoosterIsBoosting = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Update UFO locations and bounds data
        GameObject UFO = GetUFOData.GetComponent<Spawner>().UFO;
        SpriteRenderer UFOBOUNDS = UFO.GetComponent<SpriteRenderer>();

        //Collect player position
        Vector3 pos = transform.position;

        //Find screen weidge and height data
        Vector3 squareinscreen = Camera.main.WorldToScreenPoint(pos);

        //Keep speed at a moderate rate
        if (Speed < 0.03f)
        {
            Speed += 0.01f;
        }


        //Turn ship towards mouse
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouse - transform.position;
        transform.up = direction;



        //Establish boundaries so player cant fly off the screen
        //Horizontal and Vertical boundaries
        if (squareinscreen.x < 0  )
        {
            pos = new Vector3(pos.x+0.5f,pos.y, pos.z);
            
        }

        if (squareinscreen.x > Screen.width)
        {
            pos = new Vector3(pos.x - 0.5f, pos.y, pos.z);
        }

        if (squareinscreen.y < 0 )
        {
            pos = new Vector3(pos.x, pos.y + 0.5f, pos.z);
            
        }

        if (squareinscreen.y > Screen.height)
        {
            pos = new Vector3(pos.x, pos.y-0.5f, pos.z);
        }

        if (pos.x < -14 || pos.x > 14 || pos.y < -7 || pos.y > 7)
        {
            pos = new Vector3(0, 0, 0);

        }



        //Use WASD to move 
        //check movement
        if (Input.GetKey(KeyCode.A))
        {
   
            pos.x -= Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            
            pos.x += Speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            
            pos.y += Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            pos.y -= Speed;
        }


        //Check if boost button -left shift- is used
        //Start boost-coroutine if leftshift is pressed 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            print("Phase 1 of 3 is good");

            if (BoosterIsBoosting == null)
                {
                    BoosterIsBoosting = StartCoroutine(SpeedShip());
                }
            
           
        }

        //Recharge boost overtime if its amount is less than 15, and also when the player isnt
        //already boosting
        if (B < 15 && Boost < 15 && BoosterIsBoosting == null)
        {
            B += Time.deltaTime*3;
            Boost += Time.deltaTime * 3;
            RefillBoost.Invoke(1);
        }


        //FireBullets with leftclick
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //interval controls the rate of fire for bullets. After a bullet is fire, this interval
            //resets back to 0
            if (Ammo > 1)
            {
                if (interval > 0.2f)
                {
                    //When left click is activated create an instance of a bullet, give it access 
                    //to UFO data, along with 
                    Instantiate(bullets, transform.position, Quaternion.identity);
                    Ammo -= 2;



                    interval = 0;
                }
            }
            //recharge interval over time
            interval += Time.deltaTime;
            Ammo += Time.deltaTime;

            //slow down ship as it fires
            Speed = 0.01f;

        }

        //Move ship position
        transform.position = pos;
       
    }

    // Coroutine finds the vector between the player mouse and the ship itself, and 
    // moves the ship towards the mouse rapidly to make it a appear like its boosting
    IEnumerator SpeedShip()
    {

            print("Phase 2 of 3 is good");
            Boosted = Accelerate();
            Speed = 0;
            yield return StartCoroutine(Boosted);
            BoosterIsBoosting = null;
    }


    IEnumerator Accelerate()
    {
        //play audio for boost effect    
        if (boost.isPlaying == false)
        {
            boost.clip = playboost;
            boost.Play();
        }
        

        print("Phase 3 of 3 is good!!");
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector3 pos = transform.position;
        Vector3 shift = pos - mouse;


        while (B > 1 && Boost > 1)
        {
            print("Phase 4 of 3 is good!!");
            B -= 1;
            Boost -= 1;
            ConsumeBoost.Invoke(1);
            transform.position -= (shift * Time.deltaTime* (Boost*10));


            if (pos.x < -13 || pos.x > 13 || pos.y < -6 || pos.y > 6)
            {
                pos = new Vector3(0, 0, 0);

            }
            
            yield return null;
        }
        

    }
    void Hit()
    {
        HP--;
    }

    void FireGun()
    {
        Ammo--;
    }

}
