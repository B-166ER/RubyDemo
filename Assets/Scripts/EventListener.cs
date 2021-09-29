using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{

    void Start()
    {
        GameManager.instance.OnShotOccured += onShot;
    }

    public void onShot()
    {
        Debug.Log("Listener tested : shot");
    }
}
