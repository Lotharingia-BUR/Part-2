using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    Collider2D cb;
    void Start()
    {
        cb = GetComponent<Collider2D>();
    }

    public void Grab(GameObject player)
    {
        if (cb.IsTouching(player.GetComponent<Collider2D>()))
        {
            player.SendMessage("Climb");
        }
    }
}
