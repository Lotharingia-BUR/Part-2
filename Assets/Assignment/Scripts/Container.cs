using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public float ingrediantID = 0;
    Collider2D cb;
    private void Start()
    {
        cb = GetComponent<Collider2D>();
    }
    public void Grab(Collider2D playerPos, GameObject player)
    {
        if (cb.IsTouching(playerPos))
        {
            Debug.Log("selected" + ingrediantID);
            player.SendMessage("Grabbed", ingrediantID);
        } else
        {
            Debug.Log("blank");
        }
    }
}
