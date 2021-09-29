using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkGrowBehaviour : MonoBehaviour
{
    [Range(1f,0.1f)]
    [SerializeField] float shringBy;
    [Range(1f, 2f)]
    [SerializeField] float growBy;
    Transform selfTransform;

    // basket will shrink or grow depending on the color that ball has during shot
    void Start()
    {
        GameManager.instance.OnShotOccured += onShot;
        selfTransform = gameObject.transform;
    }
    void onShot ()
    {
        if (BallColorManager.instance.ActiveColor == Color.red) 
        {
            Shrink(shringBy);
        }
        else if (BallColorManager.instance.ActiveColor == Color.yellow)
        {
            Grow(growBy);
        }
        else
        {
            Debug.LogError("unsopprted color is being used");
        }
    }
    void Shrink(float shrinkMultiplier)
    {
        selfTransform.localScale *= shrinkMultiplier;
    }
    void Grow(float growMultiplier)
    {
        selfTransform.localScale *= growMultiplier;
    }
}
