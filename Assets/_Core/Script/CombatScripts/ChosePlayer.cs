using UnityEngine;
using System.Collections.Generic;  

public class ChosePlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject panelGray;
    [SerializeField] GameObject panelMaj;
    [SerializeField] GameObject panelAsthym;
    [SerializeField] GameObject deathScreen;
    [SerializeField] public GameObject dead;
    [System.NonSerialized] public int currentPlayer;
    public List<GameObject> players;
    TurnManager turnManager;
    TransfereData transfereData;
    

    private void Awake() 
    {
        transfereData = FindObjectOfType<TransfereData>();
        turnManager = FindObjectOfType<TurnManager>();
        players.Add(GameObject.FindGameObjectWithTag("Gray"));
        players.Add(GameObject.FindGameObjectWithTag("Asthym"));
        players.Add(GameObject.FindGameObjectWithTag("Maj"));
    }
    private void OnEnable() 
    {
        player = players[0];
        switch(transfereData.currentWeapon)
        {
            case 0:
                players[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Ciseaux;
                break;
            case 1:
                players[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Pioche;
                break;
            case 2:
                players[0].GetComponentInChildren<PlayerStats>().player.typeArmes = TypeArme.Marteau;
                break;
        }
    }
    public void ChoseTank()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[1];
        currentPlayer = 1;
        turnManager.pA--;
        if(turnManager.pA <= 0)
        {
            turnManager.PassTurn();
        }
    }
    public void ChoseHealer()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[2];
        currentPlayer = 2;
        turnManager.pA--;
        if(turnManager.pA <= 0)
        {
            turnManager.PassTurn();
        }
    }
    public void ChoseFighter()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = players[0];
        currentPlayer = 0;
        turnManager.pA--;
        if(turnManager.pA <= 0)
        {
            turnManager.PassTurn();
        }
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
