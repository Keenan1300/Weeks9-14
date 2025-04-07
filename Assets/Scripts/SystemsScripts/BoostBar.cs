using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public GameObject PlayerShip;
    public UnityEvent<int> OnTheHour;
    public Slider barlength;
    float Boostdata;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Boostdata = PlayerShip.GetComponent<PlayerShipMovement>().Boost;
        barlength.value = Boostdata;
    }

    public void ConsumeBoost() 
    {
        Boostdata = PlayerShip.GetComponent<PlayerShipMovement>().Boost;
        barlength.value = Boostdata;
    }

    public void RefillBoost()
    {
        Boostdata = PlayerShip.GetComponent<PlayerShipMovement>().Boost;
        barlength.value = Boostdata;
    }
}
