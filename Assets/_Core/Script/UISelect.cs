using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{
    [SerializeField] Button equipeGrayScreen;
    [SerializeField] Button equipeAsthymScreen;
    [SerializeField] Button equipeMajScreen;
    [SerializeField] Button sortsGray;
    [SerializeField] Button sortsAsthym;
    [SerializeField] Button sortsMaj;
    [SerializeField] Button attack;

    [SerializeField] Button graySword;
    [SerializeField] Button grayPickaxe;       
    [SerializeField] Button grayHammer;

    
    public void SelectGraySword()
    {
        graySword.Select();
    }
    public void SelectGrayPickaxe()
    {
        grayPickaxe.Select();
    }
    public void SelectGrayHammer()
    {
        grayHammer.Select();
    }
    public void SelectSortGray()
    {
        sortsGray.Select();
    }
    public void SelectSortMaj()
    {
        sortsMaj.Select();
    }
    public void SelectSortAsthym()
    {
        sortsAsthym.Select();
    }
    public void SelectEquipeGray()
    {
        equipeGrayScreen.Select();
    }
    public void SelectEquipeAsthym()
    {
        equipeAsthymScreen.Select();
    }
    public void SelectEquipeMaj()
    {
        equipeMajScreen.Select();
    }
    public void SelectAtk()
    {
        attack.Select();
    }

}
