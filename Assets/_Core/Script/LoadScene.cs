using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        GameObject.FindGameObjectWithTag("TransfereData").GetComponent<TransfereData>().ChangeSceneToExplo();
    }
}
