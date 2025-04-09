using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{


    //Keep track of buttons for introduction
    public GameObject buttonobject;
    public Button Startwavebutton;


    // Start is called before the first frame update
    void Start()
    {
        Startwavebutton = buttonobject.GetComponent<Button>();
        Startwavebutton.onClick.AddListener(Disapear);
    }

    void Disapear()
    {
        gameObject.SetActive(false);
    }

}
