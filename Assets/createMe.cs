using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMe : MonoBehaviour
{
    public GameObject prefab;
    private bool done;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (!done)
            {
                Instantiate(prefab, transform.position, transform.rotation);
                done = true;
            }
        }
    }
}
