using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaySoundOnCollision : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private float randomPitchVariance = 0f;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1.2f)
        {
            _audioSource.pitch = Random.Range(1f - randomPitchVariance, 1f + randomPitchVariance);
            _audioSource.PlayOneShot(sound);
        }
    }
}
