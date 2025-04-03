using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Knight : MonoBehaviour
{
    SpriteRenderer sr;
    public AudioClip Stomp;
    public AudioSource steps;

    Animator animator;
    public float speed = 2;
    public bool canRun = true;

    public GameObject cam;

    public UnityEvent<float> Timetoshake;

    // Start is called before the first frame update
    void Start()
    {
        steps = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        cam = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = (direction < 0);
        animator.SetFloat("Movement", Mathf.Abs(direction));

        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Attack");
            canRun = false;
        }


        if (canRun == true) { 
        transform.position += transform.right * direction * speed * Time.deltaTime;
      }
    }

    public void AttackHasFinished()
    {
        Debug.Log("The attack has finished mon amis");
        canRun = true;
    }

    public void GiantStuff()
    {
        steps.clip = Stomp;
        steps.Play();

    }

    public void stompprotocol()
    {
        Timetoshake.Invoke(1);
    }

}
