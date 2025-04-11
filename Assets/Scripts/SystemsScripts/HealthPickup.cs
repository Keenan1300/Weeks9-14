using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    //use sprite render to measure boundaries of object
    public SpriteRenderer pickupbounds;
    public Transform player;
    public bool Shield;

    //Collect player script
    public PlayerShipMovement PlayerShipMovement;

    // Start is called before the first frame update
    void Start()
    {
        player = player.GetComponent<Transform>();
        pickupbounds = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        //check if this bullet is colliding with player
        bool playerhit = pickupbounds.bounds.Contains(player.transform.position);

        if (playerhit)
        {
            PlayerShipMovement.restorehealth();
            Destroy(gameObject);

        }

    }
}