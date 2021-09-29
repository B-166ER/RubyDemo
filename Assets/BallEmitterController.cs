using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEmitterController : MonoBehaviour
{
    // using particles to see which color currently ball has
    ParticleSystem System
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;

    public void ActivateEmitter(Color clr)
    {
        // deprecated but needed for fast solution
        System.startColor = clr;
        if (System)
        {
            System.Play();
        }
        else
            Debug.Log("asd");
    }
        
}
