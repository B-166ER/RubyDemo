using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketBehaviour : MonoBehaviour
{
    Renderer rend;

    // generic basket color flashing animation
    //be festive
    void Start()
    {
        GameManager.instance.OnShotOccured += onShot;
        rend = gameObject.GetComponent<Renderer>();
    }
    private void onShot()
    {
        StartCoroutine( onShotRoutine() );
    }
    private IEnumerator onShotRoutine()
    {
        // animation to flash yellow color after shot
        float duration = 0.9f;
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Color originalColor = renderer.material.color;
        Color animColor = Color.yellow;


        while (duration > 0)
        {
            duration -= Time.deltaTime;

            //float lerp = Mathf.PingPong(Time.time, duration) / duration;
            
            
            rend.material.color = Color.Lerp(animColor ,originalColor  , duration);


            //.material.color = animColor;

            yield return new WaitForEndOfFrame();
        }
        rend.material.color = originalColor;
    }

    int stayingOnCollisionTooLong = 0;

    private void OnCollisionEnter(Collision collision)
    {
        stayingOnCollisionTooLong = 5;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(stayingOnCollisionTooLong < 10)collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,50,0) );
        stayingOnCollisionTooLong++;
    }
    private void OnCollisionExit(Collision collision)
    {
        stayingOnCollisionTooLong = 0;
    }
}
