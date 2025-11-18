using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 5f;
    public CharacterController characterController;
    public Transform transformJugador;
    public Camera camaraJugador;
    public Vector3 movimiento;
    public float rotacionX;

    void Update()
    {
        MoviemientoDelJugador();
        MovimientoDeCamara();
    }
    void MoviemientoDelJugador()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        movimiento = transform.right * movX + transform.forward * movZ;
        characterController.SimpleMove(movimiento * velocidadMovimiento);
    }

    void MovimientoDeCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * velocidadRotacion;
        float ratonY = Input.GetAxis("Mouse Y") * velocidadRotacion;

        rotacionX -= ratonY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        camaraJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transformJugador.Rotate(Vector3.up * ratonX);
    }
}
