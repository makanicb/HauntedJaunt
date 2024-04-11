using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sense : MonoBehaviour
{
    //The tag to lookout for
    public string lookout;

    //When a collision occurs
    private void OnTriggerEnter(Collider other)
    {
        //If the other object's tag matches lookout
        if(other.CompareTag(lookout))
        {
            Debug.Log(lookout);
        }
    }
}
