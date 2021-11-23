using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    //win game when player enter on collision with the end line
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            GameManager.winGame = true; ;
        }
    }
}
