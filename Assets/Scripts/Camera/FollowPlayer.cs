using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offest;

    private void Start()
    {
        offest = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, offest.z + target.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 10 * Time.deltaTime);
    }
}
