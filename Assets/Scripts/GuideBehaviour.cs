using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideBehaviour : MonoBehaviour
{
    public GameObject Basket;
    public GameObject Ball;

    // these are 4 objects around the ball. 1  for each direction .their positions are used to find the direction for the ball push
    public GuideNode left,right,front,back;

    //Guide always must face to the bastket poll.But it has to to stay perfectly horizontal to keep guide node positions feed Yaxis values.
    Vector3 eulerRadiantRotationCache;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = Ball.transform.localPosition;
        gameObject.transform.LookAt(Basket.transform.position);
        eulerRadiantRotationCache = gameObject.transform.rotation.eulerAngles;
        // clearing vertical rotation
        eulerRadiantRotationCache.x = 0;
        eulerRadiantRotationCache.z = 0;
        //Debug.Log("Ballpos :" + Ball.transform.position);
        //Debug.Log("selfpos :" + gameObject.transform.position);
        gameObject.transform.eulerAngles = eulerRadiantRotationCache;
    }
}
