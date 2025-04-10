using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    public GameObject PlayerShip;
    public Slider barlength;
    float Ammodata;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ammodata = PlayerShip.GetComponent<PlayerShipMovement>().Ammo;
        barlength.value = Ammodata;
    }

    public void ConsumeBoost()
    {
        Ammodata = PlayerShip.GetComponent<PlayerShipMovement>().Ammo;
        barlength.value = Ammodata;
    }

    public void RefillBoost()
    {
        Ammodata = PlayerShip.GetComponent<PlayerShipMovement>().Ammo;
        barlength.value = Ammodata;
    }
}
