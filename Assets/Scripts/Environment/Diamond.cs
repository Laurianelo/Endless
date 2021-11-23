using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            GameManager.nOfDiamond += 1;
            Destroy(gameObject);
        }
    }
}
