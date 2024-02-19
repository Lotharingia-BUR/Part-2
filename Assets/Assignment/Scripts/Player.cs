using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //game objects and lists
    public GameObject ingrediants;
    public GameObject hand;
    public List<Sprite> images;
    public GameObject slider;

    //initiate components
    Rigidbody2D rb;
    Collider2D cb;
    Animator am;
    SpriteRenderer handObj;



    //vector 2's
    Vector2 targetPosition;
    Vector2 movement;

    //public variables
    public float speed = 1;
    float objHeld = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cb = GetComponent<Collider2D>();
        am = rb.GetComponent<Animator>();
        handObj = hand.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        
        movement = targetPosition - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = Vector3.one;
        }
        // move only of the x axis
        rb.MovePosition(rb.position + movement.normalized * Vector2.left * -speed * Time.deltaTime);
        am.SetFloat("moving", (movement * Vector2.left).magnitude);
    } 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //get point clicked
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        } else if (Input.GetMouseButtonDown(1))
        {
            ingrediants.BroadcastMessage("Grab", gameObject);
        }
    }

    public void Grabbed(int ID)
    {
        if (objHeld == 0)
        {
            objHeld = ID;
            handObj.sprite = images[ID];

            am.SetTrigger("grabbing");
        }
        
    }

    public void Deposit(GameObject cauldron)
    {
        if (objHeld != 0)
        {
            cauldron.SendMessage("addIngrediant", objHeld);
            slider.SendMessage("addIngrediant");
            am.SetTrigger("deposit");
            objHeld = 0;
            handObj.sprite = images[0];
        }
    }
}
