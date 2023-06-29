using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] Button restartButton;
    [SerializeField] Button quitButton;
    [SerializeField] string sceneName;

    private void OnEnable() {
        restartButton.Select();
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Restart()
    {
        FindObjectOfType<TransfereData>().Fuite(sceneName);
    }
}