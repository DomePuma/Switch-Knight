using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject creditScreen;
    [SerializeField] Button quitGame;
    [SerializeField] Button reloadGame;

    public void EndScreenGame()
    {
        endScreen.SetActive(false);
        creditScreen.SetActive(true);
        quitGame.Select();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
