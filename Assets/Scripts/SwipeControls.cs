using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControls : MonoBehaviour
{
    // if Swipe happened any frame. push the ball accourding direction

    public Swipe swipeRef;
    public GuideBehaviour guideRoot;

    //Vector3 pushDirectionCache;
    Vector3 confirmedPushLocationWhenThouched;


    public Vector3 ConfirmedPushLocationWhenThouched => confirmedPushLocationWhenThouched;


    public void ClearAfterBounce()
    {
        confirmedPushLocationWhenThouched = Vector3.zero;
    }

    Rigidbody selfRB;
    Transform selfTransform;


    void Start()
    {

        confirmedPushLocationWhenThouched = Vector3.zero;
        selfRB = gameObject.GetComponent<Rigidbody>();
        Transform selfTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pushDirectionCache = Vector3.zero;
        if (swipeRef.SwipeLeft)
        {
            pushDirectionCache = (guideRoot.left.transform.position - gameObject.transform.position).normalized * 100;
            confirmedPushLocationWhenThouched = pushDirectionCache;
            Debug.DrawRay(gameObject.transform.position, (guideRoot.left.gameObject.transform.position - gameObject.transform.position), Color.yellow, 3f);
            Debug.Log("left " + confirmedPushLocationWhenThouched);
        }
        if (swipeRef.SwipeRight)
        {
            pushDirectionCache = (guideRoot.right.transform.position - gameObject.transform.position).normalized * 100;
            confirmedPushLocationWhenThouched = pushDirectionCache;
            Debug.DrawRay(gameObject.transform.position, (guideRoot.right.gameObject.transform.position - gameObject.transform.position), Color.yellow, 3f);
        }
        if (swipeRef.SwipeUp)
        {
            pushDirectionCache = (guideRoot.front.transform.position - gameObject.transform.position).normalized * 270;
            // pushDirection = Vector3.forward * 200;
            pushDirectionCache += Vector3.up * 280;
            confirmedPushLocationWhenThouched = pushDirectionCache;
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + pushDirectionCache, Color.green, 2f);
            Debug.DrawLine(gameObject.transform.position, guideRoot.front.transform.position, Color.red, 2f);
        }
        if (swipeRef.SwipeDown)
        {
            pushDirectionCache = (guideRoot.back.transform.position - gameObject.transform.position).normalized * 200;
            confirmedPushLocationWhenThouched = pushDirectionCache;
            //pushDirection = Vector3.back *50;
            Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + pushDirectionCache, Color.green, 2f);
            Debug.DrawLine(gameObject.transform.position, guideRoot.back.transform.position, Color.red, 2f);
        }

        // omitted . force after ground touch
        //selfRB.AddForce(pushDirectionCache);
    }
}
