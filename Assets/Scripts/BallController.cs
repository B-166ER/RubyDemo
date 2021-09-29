using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallController : MonoBehaviour
{
    public Vector3 lastMouseMovementBase;
    public GameObject TargetReObject2atBase;
    public bool oncepush;
    public Vector3 TheForceThatIsWaitingToBeAddedOneRigidBody;
    public abstract void PushTheBall(Vector3 force);
    public virtual void WaitTouchGroundAndPush()
    {

        if (GameManager.instance.waitForTouchGroundBeforePush == true && oncepush == true)
        {
            if(oncepush==false)
            TheForceThatIsWaitingToBeAddedOneRigidBody = TheForceThatIsWaitingToBeAddedOneRigidBody * 0.4f;
            Vector3 force = Vector3.zero;

            float distance = Vector3.Distance(gameObject.transform.position, TargetReObject2atBase.transform.position);

            //the distance between ball and basket
            if(distance <10 && distance>4)
            {
                if(lastMouseMovementBase.y > lastMouseMovementBase.x * 3)
                {
                    // swipe is highly vertical make shot 
                    // make a aim assisted shot.
                    force = TargetReObject2atBase.transform.position - gameObject.transform.position;
                    force.Normalize();
                    force.x *= distance*27;
                    force.z *= distance*27;
                    force.y = 300;
                }
                
            }

            if(force != Vector3.zero)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(force);
            }
            else
            {
                //wait ground touch and add force
                gameObject.GetComponent<Rigidbody>().AddForce(TheForceThatIsWaitingToBeAddedOneRigidBody);
            }

            oncepush = false;
        }
        else return;
    }
}
