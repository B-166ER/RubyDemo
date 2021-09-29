using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBallDetector : MonoBehaviour
{
    // if ball passed the basket the correct direction
    // scipt will check ball.readyforbasket bool  (which is set by upper trigger) and fire game manager's shotTaken event.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallBehaviour>() != null && other.gameObject.GetComponent<BallBehaviour>().readyForBasket)
        {
            other.gameObject.GetComponent<BallBehaviour>().readyForBasket = false;
            //other.gameObject.GetComponent<BallBehaviour>().ShotTaken();
            GameManager.instance.ShotOccured();
        }
    }

}
