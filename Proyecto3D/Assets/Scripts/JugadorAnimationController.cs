using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorAnimationController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;

    public float movementThreshold = 0.2f;
    public float velocidadCorrerUmbral = 3.0f;

    void Update()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        float magnitud = flatVel.magnitude;

        bool isMoving = magnitud > movementThreshold;
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            if (magnitud > velocidadCorrerUmbral)
            {
                animator.SetFloat("speed", 1.7f);
            }
            else
            {
                animator.SetFloat("speed", 1.0f);
            }
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
        }
    }
}
