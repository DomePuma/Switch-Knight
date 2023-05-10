using UnityEngine;

public class ChosePlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject panelGray;
    [SerializeField] GameObject panelMaj;
    [SerializeField] GameObject panelAsthym;
    
    [SerializeField] GameObject[] players;
    int currentPlayer;

    private void Start() 
    {
        player = players[0];
    }
    public void ChoseTank()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[1];
        currentPlayer = 1;
    }
    public void ChoseHealer()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[2];
        currentPlayer = 2;
    }
    public void ChoseFighter()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[0];
        currentPlayer = 0;
    }
    public void PlayerDeath()
    {
        currentPlayer += 1;
        if(currentPlayer > 2) currentPlayer = 0;
        player = players[currentPlayer];
    }
}
