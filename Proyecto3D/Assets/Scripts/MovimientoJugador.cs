using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidadMovimiento = 2f;
    public float velocidadCorrer = 4f;
    public float velocidadRotacion = 5f;

    public float staminaMax = 5f;
    public float staminaActual = 5f;
    public float consumoPorSegundo = 1.5f;
    public float recuperacionPorSegundo = 0.5f;
    private bool estaCansado = false;

    public Transform transformJugador;
    public Camera camaraJugador;
    public TMP_Text textoCansado;

    public float rotacionX;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.freezeRotation = true;

        Cursor.lockState = CursorLockMode.Locked;

        if (textoCansado != null)
            textoCansado.gameObject.SetActive(false);
    }

    void Update()
    {
        MovimientoDelJugador();
        MovimientoDeCamara();
        GestionDeStamina();
    }

    void MovimientoDelJugador()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        bool intentaCorrer = Input.GetKey(KeyCode.LeftShift);

        bool corriendo = intentaCorrer && !estaCansado && staminaActual > 0.1f;

        float velocidadActual = corriendo ? velocidadCorrer : velocidadMovimiento;

        Vector3 direccion = transformJugador.right * movX + transformJugador.forward * movZ;
        Vector3 velActual = rb.velocity;

        rb.velocity = new Vector3(
            direccion.x * velocidadActual,
            velActual.y,
            direccion.z * velocidadActual
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

    void GestionDeStamina()
    {
        bool estaCorriendo = Input.GetKey(KeyCode.LeftShift) && rb.velocity.magnitude > 0.1f && !estaCansado;

        if (estaCorriendo)
        {
            staminaActual -= consumoPorSegundo * Time.deltaTime;

            if (staminaActual <= 0f)
            {
                staminaActual = 0f;
                estaCansado = true;

                if (textoCansado != null)
                    textoCansado.gameObject.SetActive(true);
            }
        } else {
            staminaActual += recuperacionPorSegundo * Time.deltaTime;

            if (staminaActual >= staminaMax)
                staminaActual = staminaMax;

            if (staminaActual >= staminaMax * 0.4f)
            {
                estaCansado = false;

                if (textoCansado != null)
                    textoCansado.gameObject.SetActive(false);
            }
        }
    }
}
