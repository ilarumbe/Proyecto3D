using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    public Transform jugador;
    public float distanciaParaPerseguir = 100f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);
        if (distanciaAlJugador <= distanciaParaPerseguir){
            agent.SetDestination(jugador.position);
        } else {
            agent.ResetPath();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<JumpscareController>().ActivarJumpscare();
        }
    }
}
