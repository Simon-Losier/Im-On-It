using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOthersOnExit : MonoBehaviour
{
    [SerializeField] private string destroyTag;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(destroyTag))
            Destroy(other.gameObject);
    }
}
