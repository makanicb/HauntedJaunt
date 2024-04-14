using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    public AudioSource heartbeatPlay;
    Collider soundTrigger;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Ghost" || other.gameObject.tag == "Gargoyle") {
            heartbeatPlay.Play();
        }
    }

    void Start()
    {
        heartbeatPlay = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider>();
    }
}