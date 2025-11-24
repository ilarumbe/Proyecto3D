using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirConQ : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
            Debug.Log("Juego cerrado con Q");
        }
    }
}