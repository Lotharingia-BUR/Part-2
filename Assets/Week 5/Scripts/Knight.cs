using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    public float maxHealth = 5;
    float health;
    Rigidbody2D rb;
    Animator animator;
    bool clickingOnSelf = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right");
            animator.SetTrigger("Attack");
        }

        animator.SetFloat("movment", movement.magnitude);
        
    }
    private void OnMouseDown()
    {
        clickingOnSelf = true;
        SendMessage("TakeDamage", 1); 
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            clickingOnSelf = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health == 0)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            animator.SetTrigger("TakeDamage");
        }
    }


}
