using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAnimationController : MonoBehaviour
{
    public Animator animator;
    public UnityEngine.AI.NavMeshAgent agent;

    public float movementThreshold = 0.2f;

    void Update()
    {
        Vector3 flatVel = new Vector3(agent.velocity.x, 0, agent.velocity.z);

        bool isMoving = flatVel.magnitude > movementThreshold;

        animator.SetBool("isMoving", isMoving);
    }
}
