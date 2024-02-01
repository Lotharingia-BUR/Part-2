using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public List<Sprite> sprites;
    public float threshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Rigidbody2D rigidbody;
    Vector2 currentPosition;
    float speed = 1f;
    public AnimationCurve landing;
    float timerValue;
    SpriteRenderer spriteRenderer;
    bool land = false;
    public int score = 0;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        Vector3 spawnPoint = new Vector3(Random.Range(-5f,5f),Random.Range(-5f,5f),0);
        transform.position = spawnPoint;
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 359f));
        speed = Random.Range(1f, 3f);
        spriteRenderer.sprite = sprites[Random.Range(0, 4)];
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0) 
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        if(land)
        {
            speed = 0.5f;
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);
            if(transform.localScale.z < 0.2f) 
            {
                Destroy(gameObject);
                score += 1;
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0) 
        {
            if (Vector2.Distance(currentPosition, points[0]) < threshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i<lineRenderer.positionCount - 2; i++) 
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }


    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(newPosition, lastPosition) > threshold) 
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Runway")
        {
            if (collision.OverlapPoint(currentPosition))
            {
                land = true;
            }
        }
        else
        {
            spriteRenderer.color = Color.red;
            if (Vector3.Distance(currentPosition, collision.gameObject.transform.position) < 0.6f)
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Runway")
        {
            land = true;
        } else
        {
            spriteRenderer.color = Color.white;
        }  
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        land = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        land = false;
    }
}
