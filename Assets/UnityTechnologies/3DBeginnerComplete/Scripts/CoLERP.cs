using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoLERP : MonoBehaviour
{
    private Transform john;

    public float maxDistance = 7f;
    public Color endColor = Color.red;
    public Color startColor = Color.white;
    private SkinnedMeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        john = player.transform;
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      //calculate distance between ghost and player
        float distanceToJohn = Vector3.Distance(transform.position, john.position);

        //calculate lerp parameter based on distance
        float t = Mathf.Clamp01(distanceToJohn / maxDistance);

        //lerp color
        Color lerpedColor = Color.Lerp(startColor, endColor, t);

        meshRenderer.material.color = lerpedColor;
    }
}
