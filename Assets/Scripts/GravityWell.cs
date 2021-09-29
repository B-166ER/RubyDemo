using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{

    [SerializeField] float PushForce;

    private void OnTriggerStay(Collider collision)
    {
        Vector3 direction;

        //push ball to target
        direction = gameObject.transform.position - collision.gameObject.transform.position;

        // remove vertical force . ball might be suspended on air.
        direction.y = 0;
        direction *= PushForce;


        if (collision.gameObject.GetComponent<BallBehaviour>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction);
            Debug.DrawLine(collision.gameObject.transform.position , direction , Color.white,5f);
        }
    }
}
