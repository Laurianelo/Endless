using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float movementSpeed = 5f;
    private Rigidbody enemyRb;
    private GameObject player;
    private float reactDistance = 30f;

    private void Start()
    {
        GetScComponents();
    }

    private void Update()
    {
        GoToTarget();
    }

    //Get Scene components 
    private void GetScComponents()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("player");// a remplacer par un tag 
    }


    // enemy goes towards the target and is destroyed after a certain distance
    private void GoToTarget()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 lookDirecttion;

        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);


        if(distance <= reactDistance)
        {
            if(distance > 5f)
            {
                targetPos.z += (distance / 2f);
            }
            lookDirecttion = (targetPos - transform.position).normalized;
            enemyRb.AddForce(lookDirecttion * movementSpeed);
        }
        else
        {
            lookDirecttion = (targetPos - transform.position).normalized;
            enemyRb.AddForce(lookDirecttion * movementSpeed *0.2f);
        }

        if((transform.position.z - player.transform.position.z) < -3f)
        {
            Destroy(gameObject);
        }
    }
}
