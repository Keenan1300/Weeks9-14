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
    public float B;

    float Speed = 0.015f;




    // Start is called before the first frame update
    void Start()
    {
        HP = 100;
        Ammo = 12;
        Boost = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Vector3 squareinscreen = Camera.main.WorldToScreenPoint(pos);

        
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
        
        transform.position = pos;
    
    
      //Turning towards mouse


    
    }





    void Hit() 
    {
        HP--;
    }

    void FireGun()
    {
        Ammo--;
    }

    void Booster()
    {

    }

}
