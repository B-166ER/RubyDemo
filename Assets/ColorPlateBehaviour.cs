using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ColorPlateBehaviour : MonoBehaviour
{

    public abstract void ChangeBallColor(Color c, Collider other);
    public abstract void OnTriggerEnter(Collider other);
}
