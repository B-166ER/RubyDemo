using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterBehaviour : MonoBehaviour
{

    ParticleSystem particleEmittor;

    void Start()
    {
        particleEmittor = gameObject.GetComponent<ParticleSystem>();
        StopEmitting();
        GameManager.instance.OnShotOccured += StartEmitting;
    }

    public void StopEmitting()
    {
        particleEmittor.Stop();
    }
    public void StartEmitting()
    {
        particleEmittor.Play();
    }


}
