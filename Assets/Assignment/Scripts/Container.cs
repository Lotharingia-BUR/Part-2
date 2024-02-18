using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public float ingrediantID = 0;

    public void Grab()
    {
        Debug.Log("selected" + ingrediantID);
    }
}
