using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindPosition : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] GameObject Basket;
    [SerializeField] GameObject Ball;

    void Start()
    {
        vcam = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        var transposer = vcam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = CalculateWhereToStand();
    }
    public float CamToBallDistance;
    Vector3 CalculateWhereToStand()
    {
        Debug.DrawLine(Basket.gameObject.transform.position, Ball.transform.position, Color.cyan);
        Vector3 fark = Basket.gameObject.transform.position - Ball.transform.position;
        Vector3 reversed = Vector3.zero;

        reversed.x = fark.x * -1;
        reversed.z = fark.z * -1;
        // we need orbital position not spherical
        reversed.y = 0;

        reversed *= 100;

        Vector3 clampedReverse = Vector3.ClampMagnitude(reversed, CamToBallDistance);

        //Debug.DrawLine(Ball.transform.position, Ball.transform.position+reversed, Color.white);
        //Debug.DrawLine(Ball.transform.position, Ball.transform.position + reversed.normalized, Color.red);
        Debug.DrawLine(Ball.transform.position, Ball.transform.position + clampedReverse, Color.black);

        //Debug.Log((Ball.transform.position + reversed).normalized);
        //Debug.Log("mag:" + reversed.magnitude);

        return clampedReverse;
    }
}
