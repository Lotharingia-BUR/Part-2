using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    void spawn()
    {
        Instantiate(spawnObject);
    }
}
