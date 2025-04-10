using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScript : MonoBehaviour
{
    //Store Bounds of UFO
    public SpriteRenderer UFOBOUNDS;
    public GameObject UFOSPRITE;

    //Stores enemy bullet object
    public GameObject bullets;

    //Store pickup item that potentially drops with UFO death
    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;

    //randomdice roll for pickups
    float PickupRoll;

    //initialize unity events to seek the player
    public UnityEvent SeekPlayer;


    //Read player positions
    public Transform player;
    public float Playerammo;

    //intialize enemy firerate
    float interval;
    
    //Booleans for player detection
    public bool found;

    // Start is called before the first frame update
    void Start()
    {
        interval = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //Update Sprite Boundaries of UFO so that player can access where UFO Sprite is
        SpriteRenderer UFOBOUNDS = UFOSPRITE.GetComponent<SpriteRenderer>();
       
       //Know where player mouse is at all times
       Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (found == false)
        {
            search();
        }
        else
        {
            //Enemy ship will find the distance between itself and the player
            //and quickly move towards the player to be in firing range
            Vector3 Playerpos = player.transform.position;
            Vector3 direction = Playerpos - transform.position;
            direction.z = 0;
            transform.up = direction;

            transform.position += (direction * Time.deltaTime);
        }


        //check if this bullet is colliding with player
        bool UFOhinrange = UFOBOUNDS.bounds.Contains(mouse);

        if (UFOhinrange)
        {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    death();
                }
            

        }
    }

    public void isfound() 
    {
        found = true;
    }


    public void search()
    {
        Vector3 rot = transform.eulerAngles;
        rot.z += Time.deltaTime * 100;
        transform.eulerAngles = rot;
    }

    public void FireGun()
    {
        //interval controls the rate of fire for bullets. After a bullet is fire, this interval
        //resets back to 0
        if (interval > 0.5f)
        {
            Vector3 Playerpos = player.transform.position;
            Vector3 direction = Playerpos - transform.position;

            //create a bullet instance, and give it the knowledge of the player position
            GameObject bullet = Instantiate(bullets, transform.position, Quaternion.identity);
            
            interval = 0;

            bullet.transform.up = direction;
            bullet.GetComponent<EnemyBullets>().player = player.transform;
  
            EnemyBullets Script = bullet.GetComponent<EnemyBullets>();

            Destroy(bullet,0.5f);
        }

        //recharge interval over time
        interval += Time.deltaTime;
    }

    public void bulletFiring()
    {
        Vector3 Playerpos = player.transform.position;
        Vector3 pos = transform.position;

        Vector3 direction = pos - Playerpos;

        transform.position += (direction * Time.deltaTime * 20);
    }
    public void death()
    {
        PickupRoll = Random.Range(1, 10);


        if (PickupRoll == 1)
        {
            GameObject pickupchance = Instantiate(pickup1, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.7f);
        }
        if (PickupRoll == 2)
        {
            GameObject pickupchance = Instantiate(pickup2, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.7f);
        }
        if (PickupRoll == 3)
        {
            GameObject pickupchance = Instantiate(pickup3, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.7f);
        }
        if (PickupRoll >= 4)
        {
            Destroy(gameObject, 0.7f);
        }


    }
    }
