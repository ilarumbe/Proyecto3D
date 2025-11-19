using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAnimationController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

    public float movementThreshold = 0.2f;

    void Update()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        bool isMoving = flatVel.magnitude > movementThreshold;

        animator.SetBool("isMoving", isMoving);
    }
}
