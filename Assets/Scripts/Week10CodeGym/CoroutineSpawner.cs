using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoroutineSpawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform SpawnLocation;
    Renderer PrefabRenderer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(prefab, MousePos, Quaternion.identity);
        }
    }
}
