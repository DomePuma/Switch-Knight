using UnityEngine;
using UnityEngine.UI;

public class ButtonTitleScreen : MonoBehaviour
{
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject creditsScreen;
    [SerializeField] GameObject storyScreen;
    [SerializeField] Button creditsButton;
    [SerializeField] Button attackButton;
    [SerializeField] Button storyButton;
    public void UIButtonStart()
    {
        titleScreen.SetActive(false);
        storyScreen.SetActive(true);
        storyButton.Select();

    }
    public void UICredits()
    {
        titleScreen.SetActive(false);
        creditsScreen.SetActive(true);
        creditsButton.Select();
    }
    public void QuitCredit()
    {
        creditsScreen.SetActive(false);
        titleScreen.SetActive(true);
        attackButton.Select();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void UIStoryScreen()
    {
        FindObjectOfType<TransfereData>().ChangeScene("MAP FOREST");
    }
}
