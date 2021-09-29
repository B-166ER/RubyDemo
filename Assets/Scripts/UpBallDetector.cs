using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBallDetector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallBehaviour>() != null)
        {
            other.gameObject.GetComponent<BallBehaviour>().readyForBasket = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BallBehaviour>() != null)
        {
            collision.gameObject.GetComponent<BallBehaviour>().readyForBasket = true;
        }
    }

}
