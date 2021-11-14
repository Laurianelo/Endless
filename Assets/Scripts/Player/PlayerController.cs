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

    private float swipeSpeed = 80f;
    private float jumpForce = 10;
    private float gravity = -20;


    private void Start()
    {
        GetComponents();
    }


    private void Update()
    {
        direction.z = forwardSpeed; //add good speed
        direction.y += gravity * Time.deltaTime;
        ChangeRoad();

        if (SwipeManager.swipeUp && controller.isGrounded == true)
        {
            Jump();
        }

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.deltaTime); // moove player in good direction
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    //get inputs on which lan we should be
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
        //  transform.position = targetposition;
        //  transform.position = Vector3.Lerp(transform.position, targetposition, 75 * Time.deltaTime);//doesn't work IDK why

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


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
        //    GameManager.gameOver = true;
        }
    }


    // get all components we need 
    private void GetComponents()
    {
        controller = GetComponent<CharacterController>();
    }

}
