using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorMuerte : MonoBehaviour
{
    private JumpscareController jumpscare;

    void Start()
    {
        jumpscare = FindObjectOfType<JumpscareController>();

        if (jumpscare == null)
            Debug.LogError("No se encontró JumpscareController en la escena.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpscare.ActivarJumpscare();
        }
    }
}
