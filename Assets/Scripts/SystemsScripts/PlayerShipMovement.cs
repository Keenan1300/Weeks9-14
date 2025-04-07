using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{

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
        if (Speed > 0.015f)
        {
            Speed -= 0.01f;
        }


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
            if (Boost > 1)
            {
                if (BoosterIsBoosting == null)
                {
                    BoosterIsBoosting = StartCoroutine(SpeedShip());
                }
                else
                {
                    BoosterIsBoosting = null;
                }
            }
           
        }
        else
        {
            //Boosted = false;
        }
            transform.position = pos;


        //Turn ship towards mouse
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 0;
        Vector2 direction = mouse - transform.position;
        transform.up = direction;

    
    }


    IEnumerator SpeedShip()
    {
            print("Phase 2 of 3 is good");
            B = 10;
            Boosted = Accelerate();
            yield return StartCoroutine(Boosted);
            yield return null;
    }


    IEnumerator Accelerate()
    {
        print("Phase 3 of 3 is good!!");
        
        while (B > 1 && Boost < 1)
        {
            print("Phase 4 of 3 is good!!");
            Vector3 pos = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 BoostDynamic = mousePos - pos;  
            
            transform.position = BoostDynamic - pos;
            Speed += 5f;
            B -= 1;
            Boost -= 1;
        }
        yield return null;
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
