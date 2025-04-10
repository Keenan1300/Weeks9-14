using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BulletAction : MonoBehaviour
{
    //Randomly dictates the life span of bullets shot by the player
    float BulletDecay;

    //Audio elements for the bullet
    public AudioSource laser;
    public AudioClip lasersound;

    // Start is called before the first frame update
    void Start()
    {
        //playlasersound upon being created to make gun feel sci-fi
        laser.clip = lasersound;
        laser.Play();

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouse - transform.position;
        transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = transform.position;
        BulletDecay = Random.Range(0.05f, 0.1f);
        Vector3 bulletrad = pos - mouse;
        transform.position -= (bulletrad * Time.deltaTime * 30);
        Destroy(gameObject, BulletDecay);
    }
}
