using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    [SerializeField]
    private float forwardSpeed = 5;

    //number of road
    //0= left; 1 = middle, 2 = right
    private int roadNum = 1;
    public float roadDistance = 2.5f; //dsitance between two roads
    private float gravity = -20;


    private void Start()
    {
        GetComponents();
    }

    // get all components we need 
    private void GetComponents()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        direction.z = forwardSpeed; //add good speed
        direction.y += gravity * Time.deltaTime;
        ChangeRoad();

        controller.Move(direction * Time.deltaTime); // moove player in good direction
    }

    //get inputs on which road we should be
    private void ChangeRoad()
    {
        if (SwipeManager.swipeRight)
        {
            roadNum++;
            if (roadNum == 3)
            {
                roadNum = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            if (roadNum == 0)
            {
                return;
            }
            roadNum--;
        }
        RightLeftMovements();
    }


    //change player's position
    private void RightLeftMovements()
    {
        //calcul the targetposition for player
        Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (roadNum == 0)
        {
            targetposition += Vector3.left * roadDistance;
        }
        else if (roadNum == 2)
        {
            targetposition += Vector3.right * roadDistance;

        }

        if (transform.position == targetposition) return;

        Vector3 diff = targetposition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }

    }


    //loose game when player enter on collision with something 
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
    
        if (hit.transform.tag == "Obstacle")
        {
            GameManager.gameOver = true;
        }
    }




}
