using UnityEngine;

public class ChosePlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject panelGray;
    [SerializeField] GameObject panelMaj;
    [SerializeField] GameObject panelAsthym;
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject[] players;
    [SerializeField] public GameObject dead;
    [SerializeField] TurnManager turnManager;
    [System.NonSerialized] public int currentPlayer;

    private void Awake() 
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
        turnManager.pA--;
    }
    public void ChoseHealer()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[2];
        currentPlayer = 2;
        turnManager.pA--;
    }
    public void ChoseFighter()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[0];
        currentPlayer = 0;
        turnManager.pA--;
    }
    public void PlayerDeath()
    {
        if(players[0].GetComponentInChildren<PlayerStats>().player.dead == true && players[1].GetComponentInChildren<PlayerStats>().player.dead == true && players[2].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            player = dead;
            deathScreen.SetActive(true);
        }
        else
        {
            player.GetComponentInChildren<Animator>().SetBool("Death", true);
            currentPlayer += 1;
            if(currentPlayer > 2) currentPlayer = 0;
            player = players[currentPlayer];
            if(players[currentPlayer].GetComponentInChildren<PlayerStats>().player.dead)
            {
                PlayerDeath();
            }
            
        }
    }
}
