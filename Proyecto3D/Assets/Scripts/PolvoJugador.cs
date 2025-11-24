using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolvoJugador : MonoBehaviour
{
    public ParticleSystem polvo;
    public Animator animator;

    void Update()
    {
        var emission = polvo.emission;
        emission.enabled = animator.GetBool("isMoving");
    }
}