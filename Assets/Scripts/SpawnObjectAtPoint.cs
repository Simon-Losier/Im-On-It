using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectAtPoint : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform spawnPoint;
    
    public void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }
}
