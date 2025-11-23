using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorMuerte : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<JumpscareController>().ActivarJumpscare();
        }
    }
}
