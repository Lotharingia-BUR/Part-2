using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    float speed = 3;
    Rigidbody2D rb;
    float startTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.left * speed * Time.deltaTime);
        if (Time.time - startTime >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        collsion.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
