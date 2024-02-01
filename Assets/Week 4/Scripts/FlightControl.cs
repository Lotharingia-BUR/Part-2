using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightControl : MonoBehaviour
{
    public float spawnTimer = 0f;
    public float spawnTime = Random.Range(1f, 5f);
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        Debug.Log(spawnTimer);
        if (spawnTimer - spawnTime > -0.1 && spawnTimer - spawnTime < 0.1)
        {
            spawnTimer = 0f;
            spawnTime = Random.Range(1f,5f);
            Instantiate(plane);
        }
    }
}
