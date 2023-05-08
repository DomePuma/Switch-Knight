using UnityEngine;

public class ChosePlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] GameObject Gray; //Combattant
    [SerializeField] GameObject Maj; //Healer
    [SerializeField] GameObject Asthym; //Tank

    private void Start() 
    {
        player = Gray;
    }
    public void ChoseTank()
    {
        player = Asthym;
    }
    public void ChoseHealer()
    {
        player = Maj;
    }
    public void ChoseFighter()
    {
        player = Gray;
    }
}
