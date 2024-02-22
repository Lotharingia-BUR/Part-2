using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{

    SpriteRenderer sr;
    Rigidbody2D rb;
    public float speed = 1000;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Selected(false);
    }

    public void Selected( bool isSelected)
    {
        if (isSelected)
        {
            sr.color = Color.yellow;
        }
        else if (!isSelected)
        {
            sr.color = Color.red;
        }
    }

    public void Kick(Vector2 force)
    {
        rb.AddForce(force * speed);
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }
}
