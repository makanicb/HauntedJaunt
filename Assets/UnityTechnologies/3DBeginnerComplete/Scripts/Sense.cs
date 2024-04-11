using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    //The tag to lookout for
    public string lookout;
    //The gameobject to toggle when a lookout is encountered
    public GameObject toggle;

    //When a collision occurs
    private void OnTriggerEnter(Collider other)
    {
        //If the other object's tag matches lookout
        if(other.CompareTag(lookout))
        {
            Debug.Log("Hello there");
            toggle.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(lookout))
        {
            Debug.Log("Bye-bye");
            toggle.SetActive(false);
        }
    }
}
