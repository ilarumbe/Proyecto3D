using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JumpscareController : MonoBehaviour
{
    public Image jumpscareImage;
    public AudioSource audioJumpscare;
    public float duracion = 1.5f;

    public void ActivarJumpscare()
    {
        StartCoroutine(DoJumpscare());
    }

    IEnumerator DoJumpscare()
    {
        jumpscareImage.gameObject.SetActive(true);

        if (audioJumpscare != null)
            audioJumpscare.Play();

        yield return new WaitForSeconds(duracion);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}