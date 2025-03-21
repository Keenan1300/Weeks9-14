using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Builder : MonoBehaviour
{
    // Start is called before the first frame update
    //Initialize component settings
    public GameObject FirstTankPiece;
    public GameObject SecondTankPiece;
    public GameObject ThirdTankPiece;

    Renderer PrefabRenderer;

    //Initialize variables
    public float constructiontime = 5;
    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    //Add Coroutine and Enumerator
    Coroutine IsBuilding;
    IEnumerator Buildparts;

    // Start is called before the first frame update
    void Start()
    {
        //Start the building process once this code is used
        FirstTankPiece.SetActive(false);
        SecondTankPiece.SetActive(false);
        ThirdTankPiece.SetActive(false);
        IsBuilding = StartCoroutine(BuildaPart());
    }

    //Define what it means to build a part of the tank
    IEnumerator BuildaPart()
    {
        //while true (for the frame it occupies) build a part means building specifcally one part of a tank. After this-
        //-building process is done, raise the flag that this enumerator is complete in its task.
        while (true)
        {
            Buildparts = buildFirstPartOfTank();
            yield return StartCoroutine(Buildparts);

            Buildparts = buildSecondPartOfTank();
            yield return StartCoroutine(Buildparts);

            Buildparts = buildThirdPartOfTank();
            yield return StartCoroutine(Buildparts);

        }

    }

    //Define what it means to build specifically one part of the tank
    IEnumerator buildFirstPartOfTank()
    {
        //reset timer to zero, so that each tank will be built as indicated by the construction time
        t = 0;
        while (t < constructiontime)
        {
            t += Time.deltaTime;
            FirstTankPiece.SetActive(true);
            print("First Part Built!");
            yield return null;
        }
        hour++;
        if (hour == constructiontime)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);

    }

    IEnumerator buildSecondPartOfTank()
    {
        //reset timer to zero, so that each tank will be built as indicated by the construction time
        t = 0;
        while (t < constructiontime)
        {
            t += Time.deltaTime;
            SecondTankPiece.SetActive(true);
            print("Second Part Built!");
            yield return null;
        }
        hour++;
        if (hour == constructiontime)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);

    }

    IEnumerator buildThirdPartOfTank()
    {
        //reset timer to zero, so that each tank will be built as indicated by the construction time
        t = 0;
        while (t < constructiontime)
        {
            t += Time.deltaTime;
            ThirdTankPiece.SetActive(true);
            print("Third Part Built!");
            yield return null;
        }
        hour++;
        if (hour == constructiontime)
        {
            hour = 1;
        }
        OnTheHour.Invoke(hour);
    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
