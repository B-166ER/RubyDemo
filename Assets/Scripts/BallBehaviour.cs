using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // is used for determining if the ball passed the basket the correct way
    public bool readyForBasket = false;
    SwipeControls sControls;

    [SerializeField] int orbitalMovementBreakerPercent;


    void Start()
    {
        sControls = gameObject.GetComponent<SwipeControls>();
        GameManager.instance.OnShotOccured += ShotTaken;
    }

    public void ShotTaken()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Debug.Log("Shot Taken " + gameObject.GetComponent<Rigidbody>().velocity);
    }

    Vector3 velocityCache;

    void Update()
    {
        Debug.DrawRay(gameObject.transform.position, new Vector3(-1, 0, 0), new Color(0, 0, 255));
    }

    public void AfterBounce()
    {

        ////////////////////// omitted . delete orbital movement all together needed //////////////////////


        // brake orbital movement
        velocityCache = gameObject.GetComponent<Rigidbody>().velocity;
        velocityCache.x = (velocityCache.x / 100) * orbitalMovementBreakerPercent;
        velocityCache.z = (velocityCache.z / 100) * orbitalMovementBreakerPercent;
        gameObject.GetComponent<Rigidbody>().velocity = velocityCache;
        

        /////////////////////remove orbital movement /////////////////////////////
        /*
        velocityCache = gameObject.GetComponent<Rigidbody>().velocity;
        velocityCache.x = 0;
        velocityCache.z = 0;
        gameObject.GetComponent<Rigidbody>().velocity = velocityCache;
        */

        

    }


    [SerializeField] BallController activeController;

    //bounce is manual to keep the bounce distance fixed
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            //standart sekme harketi için
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 300f, 0f));
            AfterBounce();
            activeController.WaitTouchGroundAndPush();
            //            gameObject.GetComponent<Rigidbody>().AddForce(activeController.TheForceThatIsWaitingToBeAddedOneRigidBody);
        }

    }

}
