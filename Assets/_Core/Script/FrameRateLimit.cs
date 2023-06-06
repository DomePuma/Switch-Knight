using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimit : MonoBehaviour
{
    [SerializeField] private float framerate = 60;

    private void Awake()
    {
        Application.targetFrameRate = (int)framerate;
    }
}