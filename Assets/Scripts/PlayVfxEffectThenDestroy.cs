using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayVfxEffectThenDestroy : MonoBehaviour
{
    [SerializeField] private float tryDestroyDelay = 1f;
    
    private VisualEffect _vfx;
    private bool _tryDestroy;
    
    private void Awake()
    {
        _vfx = GetComponent<VisualEffect>();
        _tryDestroy = false;
    }
    
    private void OnEnable()
    {
        _vfx.Play();
        StartCoroutine(EnableTryDestroy());
    }
    
    private void Update()
    {
        if (_tryDestroy && _vfx.aliveParticleCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator EnableTryDestroy()
    {
        yield return new WaitForSeconds(tryDestroyDelay);
        _tryDestroy = true;
    }
}
