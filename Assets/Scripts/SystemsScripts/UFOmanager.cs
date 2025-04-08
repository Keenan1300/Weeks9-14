using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOmanager : MonoBehaviour
{
    public GameObject UFO;
    public GameObject GunDetection;

    // Start is called before the first frame update
    void Start()
    {
        //Collect enemy script from the UFO object
        EnemyScript newenemyscript = UFO.GetComponent<EnemyScript>();

        //Collect Gun range etection script, used for measuring weapon range from the player
        UFODETECTION newgundetectscript = GunDetection.GetComponent<UFODETECTION>();

        //Make is so that if the UFO starts looking for the player, the gun detection script will be included in that conversation.
        //Once the enemy looks for the player, the gunscript will also look
        newenemyscript.SeekPlayer.AddListener(newgundetectscript.checkbounds);

   
    }

    // Update is called once per frame
    void Update()
    {
        //UFO.search.Addlistener(Detection.checkbounds);

    }

    public void alerted()
    {

        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mouse - transform.position;
        transform.up = direction;
        transform.position -= (direction * Time.deltaTime);
    }


}
