using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    //Sprite renderer will be used for sprite bounds
    public SpriteRenderer Bullet;

    //collect player location data
    public Transform player;
    public PlayerShipMovement playership;

    //track player HP so that this bullet can potentially lower it
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        SpriteRenderer Bullet = GetComponent<SpriteRenderer>();
        HP = playership.GetComponent<PlayerShipMovement>().HP;

        //Read where the player is
        Vector3 ppos = player.transform.position;

        //use current location
        Vector3 pos = transform.position;

        //find the middle vector between these 2 location
        Vector3 bulletrack = pos - ppos;

        Vector3 move = transform.position;

        //Subtract current postion by the distance between itself and the playership
        move -= bulletrack * Time.deltaTime * 20;       

        transform.position = move;

        

        //check if this bullet is colliding with player
        bool playerhit = Bullet.bounds.Contains(player.transform.position);

        if (playerhit)
        {
            playership.Hit();
            Destroy(gameObject);

        }

    }

    public void setPlayer(PlayerShipMovement playerset)
    {
        Debug.Log("Setting player to bullet");
        playership = playerset;
        if(playership == null)
        {
            print("Hello!");
        }
    }
}
