using UnityEngine;

public class ChosePlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject panelGray;
    [SerializeField] GameObject panelMaj;
    [SerializeField] GameObject panelAsthym;
    [SerializeField] GameObject Gray; //Combattant
    [SerializeField] GameObject Maj; //Healer
    [SerializeField] GameObject Asthym; //Tank

    private void Start() 
    {
        player = Gray;
    }
    public void ChoseTank()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = Asthym;
    }
    public void ChoseHealer()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = Maj;
    }
    public void ChoseFighter()
    {
        panelGray.SetActive(false);
        panelMaj.SetActive(false);
        panelAsthym.SetActive(false);
        player = Gray;
    }
}
