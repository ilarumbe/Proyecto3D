using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class OcultarControles : MonoBehaviour
{
    public string nombrePanel = "PanelControles";
    public float tiempoVisible = 5f;

    GameObject panel;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Juego")
        {
            StartCoroutine(BuscarYDesaparecer());
        }
    }

    IEnumerator BuscarYDesaparecer()
    {
        yield return null;

        panel = GameObject.Find(nombrePanel);

        if (panel == null)
        {
            Debug.LogError("No se encontró PanelControles en la escena del juego.");
            yield break;
        }

        yield return new WaitForSeconds(tiempoVisible);

        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}