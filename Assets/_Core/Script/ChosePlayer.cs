using UnityEngine;

public class ChosePlayer : MonoBehaviour
{
    [System.NonSerialized] public GameObject player;
    [SerializeField] GameObject edward; //Combattant
    [SerializeField] GameObject winry; //Healer
    [SerializeField] GameObject alphonse; //Tank

    private void Start() 
    {
        player = edward;
    }
    public void ChoseTank()
    {
        player = alphonse;
    }
    public void ChoseHealer()
    {
        player = winry;
    }
    public void ChoseFighter()
    {
        player = edward;
    }
}
