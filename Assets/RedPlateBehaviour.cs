using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlateBehaviour : ColorPlateBehaviour
{
    [SerializeField] Color thisPlateColor;

    // plates are used to give a color to the ball. 
    
    private void Start()
    {
        thisPlateColor = Color.red;
    }
    public override void ChangeBallColor(Color col, Collider other)
    {
        other.gameObject.GetComponent<BallColorManager>().ChangeSelfColor(thisPlateColor);
    }
    public override void OnTriggerEnter(Collider other)
    {

        ChangeBallColor(Color.red, other);
    }

}
