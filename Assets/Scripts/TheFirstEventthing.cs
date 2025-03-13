using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TheFirstEventthing : MonoBehaviour
{
    public RectTransform banana;

    public UnityEvent OnTimerHasFinished;
    public float timerlength = 3;
    public float t;

    private void Update()
    {
        t += Time.deltaTime;
            if(t > timerlength)
        {
            t = 0;
            OnTimerHasFinished.Invoke();
        }
    }

    public void mousejustenteredimage()
    {

        Debug.Log("moust just entered me!!! :) ");
        banana.localScale = Vector3.one * 1.25f;
        
    }

    public void mousejustleftimage() 
    {

        Debug.Log("moust just left me... Come back!! ;( ");
        banana.localScale = Vector3.one;
    }

}
