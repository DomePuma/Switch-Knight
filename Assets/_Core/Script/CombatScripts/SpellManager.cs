using UnityEngine;
using System.Collections.Generic;
using System;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject panneauArmes;
    [SerializeField] PlayerAction UI;
    PlayerStats[] ListPlayer;
    private void Start() 
    {
        ListPlayer = FindObjectsOfType<PlayerStats>();        
    }

    public void ChangementArmes()
    {
        panneauArmes.SetActive(true);
    }
    public void MiseEnGarde()
    {
        Debug.Log("Mise En Guard");
        UI.QuitUI();
    }
    public void BouclierHumain()
    {
        Debug.Log("Pouclier Humain");
        UI.QuitUI();
    }
    public void PositionDefense()
    {
        Debug.Log("Position de Defense");
        UI.QuitUI();
    }
    public void Soins()
    {
        for(int i = 0; i > ListPlayer.Length; i++)
        {
            ListPlayer[i].player.health += ListPlayer[i].player.maxHealth/4;
        }
        UI.QuitUI();
    }
    public void Amplification()
    {
        Debug.Log("Amplification");
        UI.QuitUI();
    }

}
