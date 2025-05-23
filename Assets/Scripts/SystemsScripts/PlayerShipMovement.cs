using JetBrains.Annotations;
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

    //recognize shield game object
    public GameObject Shield;
    //checks if shield is gained
    public bool ShieldGained;
    //measures duration of shield pickup
    public float Stime;

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


    //Let ammo decide whether or not shots can be made
    public bool Cannotfire = false;

    //Initialize coroutine for boosting, will rapidly process player movement 
    Coroutine BoosterIsBoosting;
    IEnumerator Boosted;


    // Start is called before the first frame update
    void Start()
    {

        Shield.SetActive(false);

        //set stat values for player ship
        interval = 0;
        HP = 15;
        Ammo = 15;
        Boost = 10;
        B = 10;
        BoosterIsBoosting = null;
    }

    // Update is called once per frame
    void Update()
    {


        //recognize shield booster. Give it a time for how long it provides invulnerability.
        if (ShieldGained == true)
        {
            Stime += Time.deltaTime;

            if (Stime < 5)
            {
                Shield.SetActive(true);
                HP = 15;
            }
            else
            {
                Shield.SetActive(false);
                ShieldGained = false;
            }
        }



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

        //check ammo amount so player can slowly recharge bullets
        if (Ammo < 14)
        {
            Ammo += (Time.deltaTime * 5);

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
                Cannotfire = false;

                if (interval > 0.1f)
                {
                    //When left click is activated create an instance of a bullet, give it access 
                    //to UFO data, along with 
                    Instantiate(bullets, transform.position, Quaternion.identity);
                    Ammo -= 2;



                    interval = 0;
                }
            }
            else
            {
                Cannotfire = true;
            }
            //recharge interval over time
            interval += Time.deltaTime;

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
        //Setup speed variable so it doesnt interfere with boost functions.
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
        
        //Collect positional data so the ship knows where its boosting
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector3 pos = transform.position;
        Vector3 shift = pos - mouse;

        //Establish while loop that reduces total boost amount with each use, but also abides by interval of boost use
        //makes it so player consumes turbo, but not all at once.
        while (B > 1 && Boost > 1)
        {
            B -= 1;
            Boost -= 1;
            ConsumeBoost.Invoke(1);

            //Move player along the vector between the mouse and its own position
            transform.position -= (shift * Time.deltaTime* (Boost*10));


            //Check to make sure player is never too far out of bounds from boost. If they somehow are, return them to the center of the game screen.
            if (pos.x < -13 || pos.x > 13 || pos.y < -6 || pos.y > 6)
            {
                pos = new Vector3(0, 0, 0);

            }
            
            yield return null;
        }
        

    }
    //function for when player is hit by a bullet
    public void Hit()
    {
        HP--;
    }

    //function for Health restore pickup item
    public void restorehealth() 
    {
        HP = 15;
    }

    //function for Ammo restore pickup item
    public void ammorefill()
    {
        Ammo = 15;
    }

    //function for shield boost pickup item
    public void gainshield() 
    {
        Stime = 0;
        ShieldGained = true;
    }

}
