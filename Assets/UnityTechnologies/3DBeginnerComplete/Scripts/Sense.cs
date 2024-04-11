using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    //The tag to lookout for
    public string lookout;
    //The gameobject to toggle when a lookout is encountered
    public GameObject toggle;
    //The particleSystem to toggle
    private ParticleSystem sys;

    private void Start()
    {
        sys = toggle.GetComponent<ParticleSystem>();
    }
    //When a collision occurs
    private void OnTriggerEnter(Collider other)
    {
        //If the other object's tag matches lookout
        if(other.CompareTag(lookout))
        {
            Debug.Log("Hello there");
            sys.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(lookout))
        {
            Debug.Log("Bye-bye");
            sys.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
