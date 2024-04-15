using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using Unity.Mathematics;

public class GhostTracker : MonoBehaviour
{
    // Initialize vars
    private int ghostFlag;
    private float ghostDist;
    private Vector3 vecDiff;
    private Vector3 pPos;
    private float dProd;
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
        // Also update ghostFlag
        pPos = player.transform.position;
        switch (ghostFlag)
        {
            case 0:
                ghostDist = CalcGhostDist(player, ghost0);
                if (pPos.x >= -3.5 && pPos.x <= -0.5 && pPos.z >= 4.5 && pPos.z <= 7.5)
                {
                    ghostFlag++;
                }
                break;
            case 1:
                ghostDist = CalcGhostDist(player, ghost1);
                if (pPos.x >= -0.5 && pPos.x <= 2.5 && pPos.z >= 7.5 && pPos.z <= 10.5)
                {
                    ghostFlag++;
                }
                break;
            case 2:
                ghostDist = CalcGhostDist(player, ghost2);
                if (pPos.x >= 6.5 && pPos.x <= 9.5 && pPos.z >= 1.5 && pPos.z <= 4.5)
                {
                    ghostFlag++;
                }
                break;
            case 3:
                ghostDist = CalcGhostDist(player, ghost3);
                break;
            default:
                Debug.LogError("ghostFlag counted above 3");
                ghostDist = CalcGhostDist(player, ghost0);
                break;
        }
        SetGhostText ();
    }

    // Calculate distance to ghost using dot product
    float CalcGhostDist(GameObject p, GameObject g)
    {
        vecDiff = p.transform.position - g.transform.position;
        // Dot product
        dProd = (vecDiff.x * vecDiff.x) + (vecDiff.y * vecDiff.y) + (vecDiff.z * vecDiff.z);
        return math.sqrt(dProd);

        // return Vector3.Distance(p.transform.position, g.transform.position);
    }
}
