using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void CargarJuego()
    {
        SceneManager.LoadScene("Juego");
    }

    public void CargarFinal()
    {
        SceneManager.LoadScene("Final");
    }
    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}