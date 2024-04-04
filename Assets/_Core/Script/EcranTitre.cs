using UnityEngine;

public class EcranTitre : MonoBehaviour
{
    [SerializeField] string sceneName;
    private void Start()
    {
        FindObjectOfType<TransfereData>().ChangeScene(sceneName);
    }
}
