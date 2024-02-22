using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{

    SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Selected(false);
        }*/
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

    private void OnMouseDown()
    {
        Selected(true);
    }
}
