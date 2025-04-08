using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOmanager : MonoBehaviour
{
    public GameObject UFO;
    public GameObject Detection;

    // Start is called before the first frame update
    void Start()
    {

        EnemyScript newenemyscript = UFO.GetComponent<EnemyScript>();
        UFODETECTION newdetectscript = Detection.GetComponent<UFODETECTION>();

        newenemyscript.SeekPlayer.AddListener(newdetectscript.checkbounds);

   
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
