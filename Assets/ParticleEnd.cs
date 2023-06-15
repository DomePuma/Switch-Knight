using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnd : MonoBehaviour
{
    [SerializeField] GameObject mainParticle;
    void Start()
    {
        var main = this.gameObject.GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    void OnParticleSystemStopped()
    {
        TurnManager turn = FindObjectOfType<TurnManager>();
        turn.EndTurnEnemy();
        mainParticle.SetActive(false);
        
    }
}
