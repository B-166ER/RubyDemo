using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColorManager : MonoBehaviour
{
    public Color ActiveColor;
    public BallEmitterController Emmiter;

    public static BallColorManager instance;


    private void Awake()
    {
        // First time run
        if (instance == null)
        {
            // Save a reference to 'this'
            instance = this;
        }

    }

    public void ChangeSelfColor(Color clr)
    {
        ActiveColor = clr;
        Emmiter.ActivateEmitter(clr);
    }
    public Color getColor()
    {
        return ActiveColor;
    }
    private void Start()
    {
        ActiveColor = Color.red;
        instance = this;
    }
}
