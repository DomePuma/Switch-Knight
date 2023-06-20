using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeathManager : MonoBehaviour
{
    List<GameObject> players;
    [SerializeField] GameObject[] grayButtons;
    [SerializeField] GameObject[] asthymButtons;
    [SerializeField] GameObject[] majButtons;
    
    private void Start() 
    {
        players = FindObjectOfType<ChosePlayer>().players;
    }
    void Update()
    {
        if(players[0].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            grayButtons[0].GetComponentInChildren<Button>().interactable = false;
            grayButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
        if(players[1].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            asthymButtons[0].GetComponentInChildren<Button>().interactable = false;
            asthymButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
        if(players[2].GetComponentInChildren<PlayerStats>().player.dead == true)
        {
            majButtons[0].GetComponentInChildren<Button>().interactable = false;
            majButtons[1].GetComponentInChildren<Button>().interactable = false;
        }
    }
}
