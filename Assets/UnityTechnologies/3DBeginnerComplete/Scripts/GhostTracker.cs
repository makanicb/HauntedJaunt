using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GhostTracker : MonoBehaviour
{
    // Initialize vars
    private int ghostFlag;
    private float ghostDist;
    public TextMeshProUGUI ghostTracker;
    public GameObject player;
    public GameObject ghost0;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;

    // Start is called before the first frame update
    void Start()
    {
        ghostFlag = 0;
        ghostDist = 0;
        SetGhostText();
        player = GameObject.Find("JohnLemon");
        ghost0 = GameObject.Find("Enemies/Ghost");
        ghost1 = GameObject.Find("Enemies/Ghost (1)");
        ghost2 = GameObject.Find("Enemies/Ghost (2)");
        ghost3 = GameObject.Find("Enemies/Ghost (3)");
    }

    // Set text for ghost tracker
    void SetGhostText()
    {
        ghostTracker.text = "Next ghost: " + ghostDist.ToString("F2") + " units away";
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate and display ghostDist every frame
        switch(ghostFlag)
        {
            case 0:
                ghostDist = Vector3.Distance(player.transform.position, ghost0.transform.position);
                break;
            case 1:
                ghostDist = Vector3.Distance(player.transform.position, ghost1.transform.position);
                break;
            case 2:
                ghostDist = Vector3.Distance(player.transform.position, ghost2.transform.position);
                break;
            case 3:
                ghostDist = Vector3.Distance(player.transform.position, ghost3.transform.position);
                break;
            default:
                Debug.LogError("ghostFlag counted above 3");
                ghostDist = Vector3.Distance(player.transform.position, ghost0.transform.position);
                break;
        }
        SetGhostText ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ghostTracker"))
        {
            ghostFlag++;
            other.gameObject.SetActive(false);
        }
    }
}
