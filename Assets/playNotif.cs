using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playNotif : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject go;
    public void playSound()
    {
        go.GetComponent<AudioSource>().Play();
    }
}
