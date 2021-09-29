using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPlateBehaviour : ColorPlateBehaviour
{
    [SerializeField] Color thisPlateColor;
    private void Start()
    {
        thisPlateColor = Color.yellow;
    }
    public override void ChangeBallColor(Color clr, Collider other)
    {
        other.gameObject.GetComponent<BallColorManager>().ChangeSelfColor(clr);
    }
    public override void OnTriggerEnter(Collider other)
    {
        ChangeBallColor(Color.yellow,other);
    }

}
