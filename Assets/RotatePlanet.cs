using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float speed = 0.1f;
    void Update()
    {
        transform.Rotate(Vector3.up, speed*Time.deltaTime);
    }
}
