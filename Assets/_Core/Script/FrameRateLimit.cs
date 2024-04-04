using UnityEngine;

public class FrameRateLimit : MonoBehaviour
{
    [SerializeField] private float framerate = 60;

    private void Awake()
    {
        Application.targetFrameRate = (int)framerate;
    }
    public void timeScaleDown()
    {
        Time.timeScale -= 0.1f;
    }
    public void timeScaleUp()
    {
        Time.timeScale += 0.1f;
    }
    public void timeScaleNormal()
    {
        Time.timeScale = 1f;
    }
}