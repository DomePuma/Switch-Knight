using UnityEngine;
using UnityEngine.SceneManagement;

public class Artefact : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Weapon")) return;
        SceneManager.LoadScene("EndScene");
        Cursor.lockState = CursorLockMode.None;
    }
}