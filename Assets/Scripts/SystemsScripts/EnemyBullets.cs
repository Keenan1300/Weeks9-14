using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{

    //Read player position
    public Transform player;
    EnemyScript EnemyScript;
    float PlayerData;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<EnemyScript>().player = player;
        EnemyScript = new EnemyScript();

        Vector3 Playerpos = player.transform.position;
        Vector2 direction = Playerpos - transform.position;
        transform.up = direction;
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<EnemyScript>().player = player;
        Vector3 Playerpos = player.transform.position;
        Vector3 pos = transform.position;

        Vector3 direction = pos - Playerpos;

        transform.position += (direction * Time.deltaTime * 20);
        Destroy(gameObject, 0.2f);
    }
}
