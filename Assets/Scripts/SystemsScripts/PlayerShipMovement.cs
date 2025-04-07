using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.PlayerSettings;

public class PlayerShipMovement : MonoBehaviour
{


    public UnityEvent<float> ConsumeBoost;
    public UnityEvent<float> RefillBoost;
    public UnityEvent<float> ConsumeHealth;
    public UnityEvent<float> RefillHealth;
    public UnityEvent<float> ConsumeAmmo;
    public UnityEvent<float> RefillAmmo;


    //Player position data
    float Ppos;

    //Player statistics
    public float Ammo;
    public float Boost;
    public float HP;

    //Reload times for firing mechanic
    public float R;

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
        HP = 100;
        Ammo = 12;
        Boost = 10;
        B = 10;
        BoosterIsBoosting = null;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 squareinscreen = Camera.main.WorldToScreenPoint(pos);

        //Keep speed at a moderate rate
        if (Speed < 0.015f)
        {
            Speed += 0.01f;
        }


        //Turn ship towards mouse
       
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouse - transform.position;
        transform.up = direction;

        Vector3 BoostDynamic = mouse - pos;


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

        if (pos.x < -11 || pos.x > 11 || pos.y < -6 || pos.y > 6)
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            print("Phase 1 of 3 is good");
         
            if (BoosterIsBoosting == null)
                {
                    BoosterIsBoosting = StartCoroutine(SpeedShip());
                }
            
           
        }

        if (B < 15 && Boost < 15 && BoosterIsBoosting == null)
        {
            B += Time.deltaTime*3;
            Boost += Time.deltaTime * 3;
            print(B);
            RefillBoost.Invoke(1);
        }


        //Move ship position
        transform.position = pos;
       
    }

    //Need this coroutine to progressivley move the ship in the direction its pointed in, but only until a certain amount of times
    //How can i do this through coroutines?
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
            transform.position -= (shift * Time.deltaTime*30);


            if (pos.x < -9 || pos.x > 9 || pos.y < -5 || pos.y > 5)
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
