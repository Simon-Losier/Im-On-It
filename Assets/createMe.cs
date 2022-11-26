using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject prefab;
    private bool done = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!done)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                done = true;
            }
        }
    }
}
