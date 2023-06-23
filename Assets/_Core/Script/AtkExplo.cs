using UnityEngine;
public class AtkExplo : MonoBehaviour
{
    [SerializeField] string fightSceneName;
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Weapon")
        {
            TransfereData transfereData = GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>();
            transfereData.enemiesToTransfere.Add(this.gameObject);
            transfereData.ChangeSceneToFight("COMBAT FOREST");
        }
    }
}