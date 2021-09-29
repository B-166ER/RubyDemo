using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller1 : BallController
{
    [SerializeField] SwipeControls sControls;
    public override void PushTheBall(Vector3 f)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(sControls.ConfirmedPushLocationWhenThouched);
        sControls.ClearAfterBounce();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
