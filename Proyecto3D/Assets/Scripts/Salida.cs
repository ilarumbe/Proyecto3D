using UnityEngine;

public class SalidaFinal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.instancia.CargarFinal();
        }
    }
}
