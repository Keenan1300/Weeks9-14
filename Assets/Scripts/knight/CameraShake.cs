using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.y < 0)
        {
            pos.y += 0.5f;
        }

        if (pos.y > 0)
        {
            pos.y -= 0.5f;
        }
        transform.position = pos;
    }

    public void shakeit()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.PerlinNoise(-1000, 1000) * 6;
        transform.position = pos;
        print("shooketh");
    }
}
