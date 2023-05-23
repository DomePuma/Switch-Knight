using UnityEngine;

public class SpellManager : MonoBehaviour
{
    [SerializeField] GameObject panneauArmes;
    [SerializeField] PlayerAction UI;
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
        Debug.Log("Soins");
        UI.QuitUI();
    }
    public void Amplification()
    {
        Debug.Log("Amplification");
        UI.QuitUI();
    }

}
