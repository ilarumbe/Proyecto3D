using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 5f;

    public Transform transformJugador;
    public Camera camaraJugador;

    public float rotacionX;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MovimientoDelJugador();
        MovimientoDeCamara();
    }

    void MovimientoDelJugador()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        Vector3 direccion = transformJugador.right * movX + transformJugador.forward * movZ;

        Vector3 velocidadActual = rb.velocity;

        rb.velocity = new Vector3(
            direccion.x * velocidadMovimiento,
            velocidadActual.y,
            direccion.z * velocidadMovimiento
        );
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
