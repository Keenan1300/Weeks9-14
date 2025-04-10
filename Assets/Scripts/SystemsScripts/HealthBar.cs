using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject PlayerShip;
    public Slider barlength;
    float HPdata;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        HPdata = PlayerShip.GetComponent<PlayerShipMovement>().HP;
        barlength.value = HPdata;
    }

    public void ConsumeBoost()
    {
        HPdata = PlayerShip.GetComponent<PlayerShipMovement>().HP;
        barlength.value = HPdata;
    }

    public void RefillBoost()
    {
        HPdata = PlayerShip.GetComponent<PlayerShipMovement>().HP;
        barlength.value = HPdata;
    }
}
